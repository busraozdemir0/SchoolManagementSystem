using EntityLayer.DTOs.Documents;
using EntityLayer.DTOs.Videos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers.Videos
{
    public interface IVideoHelper
    {
        Task<VideoUploadedDto> Upload(string name, IFormFile videoFile, string folderName = null);
        void Delete(string videoName);
    }
}
