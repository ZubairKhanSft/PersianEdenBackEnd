using PersianEden.Dtos.User;
using PersianEden.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.Infrastructure.Managers
{
    public interface IUserManager
    {
        Task<UserDto> CheckPersianUserEmailAsync(string Email);
        Task AddPersianUserAsync(UserAddModel model, string header);
        Task<UserDto> GetUserByEmailAsync(string Email);

    }
}
