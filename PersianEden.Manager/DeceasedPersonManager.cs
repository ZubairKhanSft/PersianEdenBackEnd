using PersianEden.Dtos.Deceased;
using PersianEden.Dtos.HebrewMonths;
using PersianEden.Factory;
using PersianEden.Infrastructure.Managers;
using PersianEden.Infrastructure.Repositrories;
using PersianEden.Models.Deceased;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden.Manager
{
    public class DeceasedPersonManager : IDeceasedPersonManager
    {
        public readonly IDeceasedPersonRepository _repository;
        public DeceasedPersonManager(IDeceasedPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(AddDeceasedPersonModel model)
        {
           var data = await _repository.AddAsync(DeceasedPersonFactory.Create(model));
            return data.Id;
        }
        public async Task AddFuneralVideo(AddDeceasedPersonModel multi)
        {
           await _repository.AddFuneralVideo(DeceasedPersonFactory.CreateFuneralVideo(multi));
           
        }
        public async Task AddMemorialVideo(AddDeceasedPersonModel multi)
        {
            await _repository.AddMemorialVideo(DeceasedPersonFactory.CreateMemorialVideo(multi));

        }
        public async Task AddMemorialImage(AddDeceasedPersonModel multi)
        {
            await _repository.AddMemorialImage(DeceasedPersonFactory.CreateMemorialImage(multi));

        }
        public async Task AddFuneralImage(AddDeceasedPersonModel multi)
        {
            await _repository.AddFuneralImage(DeceasedPersonFactory.CreateFuneralImage(multi));
            
        }
        public async Task<List<DeceasedPeopleDetailDto>> GetAllAsync()
        {
             var data = await _repository.GetAllAsync();
            foreach (var item in data)
            {
                item.FuneralImages = await _repository.GetFuneralImages(item.Id);
                item.FuneralVideos = await _repository.GetFuneralVideos(item.Id);
                item.MemorialImages = await _repository.GetMemorialImages(item.Id);
                item.MemorialVideos = await _repository.GetMemorialVideos(item.Id);
            }
            return data;
        }

        public async Task<List<HebrewMonthsDto>> GetAll_V1()
        {
            var data = await _repository.GetHebrewMonths();
           

            foreach (var item in data)
            {
                item.DeceasedPeople = await _repository.DeceasedWithMonth(item.HebrewMonthsName);
            }
            return data;
        }
    }
}
