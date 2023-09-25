using PersianEden.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.Infrastructure.Repositrories
{
    public interface INameRepository
    {
        Task AddName(Name entity);
    }
}
