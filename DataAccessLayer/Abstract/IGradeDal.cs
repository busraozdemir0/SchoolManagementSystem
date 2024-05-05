using DataAccessLayer.Repository.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGradeDal : IRepository<Grade>
    {
        Task<Grade> GetGradeByIdAsync(int? id);
        Task<string> SafeDeleteGradeAsync(int gradeId);
        Task<string> UndoDeleteGradeAsync(int gradeId);
        Task<string> IsThereTheSameGradeName(string gradeName); // Gelen sinif adi db'de var mi diye kontrol edecegimiz eger varsa hata mesaji dondurecegimiz metod.
    }
}
