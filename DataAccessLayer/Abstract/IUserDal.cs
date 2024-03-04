using EntityLayer.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal
    {
        Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto);
        Task<List<UserListDto>> GetAllUsersWithRoleAsync(); // Kullanicilari rolleriyle birlikte listeleme islemi
    }
}
