﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Users
{
    public class UserAddDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public List<AppRole> Roles { get; set; } // Kullanici eklerken rolunu secebilmek icin
        public int? GradeId { get; set; }
        public List<Grade> Grades { get; set; } // Ogrenci eklerken sinifini secebilmek icin

    }
}
