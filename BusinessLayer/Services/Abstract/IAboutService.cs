using EntityLayer.DTOs.Abouts;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IAboutService:IGenericService<About>
    {
        Task<About> TGetByIdAsync(int id);
        Task<string> TGetSchoolNameAsync(); // Okul adini dondurecek olan metod
        Task TUpdateAboutAndImage(AboutUpdateDto aboutUpdateDto);
    }
}
