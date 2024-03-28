using EntityLayer.DTOs.Documents;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers.Documents
{
    public interface IDocumentHelper
    {
        Task<DocumentUploadedDto> Upload(string name, IFormFile documentFile, string folderName = null);
        void Delete(string documentName);
    }
}
