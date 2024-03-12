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

namespace DataAccessLayer.Helpers.Search
{
    public class SearchProcess : ISearchProcess
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchProcess(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SearchModel> SearchAsync(string keyword)
        {
            var announcement = await _unitOfWork.GetRepository<Announcement>().GetAllAsync(x => !x.IsDeleted && (x.Title.Contains(keyword)) || keyword.ToLower().Contains("duyuru"));
            var mapAnnouncement = _mapper.Map<List<AnnouncementListDto>>(announcement);

            var contact = await _unitOfWork.GetRepository<Contact>().GetAllAsync(x => !x.IsDeleted && (x.Subject.Contains(keyword)) || keyword.ToLower().Contains("iletişim"));
            var mapContact = _mapper.Map<List<ContactDto>>(contact);

            var grade = await _unitOfWork.GetRepository<Grade>().GetAllAsync(x => !x.IsDeleted && (x.Name.Contains(keyword)));
            var mapGrade = _mapper.Map<List<GradeListDto>>(grade);

            var lesson = await _unitOfWork.GetRepository<Lesson>().GetAllAsync(x => !x.IsDeleted && (x.LessonName.Contains(keyword)) || keyword.ToLower().Contains("ders"));
            var mapLesson = _mapper.Map<List<LessonListDto>>(lesson);

            var report = await _unitOfWork.GetRepository<Report>().GetAllAsync(x => !x.IsDeleted && (x.Title.Contains(keyword)) || keyword.ToLower().Contains("haber"));
            var mapReport = _mapper.Map<List<ReportDto>>(report);

            var role = await _unitOfWork.GetRepository<AppRole>().GetAllAsync(x => (x.Name.Contains(keyword)) || keyword.ToLower().Contains("rol"));
            var mapRole = _mapper.Map<List<RoleListDto>>(role);

            var user = await _unitOfWork.GetRepository<AppUser>().GetAllAsync(x => (x.Name.Contains(keyword)) || 
                                            (x.Surname.Contains(keyword)) || (x.Email.Contains(keyword)) || 
                                            (x.UserName.Contains(keyword)) || keyword.ToLower().Contains("kullanıcı"));
            var mapUser = _mapper.Map<List<UserListDto>>(user);

            return new SearchModel
            {
                Announcements = mapAnnouncement,
                Contacts=mapContact,
                Grades = mapGrade,
                Lessons = mapLesson,
                Reports = mapReport,
                Roles = mapRole,
                Users = mapUser,
            };

        }
    }
}
