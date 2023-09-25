using PersianEden.Dtos.Deceased;
using PersianEden.Dtos.HebrewMonths;
using PersianEden.Models.Deceased;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.Infrastructure.Managers
{
    public interface IDeceasedPersonManager
    {
        Task<int> AddAsync(AddDeceasedPersonModel model );
        Task<List<DeceasedPeopleDetailDto>> GetAllAsync();
        Task<List<HebrewMonthsDto>> GetAll_V1();
        Task AddFuneralVideo(AddDeceasedPersonModel multi);
        Task AddMemorialVideo(AddDeceasedPersonModel multi);
        Task AddFuneralImage(AddDeceasedPersonModel image);
        Task AddMemorialImage(AddDeceasedPersonModel image);
    }
}
