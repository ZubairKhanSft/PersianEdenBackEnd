using PersianEden.Factory;
using PersianEden.Infrastructure.Managers;
using PersianEden.Infrastructure.Repositrories;
using PersianEden.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.Manager
{
    public class NameManager: INameManager
    {
        private readonly INameRepository _repository;
        public NameManager(INameRepository repository)
        {
            _repository = repository;
        }

        public async Task AddName(NameModel model)
        {
            await _repository.AddName(NameFactory.Create(model));
        }
    }
}
