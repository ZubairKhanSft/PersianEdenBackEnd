using PersianEden.Dtos.Deceased;
using PersianEden.Entities;
using PersianEden.Infrastructure.Repositrories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersianEden.Dtos.HebrewMonths;

namespace PersianEden.DataLayer.Repositories
{
    public class DeceasedPersonRepository : IDeceasedPersonRepository
    {
        public readonly DataContext _dataContext;

        public DeceasedPersonRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task<DeceasedPerson> AddAsync(DeceasedPerson entity)
        {
           await _dataContext.DeceasedPerson.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
        public async Task AddFuneralVideo(FuneralVideo entity)
        {
            await _dataContext.FuneralVideo.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

        }
        public async Task AddFuneralImage(FuneralPictures entity)
        {
            await _dataContext.FuneralPictures.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

        }

        public async Task AddMemorialVideo(MemorialVideo entity)
        {
            await _dataContext.MemorialVideo.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

        }

        public async Task AddMemorialImage(MemorialPictures entity)
        {
            await _dataContext.MemorialPictures.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

        }
        public async Task<List<DeceasedPeopleDetailDto>> GetAllAsync()
        {
            return await( from s in _dataContext.DeceasedPerson
                          where s.CreatedOn.Year.ToString() == DateTime.Now.Year.ToString()
                          select new DeceasedPeopleDetailDto 
                          { 
                              Id = s.Id,
                             /* Name = s.Name,
                              FamilyName = s.FamilyName,
                              CompanyName = s.CompanyName,
                              Address = s.Address,
                              Email = s.Email,
                              RelationToDeceased = s.RelationToDeceased,
                              LandLineNumber = s.LandLineNumber,
                              MobileNumber = s.MobileNumber,*/
                              
                              Deceased_Name_English = s.Deceased_Name_English,
                              Deceased_Name_Hebrew = s.Deceased_Name_Hebrew,
                              Deceased_Name_Persian = s.Deceased_Name_Persian,
                              
                              Deceased_FatherName_English = s.Deceased_FatherName_English,
                              Deceased_FatherName_Hebrew = s.Deceased_FatherName_Hebrew,
                              Deceased_FatherName_Persian = s.Deceased_FatherName_Persian,
                              
                              Deceased_MotherName_Engish = s.Deceased_MotherName_Engish,
                              Deceased_MotherName_Hebrew = s.Deceased_MotherName_Hebrew,
                              Deceased_MotherName_Persian = s.Deceased_MotherName_Persian,
                              
                              DemiseDate_Gregorian = s.DemiseDate_Gregorian,
                              DemiseDate_Hebrew = s.DemiseDate_Hebrew,
                              DemiseDate_Iranian = s.DemiseDate_Iranian,
                              Month_DemiseDate_Hebrew = s.Month_DemiseDate_Hebrew,
                              Year_DemiseDate_English = s.Year_DemiseDate_English,
                              
                              CityOfDemise = s.CityOfDemise,
                              StateOfDemise = s.StateOfDemise,
                              CountryOfDemise = s.CountryOfDemise,
                              
                              CemetryName = s.CemetryName,
                              CemetryAddress = s.CemetryAddress,
                              
                              Gravelat = s.Gravelat,
                              Gravelng = s.Gravelng,
                              
                              Biography_English = s.Biography_English,
                              Biography_Hebrew = s.Biography_Hebrew,
                              Biography_Persian = s.Biography_Persian,
                              
                              Date_Of_Funeral_Gregorian = s.Date_Of_Funeral_Gregorian,
                              Date_Of_Funeral_Hebrew = s.Date_Of_Funeral_Hebrew,
                              Date_Of_Funeral_Iranian = s.Date_Of_Funeral_Iranian,
                              
                              Date_Of_Memorial_Gregorian = s.Date_Of_Memorial_Gregorian,
                              Date_Of_Memorial_Hebrew = s.Date_Of_Memorial_Hebrew,
                              Date_Of_Memorial_Iranian = s.Date_Of_Memorial_Iranian,
                              
                              Location_Of_Memorial = s.Location_Of_Memorial,
                              DeceasedReligion = s.DeceasedReligion,
                              CreatedOn = s.CreatedOn,
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<List<FuneralImageDto>> GetFuneralImages(int id)
        {
            return await (from s in _dataContext.FuneralPictures
                          where s.DeceasedId == id
                          select new FuneralImageDto
                          {
                              Id = s.Id,
                              DeceasedId = s.DeceasedId,
                              ImagePath = s.ImagePath,
                              CreatedOn = s.CreatedOn
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<List<HebrewMonthsDto>> GetHebrewMonths()
        {
            return await (from s in _dataContext.HebrewMonths
                          select new HebrewMonthsDto
                          {
                              Id = s.id,
                              HebrewMonthsName = s.MonthName
                          }).AsNoTracking().ToListAsync();
        }
        public async Task<List<DeceasedPeopleDetailDto>> DeceasedWithMonth(string month)
        {
            return await (from s in _dataContext.DeceasedPerson
                          where s.Month_DemiseDate_Hebrew == month
                          select new DeceasedPeopleDetailDto
                          {
                              Id = s.Id,


                              Deceased_Name_English = s.Deceased_Name_English,
                              Deceased_Name_Hebrew = s.Deceased_Name_Hebrew,
                              Deceased_Name_Persian = s.Deceased_Name_Persian,

                              Deceased_FatherName_English = s.Deceased_FatherName_English,
                              Deceased_FatherName_Hebrew = s.Deceased_FatherName_Hebrew,
                              Deceased_FatherName_Persian = s.Deceased_FatherName_Persian,

                              Deceased_MotherName_Engish = s.Deceased_MotherName_Engish,
                              Deceased_MotherName_Hebrew = s.Deceased_MotherName_Hebrew,
                              Deceased_MotherName_Persian = s.Deceased_MotherName_Persian,

                              DemiseDate_Gregorian = s.DemiseDate_Gregorian,
                              DemiseDate_Hebrew = s.DemiseDate_Hebrew,
                              DemiseDate_Iranian = s.DemiseDate_Iranian,
                              Month_DemiseDate_Hebrew = s.Month_DemiseDate_Hebrew,
                              Year_DemiseDate_English = s.Year_DemiseDate_English,

                              CityOfDemise = s.CityOfDemise,
                              StateOfDemise = s.StateOfDemise,
                              CountryOfDemise = s.CountryOfDemise,

                              CemetryName = s.CemetryName,
                              CemetryAddress = s.CemetryAddress,

                              Gravelat = s.Gravelat,
                              Gravelng = s.Gravelng,

                              Biography_English = s.Biography_English,
                              Biography_Hebrew = s.Biography_Hebrew,
                              Biography_Persian = s.Biography_Persian,

                              Date_Of_Funeral_Gregorian = s.Date_Of_Funeral_Gregorian,
                              Date_Of_Funeral_Hebrew = s.Date_Of_Funeral_Hebrew,
                              Date_Of_Funeral_Iranian = s.Date_Of_Funeral_Iranian,

                              Date_Of_Memorial_Gregorian = s.Date_Of_Memorial_Gregorian,
                              Date_Of_Memorial_Hebrew = s.Date_Of_Memorial_Hebrew,
                              Date_Of_Memorial_Iranian = s.Date_Of_Memorial_Iranian,

                              Location_Of_Memorial = s.Location_Of_Memorial,
                              DeceasedReligion = s.DeceasedReligion,

                          }).AsNoTracking().ToListAsync();
        }
        public async Task<List<FuneralVideoDto>> GetFuneralVideos(int id)
        {
            return await (from s in _dataContext.FuneralVideo
                          where s.DeceasedId == id
                          select new FuneralVideoDto
                          {
                              Id = s.Id,
                              DeceasedId = s.DeceasedId,
                              VideoPath = s.VideoPath,
                              CreatedOn = s.CreatedOn
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<List<MemorialImageDto>> GetMemorialImages(int id)
        {
            return await (from s in _dataContext.MemorialPictures
                          where s.DeceasedId == id
                          select new MemorialImageDto
                          {
                              Id = s.Id,
                              DeceasedId = s.DeceasedId,
                              ImagePath = s.ImagePath,
                              CreatedOn = s.CreatedOn
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<List<MemorialVideoDto>> GetMemorialVideos(int id)
        {
            return await (from s in _dataContext.MemorialVideo
                          where s.DeceasedId == id
                          select new MemorialVideoDto
                          {
                              Id = s.Id,
                              DeceasedId = s.DeceasedId,
                              VideoPath = s.VideoPath,
                              CreatedOn = s.CreatedOn
                          }).AsNoTracking().ToListAsync();
        }
    }
}
