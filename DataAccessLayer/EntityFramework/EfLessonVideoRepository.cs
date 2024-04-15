using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Extensions;
using DataAccessLayer.Helpers.Videos;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfLessonVideoRepository : Repository<LessonVideo>, ILessonVideoDal
    {
        private readonly IVideoHelper _videoHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public EfLessonVideoRepository(AppDbContext context, IVideoHelper videoHelper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _videoHelper = videoHelper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<List<LessonVideo>> GetAllVideosByLesson(Lesson lesson)
        {
            var loginTeacherId = _user.GetLoggedInUserId();

            // Giris yapan kisinin o derse yukledigi ders videolari
            var videos = await _unitOfWork.GetRepository<LessonVideo>()
                .GetAllAsync(x => x.CreatedBy == loginTeacherId.ToString() && !x.IsDeleted, l => l.Lesson, d => d.Video);

            List<LessonVideo> lessonVideosByLesson = new();
            foreach (var Video in videos)
            {
                if (Video.LessonId == lesson.Id)
                    lessonVideosByLesson.Add(Video);
            }

            return lessonVideosByLesson;
        }

        public async Task<string> AddLessonVideoAsync(LessonVideoAddDto lessonVideoAddDto)
        {
            var loginTeacherId = _user.GetLoggedInUserId();

            if (lessonVideoAddDto.File != null) // Eger video secmisse
            {
                // Video yukleme islemleri
                var videoUpload = await _videoHelper.Upload(lessonVideoAddDto.Title, lessonVideoAddDto.File);
                Video video = new(videoUpload.FullName, lessonVideoAddDto.File.ContentType);
                await _unitOfWork.GetRepository<Video>().AddAsync(video);

                // Entity Constructure sayesinde Video Entity'si ile beraber ders videosu olusturduk.
                var lessonVideo = new LessonVideo(lessonVideoAddDto.Title,
                    lessonVideoAddDto.LessonId, video.Id, loginTeacherId.ToString());

                await _unitOfWork.GetRepository<LessonVideo>().AddAsync(lessonVideo);
                await _unitOfWork.SaveAsync();

                return lessonVideo.Title;
            }
            else // Video secmemisse
            {
                var lessonVideo = new LessonVideo()
                {
                    Title = lessonVideoAddDto.Title,
                    YoutubeVideoPath=lessonVideoAddDto.YoutubeVideoPath,
                    LessonId = lessonVideoAddDto.LessonId,
                    CreatedBy = loginTeacherId.ToString(),    // Giris yapan yani videoyu yukleyen kisinin id'si
                };
                await _unitOfWork.GetRepository<LessonVideo>().AddAsync(lessonVideo); // ve bu lessonVideo nesnesini kaydet
                await _unitOfWork.SaveAsync();

                return lessonVideo.Title;
            }
        }
        public async Task<string> UpdateLessonVideoAsync(LessonVideoUpdateDto lessonVideoUpdateDto)
        {
            var lessonVideo = await _unitOfWork.GetRepository<LessonVideo>().
                GetAsync(x => x.Id == lessonVideoUpdateDto.Id, d => d.Video, l => l.Lesson);

            if (lessonVideoUpdateDto.File != null) // Eger bir video secilmisse
            {
                if (lessonVideoUpdateDto.VideoId != null) // Eger ders videosu guncelleme sirasinda VideoId bos degilse yani bir video varsa o video silinecek.
                    _videoHelper.Delete(lessonVideo.Video.FileName); // Once ders videosunda var olan video silinecek

                // Ardindan yeni bir video yukleme islemi
                var videoUpload = await _videoHelper.Upload(lessonVideoUpdateDto.Title, lessonVideoUpdateDto.File);
                Video video = new(videoUpload.FullName, lessonVideoUpdateDto.File.ContentType);
                await _unitOfWork.GetRepository<Video>().AddAsync(video);

                lessonVideo.VideoId = video.Id;
            }

            lessonVideo.Title = lessonVideoUpdateDto.Title;
            lessonVideo.YoutubeVideoPath = lessonVideoUpdateDto.YoutubeVideoPath;
            lessonVideo.LessonId = lessonVideoUpdateDto.LessonId;
            lessonVideo.CreatedBy = lessonVideoUpdateDto.CreatedBy;
            lessonVideo.ModifiedDate = DateTime.Now;

            await _unitOfWork.GetRepository<LessonVideo>().UpdateAsync(lessonVideo);
            await _unitOfWork.SaveAsync();

            return lessonVideo.Title;
        }
        public async Task<string> SafeDeleteLessonVideoAsync(Guid lessonVideoId)
        {
            var lessonVideo = await _unitOfWork.GetRepository<LessonVideo>().GetByGuidAsync(lessonVideoId);

            lessonVideo.IsDeleted = true;
            lessonVideo.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<LessonVideo>().UpdateAsync(lessonVideo);
            await _unitOfWork.SaveAsync();

            return lessonVideo.Title;
        }

        public async Task<string> UndoDeleteLessonVideoAsync(Guid lessonVideoId)
        {
            var lessonVideo = await _unitOfWork.GetRepository<LessonVideo>().GetByGuidAsync(lessonVideoId);

            lessonVideo.IsDeleted = false;
            lessonVideo.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<LessonVideo>().UpdateAsync(lessonVideo);
            await _unitOfWork.SaveAsync();

            return lessonVideo.Title;
        }

        public async Task<List<LessonVideo>> GetAllVideosByLesson(Guid lessonId)
        {
            var videos = await _unitOfWork.GetRepository<LessonVideo>()
               .GetAllAsync(x => x.LessonId == lessonId && !x.IsDeleted, l => l.Lesson, d => d.Video);

            return videos;
        }

        public async Task IncreaseTheCountOfViewsOfTheLessonVideo(LessonVideo lessonVideo)
        {
            List<Visitor> visitors = _unitOfWork.GetRepository<Visitor>().GetAllAsync().Result; // Tum visitor'lari al

            var userId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si
            string getIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(); // Giren kullanicinin ip adresini aliyoruz
            string getUserAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"]; // Giren kullanicinin tarayici turu, surumu ve isletim sistemi gibi bilgileri iceren UserAgent bilgisini alir.
            Visitor visitor = new(userId, getIp, getUserAgent);

            // Bir kullanici vt'ye sadece bir defa kaydedilecek. Bu yuzden eger giren kullanici LessonVideoVisitor tablosunda kayitli ise tekrar kaydetmemeliyiz.

            if (!visitors.Any(x => x.UserId == visitor.UserId)) // Eger giren kullanicinin id'si Visitor tablosunda yoksa ekleme islemi gerceklesecek
            {
                _unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
                _unitOfWork.Save();
            }

            // LessonVideoVisitor tablosundaki bilgileri getir dedik ve getir derken LessonVideo ve Visitor tablosunu LessonVideoVisitor tablosuna include ettik.
            var lessonVideoVisitors = await _unitOfWork.GetRepository<LessonVideoVisitor>().GetAllAsync(null, x => x.Visitor, y => y.LessonVideo);

            var loginVisitor = await _unitOfWork.GetRepository<Visitor>().GetAsync(x => x.UserId == userId);

            var addLessonVideoVisitors = new LessonVideoVisitor(lessonVideo.Id, loginVisitor.Id); // Kullanicinin tikladigi ders videosu ve kullanicinin bilgileri eklenecek olan degerler

            if (!lessonVideoVisitors.Any(x => x.VisitorId == addLessonVideoVisitors.VisitorId     // Eger ayni kullanici ayni videoya tekrar tiklamissa ViewCount artmayacak
                                    && x.LessonVideoId == addLessonVideoVisitors.LessonVideoId))  // Bu satir ile kullanici ayni videoya tekrar tiklamadigi vakit o videonun ViewCount sayisini bir arttirma islemi gerceklestiriyoruz.
                                                                                                                
            {
                await _unitOfWork.GetRepository<LessonVideoVisitor>().AddAsync(addLessonVideoVisitors); // LessonVideoVisitor tablosuna kayit ekleme
                lessonVideo.ViewCount += 1; // Tiklanan ders videosunun ViewCount sayisini bir arttirma
                await _unitOfWork.GetRepository<LessonVideo>().UpdateAsync(lessonVideo); // ViewCount sayisini bir arttirdigimiz icin LessonVideo tablosunu guncelleme islemi
                await _unitOfWork.SaveAsync(); // degisiklikleri kaydetme islemi
            }
        }
    }
}
