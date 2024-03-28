using EntityLayer.DTOs.Documents;
using EntityLayer.DTOs.Images;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers.Documents
{
    public class DocumentHelper : IDocumentHelper
    {
        private readonly string _wwwroot;
        private readonly IWebHostEnvironment _environment;
        private const string documentFolder = "documents";
        public DocumentHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
            _wwwroot = environment.WebRootPath;
        }
        public async Task<DocumentUploadedDto> Upload(string name, IFormFile documentFile, string folderName = null)
        {
            folderName = documentFolder;

            if (!Directory.Exists($"{_wwwroot}/{documentFolder}")) // Eger belirtilen dizin yoksa
                Directory.CreateDirectory($"{_wwwroot}/{documentFolder}"); // Bu dizini olustur

            string oldFileName = Path.GetFileNameWithoutExtension(documentFile.FileName); // Uzantisi olmadan dokuman adi
            string fileExtension = Path.GetExtension(documentFile.FileName); // Dokumanin uzantisi

            name = InvalidChars.ReplaceInvalidChars(name); // Dokuman ismindeki ozel ve turkce karakterleri degistirecek olan fonksiyon

            DateTime dateTime = DateTime.Now;

            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}"; // Ayni dokuman adlari olmamasi icin suanki tarihin mili saniye bilgisiyle isim olusturuldu.

            var path = Path.Combine($"{_wwwroot}/{folderName}", newFileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write,
                                                                            FileShare.None, 1024 * 1024, useAsync: false);
            await documentFile.CopyToAsync(stream);
            await stream.FlushAsync();

            string message = $"{newFileName} isimli doküman başarıyla yüklendi.";
                                                       

            return new DocumentUploadedDto()
            {
                FullName = $"{newFileName}"
            };
        }

        public void Delete(string documentName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{documentFolder}/{documentName}");
            if (File.Exists(fileToDelete)) // Silinecek dokuman gercekten mevcutsa silme islemi yapilacak.
                File.Delete(fileToDelete);
        }
   
    }
}
