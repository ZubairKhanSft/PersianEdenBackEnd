using PersianEden.Entities;
using PersianEden.Infrastructure.Repositrories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.DataLayer.Repositories
{
    public class NameRepository:INameRepository
    {
        private readonly DataContext _dataContext;
        public NameRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddName(Name entity)
        {
            await _dataContext.Names.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
