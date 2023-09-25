using PersianEden.Dtos.User;
using PersianEden.Infrastructure.Repositrories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersianEden.Entities;

namespace PersianEden.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddPersianUserAsync(PersianEdenUser entity)
        {
            await _dataContext.PersianEdenUsers.AddAsync(entity);
        }
        public async Task <UserDto>GetUserByEmailAsync(string Email)
        {
            return await (from s in _dataContext.PersianEdenUsers
                          where Email == s.Email
                          select new UserDto
                          {
                              Id = s.Id,
                              UserId = s.UserId,
                              Email=s.Email,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Gender = s.Gender,
                          }).AsNoTracking().FirstOrDefaultAsync();
                              
        }
    }
}
