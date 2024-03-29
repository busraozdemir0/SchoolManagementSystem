using EntityLayer.DTOs.Documents;
using EntityLayer.DTOs.Videos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers.Videos
{
    public class VideoHelper : IVideoHelper
    {
        private readonly string _wwwroot;
        private readonly IWebHostEnvironment _environment;
        private const string videoFolder = "videos";

        public VideoHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
            _wwwroot = environment.WebRootPath;
        }
        public async Task<VideoUploadedDto> Upload(string name, IFormFile videoFile, string folderName = null)
        {
            folderName = videoFolder;

            if (!Directory.Exists($"{_wwwroot}/{videoFolder}")) // Eger belirtilen dizin yoksa
                Directory.CreateDirectory($"{_wwwroot}/{videoFolder}"); // Bu dizini olustur

            string oldFileName = Path.GetFileNameWithoutExtension(videoFile.FileName); // Uzantisi olmadan video adi
            string fileExtension = Path.GetExtension(videoFile.FileName); // Videonun uzantisi

            name = InvalidChars.ReplaceInvalidChars(name); // Video ismindeki ozel ve turkce karakterleri degistirecek olan fonksiyon

            DateTime dateTime = DateTime.Now;

            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}"; // Ayni video adlari olmamasi icin suanki tarihin mili saniye bilgisiyle isim olusturuldu.

            var path = Path.Combine($"{_wwwroot}/{folderName}", newFileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write,
                                                                            FileShare.None, 1024 * 1024, useAsync: false);
            await videoFile.CopyToAsync(stream);
            await stream.FlushAsync();

            string message = $"{newFileName} isimli video başarıyla yüklendi.";


            return new VideoUploadedDto()
            {
                FullName = $"{newFileName}"
            };
        }
        public void Delete(string videoName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{videoFolder}/{videoName}");
            if (File.Exists(fileToDelete)) // Silinecek video gercekten mevcutsa silme islemi yapilacak.
                File.Delete(fileToDelete);
        }
    }
}
