﻿using EntityLayer.DTOs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers.Search
{
    public interface ISearchProcess
    {
        Task<SearchModel> SearchAsync(string keyword, int page = 1);
        Task<SearchModel> SearchTeacherAsync(string keyword, int page = 1);
        Task<SearchModel> SearchStudentAsync(string keyword, int page = 1);
    }
}
