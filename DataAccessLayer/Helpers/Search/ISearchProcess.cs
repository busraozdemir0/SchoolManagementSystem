using EntityLayer.DTOs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers.Search
{
    public interface ISearchProcess
    {
        Task<SearchModel> SearchAsync(string keyword);
    }
}
