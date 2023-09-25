using PersianEden.Dtos.User;
using PersianEden.Factory;
using PersianEden.Infrastructure.DataLayer;
using PersianEden.Infrastructure.Managers;
using PersianEden.Infrastructure.Repositrories;
using PersianEden.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.Manager
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> CheckPersianUserEmailAsync(string Email)
        {
            return await _repository.GetUserByEmailAsync(Email);
        }

        public async Task AddPersianUserAsync(UserAddModel model, string header)
        {
            await _repository.AddPersianUserAsync(PersianUserFactory.Create(model, header));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserDto> GetUserByEmailAsync(string Email)
        {
            return await _repository.GetUserByEmailAsync(Email);
        }

    }
}
