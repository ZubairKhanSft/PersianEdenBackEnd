using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.Infrastructure.DataLayer
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        Task BeginTransactionAsync();

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void Commit();

        void Rollback();

        Task<int> ExecuteSqlCommandAsync(string sqlCommand, params object[] parameters);

    }
}
