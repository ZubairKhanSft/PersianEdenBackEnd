using PersianEden.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.Infrastructure.Managers
{
    public interface INameManager
    {
        Task AddName(NameModel model);
    }
}
