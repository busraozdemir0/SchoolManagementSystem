using EntityLayer.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IUserService
    {
        Task<IdentityResult> TCreateUserAsync(UserAddDto userAddDto);
        Task<List<UserListDto>> TGetAllUsersWithRoleAsync();
    }
}
