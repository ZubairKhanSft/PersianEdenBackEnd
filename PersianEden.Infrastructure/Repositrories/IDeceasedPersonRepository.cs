using PersianEden.Dtos.Deceased;
using PersianEden.Dtos.HebrewMonths;
using PersianEden.Entities;
using PersianEden.Models.Deceased;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.Infrastructure.Repositrories
{
    public interface IDeceasedPersonRepository
    {
        Task<DeceasedPerson> AddAsync(DeceasedPerson entity );
        Task AddFuneralVideo(FuneralVideo entity);
        Task AddFuneralImage(FuneralPictures entity);
        Task<List<FuneralImageDto>> GetFuneralImages(int id);
        Task<List<FuneralVideoDto>> GetFuneralVideos(int id);
        Task<List<MemorialImageDto>> GetMemorialImages(int id);
        Task<List<MemorialVideoDto>> GetMemorialVideos(int id);
        Task AddMemorialVideo(MemorialVideo entity);
        Task AddMemorialImage(MemorialPictures entity);
        Task<List<DeceasedPeopleDetailDto>> GetAllAsync();
        Task<List<DeceasedPeopleDetailDto>> DeceasedWithMonth(string month);
        Task<List<HebrewMonthsDto>> GetHebrewMonths();
    }
}
