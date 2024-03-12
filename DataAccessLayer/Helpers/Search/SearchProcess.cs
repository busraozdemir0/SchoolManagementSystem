using AutoMapper;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.Announcements;
using EntityLayer.DTOs.Contacts;
using EntityLayer.DTOs.Grades;
using EntityLayer.DTOs.Lessons;
using EntityLayer.DTOs.Reports;
using EntityLayer.DTOs.Roles;
using EntityLayer.DTOs.Search;
using EntityLayer.DTOs.Users;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace DataAccessLayer.Helpers.Search
{
    public class SearchProcess : ISearchProcess
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SearchModel> SearchAsync(string keyword, int page=1)
        {
            var announcement = await _unitOfWork.GetRepository<Announcement>().GetAllAsync(x => !x.IsDeleted && (x.Title.Contains(keyword)) || keyword.ToLower().Contains("duyuru"));

            var contact = await _unitOfWork.GetRepository<Contact>().GetAllAsync(x => !x.IsDeleted && (x.Subject.Contains(keyword)) || keyword.ToLower().Contains("iletişim"));

            var grade = await _unitOfWork.GetRepository<Grade>().GetAllAsync(x => !x.IsDeleted && (x.Name.Contains(keyword)));

            var lesson = await _unitOfWork.GetRepository<Lesson>().GetAllAsync(x => !x.IsDeleted && (x.LessonName.Contains(keyword)) || keyword.ToLower().Contains("ders"));

            var report = await _unitOfWork.GetRepository<Report>().GetAllAsync(x => !x.IsDeleted && (x.Title.Contains(keyword)) || keyword.ToLower().Contains("haber"));

            var role = await _unitOfWork.GetRepository<AppRole>().GetAllAsync(x => (x.Name.Contains(keyword)) || keyword.ToLower().Contains("rol"));

            var user = await _unitOfWork.GetRepository<AppUser>().GetAllAsync(x => (x.Name.Contains(keyword)) || 
                                            (x.Surname.Contains(keyword)) || (x.Email.Contains(keyword)) || 
                                            (x.UserName.Contains(keyword)) || keyword.ToLower().Contains("kullanıcı"));

            return new SearchModel
            {
                Announcements = announcement.ToPagedList(page,5),
                Contacts= contact.ToPagedList(page, 5),
                Grades = grade.ToPagedList(page, 5),
                Lessons = lesson.ToPagedList(page, 5),
                Reports = report.ToPagedList(page, 5),
                Roles = role.ToPagedList(page, 5),
                Users = user.ToPagedList(page, 5),
            };

        }
    }
}
