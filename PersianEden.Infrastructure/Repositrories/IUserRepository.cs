using PersianEden.Dtos.User;
using PersianEden.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.Infrastructure.Repositrories
{
    public interface IUserRepository
    {
        Task <UserDto>GetUserByEmailAsync(string Email);
        Task AddPersianUserAsync(PersianEdenUser entity);
    }
}
