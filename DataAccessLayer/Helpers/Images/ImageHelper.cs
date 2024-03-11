using EntityLayer.DTOs.Images;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        private readonly string _wwwroot;
        private readonly IWebHostEnvironment _environment;
        private const string imgFolder = "images";
        private const string postImagesFolder = "post-images";
        private const string userImagesFolder = "user-images";

        public ImageHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
            _wwwroot = environment.WebRootPath;       
        }

        public async Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null)
        {
            folderName ??= imageType == ImageType.User ? userImagesFolder : postImagesFolder;

            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}")) // Eger belirtilen dizin yoksa
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}"); // Bu dizini olustur

            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName); // Uzantisi olmadan resim adi
            string fileExtension = Path.GetExtension(imageFile.FileName); // Resmin uzantisi

            name = ReplaceInvalidChars(name); // Resim ismindeki ozel ve turkce karakterleri degistirecek olan fonksiyon

            DateTime dateTime=DateTime.Now;

            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}"; // Ayni resim adlari olmamasi icin suanki tarihin mili saniye bilgisiyle isim olusturuldu

            var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, 
                                                                            FileShare.None, 1024 * 1024, useAsync: false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();

            string message = imageType == ImageType.User ? $"{newFileName} isimli kullanıcı resmi başarıyla eklendi." :
                                                       $"{newFileName} isimli gönderi resmi başarıyla eklendi.";

            return new ImageUploadedDto()
            {
                FullName = $"{folderName}/{newFileName}"
            };
        }
        public async void Delete(string imageName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}/{imageName}");
            if(File.Exists(fileToDelete)) // Silinecek resim gercekten var mi
                File.Delete(fileToDelete);
        }

        private string ReplaceInvalidChars(string fileName) // Turkce veya ozel karakterleri degistirecek olan fonksiyon
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }
    }
}
