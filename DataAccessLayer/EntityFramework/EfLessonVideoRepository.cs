using AutoMapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Extensions;
using DataAccessLayer.Helpers.Videos;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.LessonVideos;
using EntityLayer.DTOs.Users;
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
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public EfLessonVideoRepository(AppDbContext context, IVideoHelper videoHelper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context)
        {
            _videoHelper = videoHelper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _mapper = mapper;
        }
        public async Task<List<LessonVideo>> GetAllVideosByLesson(Lesson lesson)
        {
            var loginTeacherId = _user.GetLoggedInUserId();

            // Giris yapan kisinin o derse yukledigi ders videolari
            var videos = await _unitOfWork.GetRepository<LessonVideo>()
                .GetAllAsync(x => x.CreatedBy == loginTeacherId.ToString() && !x.IsDeleted,
                l => l.Lesson, d => d.Video, v => v.LessonVideoVisitors);

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

                lessonVideo.YoutubeVideoPath = lessonVideoAddDto.YoutubeVideoPath; // Eger video sectikten sonra Youtube videosu da entegre ettiyse Youtube video yolunu ilgili nesneye atiyoruz.

                await _unitOfWork.GetRepository<LessonVideo>().AddAsync(lessonVideo);
                await _unitOfWork.SaveAsync();

                return lessonVideo.Title;
            }
            else // Video secmemisse
            {
                var lessonVideo = new LessonVideo()
                {
                    Title = lessonVideoAddDto.Title,
                    YoutubeVideoPath = lessonVideoAddDto.YoutubeVideoPath,
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

        public async Task<List<LessonVideo>> GetAllVideosByLessonId(Guid lessonId)
        {
            var videos = await _unitOfWork.GetRepository<LessonVideo>()
               .GetAllAsync(x => x.LessonId == lessonId && !x.IsDeleted, l => l.Lesson, d => d.Video, v => v.LessonVideoVisitors);

            return videos;
        }

        public async Task IncreaseTheCountOfViewsOfTheLessonVideo(LessonVideo lessonVideo)
        {
            List<Visitor> visitors = _unitOfWork.GetRepository<Visitor>().GetAllAsync().Result; // Tum visitor'lari al

            var userId = _user.GetLoggedInUserId(); // Giris yapan kisinin id'si
            string getIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(); // Giren kullanicinin ip adresini aliyoruz
            // Giren kullanicinin tarayici turu, surumu ve isletim sistemi gibi bilgileri iceren UserAgent bilgisini alir.
            string getUserAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
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

            // Kullanicinin tikladigi ders videosu ve kullanicinin bilgileri eklenecek olan degerler
            var addLessonVideoVisitors = new LessonVideoVisitor(lessonVideo.Id, loginVisitor.Id);

            if (!lessonVideoVisitors.Any(x => x.VisitorId == addLessonVideoVisitors.VisitorId     // Eger ayni kullanici ayni videoya tekrar tiklamissa ViewCount artmayacak
                                    && x.LessonVideoId == addLessonVideoVisitors.LessonVideoId))
            // Bu satir ile kullanici ayni videoya tekrar tiklamadigi vakit o videonun ViewCount sayisini bir arttirma islemi gerceklestiriyoruz.

            {
                await _unitOfWork.GetRepository<LessonVideoVisitor>().AddAsync(addLessonVideoVisitors); // LessonVideoVisitor tablosuna kayit ekleme
                lessonVideo.ViewCount += 1; // Tiklanan ders videosunun ViewCount sayisini bir arttirma
                await _unitOfWork.GetRepository<LessonVideo>().UpdateAsync(lessonVideo); // ViewCount sayisini bir arttirdigimiz icin LessonVideo tablosunu guncelleme islemi
                await _unitOfWork.SaveAsync(); // degisiklikleri kaydetme islemi
            }
        }

        public async Task<HashSet<AppUser>> StudentsWatchingTheLessonVideo(Guid lessonVideoId) // İlgili ders videosunu izleyen ogrenciler
        {
            // Gelen lessonVideoId'ye esit olanlar LessonVideoVisitors kayitlarini listele
            var lessonVideoVisitors = await _unitOfWork.GetRepository<LessonVideoVisitor>()
                .GetAllAsync(v => v.LessonVideoId == lessonVideoId, x => x.Visitor, y => y.LessonVideo);

            List<Visitor> visitors = await _unitOfWork.GetRepository<Visitor>().GetAllAsync(); // Tum visitor'lari al

            // O ders videosunu izleyen ogrencilerin userId bilgilerini studentsId adli listeye kaydet.
            List<Guid> studentsId = new();
            foreach (var lessonVideoVisitor in lessonVideoVisitors)
            {
                foreach (var visitor in visitors)
                {
                    if (lessonVideoVisitor.VisitorId == visitor.Id)
                        studentsId.Add(visitor.UserId);
                }
            }

            HashSet<AppUser> studentsWatchingTheLessonVideo = new(); // Videoyu izleyen ogrencilerin kaydedilecegi liste
            foreach (var studentId in studentsId)
            {
                var user = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == studentId, g => g.Grade);
                studentsWatchingTheLessonVideo.Add(user);
            }

            return studentsWatchingTheLessonVideo;
        }
        public async Task<HashSet<LessonVideo>> LessonVideosByLoginStudent() // Giris yapan ogrencinin derslerine ait yuklenmis videolar
        {
            var loginStudentId = _user.GetLoggedInUserId();
            var student = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == loginStudentId);
            var studentGradeId = student.GradeId; // Giris yapan ogrencinin hangi sinifta oldugu bilgisi(Id)

            var studentLessons = await _unitOfWork.GetRepository<Lesson>()
                    .GetAllAsync(x => !x.IsDeleted && x.GradeId == studentGradeId); // Giris yapan ogrencinin bulundugu siniftaki dersler
            var lessonVideos = await _unitOfWork.GetRepository<LessonVideo>().GetAllAsync(x => !x.IsDeleted, v => v.Video, l => l.Lesson); // Yuklenmis tum ders videolari

            HashSet<LessonVideo> studentLessonVideos = new(); // Ogrencinin derslerine ait yuklenmis ders videolari

            foreach (var studentLesson in studentLessons)
            {
                foreach (var lessonVideo in lessonVideos)
                {
                    // Ogrencinin bulundugu siniftaki ders id'si ile lessonVideo'nun ders id'si esit ise listeye ekle.
                    if (lessonVideo.LessonId == studentLesson.Id)  // Ogrencinin derslerine ait yuklenmis ders videolarini al.
                    {
                        studentLessonVideos.Add(lessonVideo); // Bu ders videosunu listeye kaydet
                    }
                }
            }
            return studentLessonVideos;
        }
        public async Task<HashSet<LessonVideo>> UnwatchedVideosByLoginStudent()
        {
            var loginStudentId = _user.GetLoggedInUserId();
            var studentLessonVideos = await LessonVideosByLoginStudent(); // Giris yapan ogrencinin bulundugu siniftaki derslere ait yuklenmis tum ders videolari.

            HashSet<LessonVideo> studentUnwatchedLessonVideo = new(); // Giris yapan ogrencinin izlememis oldugu ders videolari

            // Ogrencinin izledigi ders videolarini belirlemek icin LessonVideoVisitor tablosunu kullaniyoruz.
            var lessonVideoVisitors = await _unitOfWork.GetRepository<LessonVideoVisitor>()
                .GetAllAsync(x => x.Visitor.UserId == loginStudentId); // LessonVideoVisitor tablosu uzerinden Visitor tablosuna ulasabildigimiz icin(iliskili oldugundan dolayi) Visitor tablosunda UserId'si giris yapan ogrencinin user id bilgisine esit ise

            // Ogrencinin izlemis oldugu videolarin Ders Video Id bilgisini secelim ve listeleyelim.
            var watchedLessonVideoIds = lessonVideoVisitors.Select(x => x.LessonVideoId).ToList();

            // İzlenmemis ders videolarini belirleme islemi
            foreach (var studentLessonVideo in studentLessonVideos) // Ogrencinin derslerine yuklenen tum ders videolari icinde don 
            {
                if (!watchedLessonVideoIds.Contains(studentLessonVideo.Id))
                {
                    studentUnwatchedLessonVideo.Add(studentLessonVideo); // izlemis oldugu video icinde bulunulan ders videosunun id'sini icermiyorsa listeye ekle.
                }
            }
            return studentUnwatchedLessonVideo;
        }
    }
}
