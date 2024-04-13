using AutoMapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Consts;
using DataAccessLayer.Extensions;
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
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace DataAccessLayer.Helpers.Search
{
    public class SearchProcess : ISearchProcess
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILessonDal _lessonDal;
        private readonly IGradeDal _gradeDal;
        private readonly IUserDal _userDal;
        private readonly IRoleDal _roleDal;
        private readonly IAnnouncementDal _announcementDal;
        private readonly ILessonScoreDal _lessonScoreDal;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public SearchProcess(IUnitOfWork unitOfWork, ILessonDal lessonDal, IGradeDal gradeDal, IMapper mapper, IAnnouncementDal announcementDal, IUserDal userDal, IRoleDal roleDal, IHttpContextAccessor httpContextAccessor, ILessonScoreDal lessonScoreDal)
        {
            _unitOfWork = unitOfWork;
            _lessonDal = lessonDal;
            _gradeDal = gradeDal;
            _mapper = mapper;
            _announcementDal = announcementDal;
            _userDal = userDal;
            _roleDal = roleDal;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _lessonScoreDal = lessonScoreDal;
        }

        public async Task<SearchModel> SearchAsync(string keyword, int page=1)
        {
            var announcement = await _unitOfWork.GetRepository<Announcement>()
                .GetAllAsync(x => !x.IsDeleted && (x.Title.ToLower().Contains(keyword)) || keyword.ToLower().Contains("duyuru"));

            var contact = await _unitOfWork.GetRepository<Contact>()
                .GetAllAsync(x => !x.IsDeleted && (x.Subject.ToLower().Contains(keyword)) || keyword.ToLower().Contains("iletişim"));

            var grade = await _unitOfWork.GetRepository<Grade>()
                .GetAllAsync(x => !x.IsDeleted && (x.Name.ToLower().Contains(keyword)));

            var lesson = await _unitOfWork.GetRepository<Lesson>()
                .GetAllAsync(x => !x.IsDeleted && (x.LessonName.ToLower().Contains(keyword)) || keyword.ToLower().Contains("ders"));
            
            var lessonScore = await _unitOfWork.GetRepository<LessonScore>()
                .GetAllAsync(x => !x.IsDeleted && (keyword.ToLower().Contains("not")) || (keyword.ToLower().Contains("puan")), l=>l.Lesson, u=>u.User);

            var report = await _unitOfWork.GetRepository<Report>()
                .GetAllAsync(x => !x.IsDeleted && (x.Title.ToLower().Contains(keyword)) || keyword.ToLower().Contains("haber"));

            var role = await _unitOfWork.GetRepository<AppRole>()
                .GetAllAsync(x => (x.Name.ToLower().Contains(keyword)) || keyword.ToLower().Contains("rol"));

            var user = await _unitOfWork.GetRepository<AppUser>()
                                            .GetAllAsync(x => (x.Name.ToLower().Contains(keyword)) || 
                                            (x.Surname.ToLower().Contains(keyword)) || (x.Email.ToLower().Contains(keyword)) || 
                                            (x.UserName.ToLower().Contains(keyword)) || keyword.ToLower().Contains("kullanıcı"));

            return new SearchModel
            {
                Announcements = announcement.ToPagedList(page,5),
                Contacts= contact.ToPagedList(page, 5),
                Grades = grade.ToPagedList(page, 5),
                Lessons = lesson.ToPagedList(page, 5),
                LessonScores = lessonScore.ToPagedList(page, 5),
                Reports = report.ToPagedList(page, 5),
                Roles = role.ToPagedList(page, 5),
                Users = user.ToPagedList(page, 5),
            };

        }

        public async Task<SearchModel> SearchStudentAsync(string keyword, int page = 1)
        {
            var lessons = await _unitOfWork.GetRepository<Lesson>()
                .GetAllAsync(x => !x.IsDeleted); // Silinmemis olan tum dersleri listele
            var lessonStudent = await _lessonDal.LessonsInTheStudent(lessons); // lessons gonderilerek giris yapan ogrenci kullanicisinin dersleri listeleniyor. 
            var mapLessonStudent = _mapper.Map<List<Lesson>>(lessonStudent);
            HashSet<Lesson> studentLessons = new();
            foreach (var item in mapLessonStudent)
            {
                if (item.LessonName.ToLower().Contains(keyword) || keyword.ToLower().Contains("ders"))
                    studentLessons.Add(item);
            }

            var announcements = await _announcementDal.StudentAnnouncementListAsync(); // Duyurular icerisinde Ogrenci ve User rolu kullanilarak yapilan duyurular listelenecek.
            HashSet<Announcement> studentAnnouncement = new();
            foreach (var item in announcements)
            {
                if (item.Title.ToLower().Contains(keyword) || keyword.ToLower().Contains("duyuru"))
                    studentAnnouncement.Add(item);
            }

            return new SearchModel
            { 
                Lessons = studentLessons.ToPagedList(page, 5),
                Announcements = studentAnnouncement.ToPagedList(page, 5),
            };
        }

        public async Task<SearchModel> SearchTeacherAsync(string keyword, int page = 1)
        {
            var announcements = await _announcementDal.TeacherAnnouncementListAsync();
            HashSet<Announcement> teacherAnnouncement = new();
            foreach (var item in announcements)
            {
                if (item.Title.ToLower().Contains(keyword) || keyword.ToLower().Contains("duyuru"))
                    teacherAnnouncement.Add(item);
            }

            var lessons = await _lessonDal.GetAllTeacherLessonsAsync(); // Login olan ogretmenin verdigi dersler listeleniyor.
            HashSet<Lesson> teacherLessons = new();
            foreach (var item in lessons)
            {
                if (item.LessonName.ToLower().Contains(keyword) || keyword.ToLower().Contains("ders"))
                    teacherLessons.Add(item);
            }

            HashSet<Grade> teacherGrades = new(); // Login olan ogretmenin girdigi siniflarin tutulacagi liste. (HashSet yapisi tekrarsiz veri tutmasini saglayacak)
            foreach (var item in lessons)
            {
                var grade = await _gradeDal.GetGradeByIdAsync(item.GradeId); // Dersin ait oldugu sinifin id'sine gore o sinif entity'sini getir.
                if(item.Grade.Name.ToLower().Contains(keyword) || keyword.ToLower().Contains("sınıf"))
                    teacherGrades.Add(grade); // Map'lenen sinifi listeye ekle
            }

            var lessonScores = await _lessonScoreDal.GetListLoginTeacherLessonScore();
            HashSet<LessonScore> teacherLessonScores = new();
            foreach (var item in lessonScores)
            {
                if (keyword.ToLower().Contains("puan") || keyword.ToLower().Contains("not"))
                    teacherLessonScores.Add(item);
            }

            var users = await _userDal.GetAllUsersWithRoleAsync();
            var studentInClasses = await _userDal.StudentInClassListAsync(users); // Giren ogretmenin ders verdigi siniflarda bulunan ogrenciler listesi
            var mapStudents = _mapper.Map<List<AppUser>>(studentInClasses); 
            HashSet<AppUser> teacherStudents = new();
            foreach (var item in mapStudents)
            {
                if (item.Name.ToLower().Contains(keyword) || item.Surname.Contains(keyword) || keyword.ToLower().Contains("öğrenci"))
                    teacherStudents.Add(item);
            }

            return new SearchModel
            {
                Announcements = teacherAnnouncement.ToPagedList(page, 5),
                Grades = teacherGrades.ToPagedList(page, 5),
                Lessons = teacherLessons.ToPagedList(page, 5),
                LessonScores=teacherLessonScores.ToPagedList(page, 5),
                Users =teacherStudents.ToPagedList(page,5),
            };
        }
    }
}
