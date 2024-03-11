using DataAccessLayer.Repository.Abstract;
using EntityLayer.DTOs.Abouts;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAboutDal : IRepository<About>
    {
        Task<About> GetByIdAsync(int id);
        Task UpdateAboutAndImage(AboutUpdateDto aboutUpdateDto);
    }
}
