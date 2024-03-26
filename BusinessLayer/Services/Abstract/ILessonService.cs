﻿using EntityLayer.DTOs.Lessons;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface ILessonService:IGenericService<Lesson>
    {
        Task<List<Lesson>> TGetAllTeacherLessonsAsync(); // Giren ogretmen kullanicisinin verdigi dersler listeleniyor.
        Task<string> TSafeDeleteLessonAsync(Guid lessonId);
        Task<string> TUndoDeleteLessonAsync(Guid lessonId);
        Task<List<LessonListDto>> TLessonsInTheStudentsGrade(Guid userId);  // Ogrencinin bulundugu siniftaki dersler listelencek (sadece o ogretmenin verdigi dersler)

    }
}
