using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IGradeService:IGenericService<Grade>
    {
        Task<Grade> TGetGradeByIdAsync(int id);
        Task<string> TSafeDeleteGradeAsync(int gradeId);
        Task<string> TUndoDeleteGradeAsync(int gradeId);
    }
}
