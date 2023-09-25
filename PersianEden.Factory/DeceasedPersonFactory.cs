using PersianEden.Entities;
using PersianEden.Models.Deceased;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.Factory
{
    public class DeceasedPersonFactory
    {
        public static DeceasedPerson Create(AddDeceasedPersonModel model)
        {
            var data = new DeceasedPerson
            {
                /*Name = model.Name,
                FamilyName = model.FamilyName,
                CompanyName = model.CompanyName,
                Address = model.Address,
                Email = model.Email,
                RelationToDeceased = model.RelationToDeceased,
                LandLineNumber = model.LandLineNumber,
                MobileNumber = model.MobileNumber,*/
                
                Deceased_Name_English = model.Deceased_Name_English,
                Deceased_Name_Persian = model.Deceased_Name_Persian,
                Deceased_Name_Hebrew = model.Deceased_Name_Hebrew,
               
                Deceased_FatherName_English = model.Deceased_FatherName_English,
                Deceased_FatherName_Persian = model.Deceased_FatherName_Persian,
                Deceased_FatherName_Hebrew = model.Date_Of_Funeral_Hebrew,
               
                Deceased_MotherName_Engish = model.Deceased_MotherName_Engish,
                Deceased_MotherName_Hebrew = model.Deceased_MotherName_Hebrew,
                Deceased_MotherName_Persian = model.Deceased_MotherName_Persian,

                DemiseDate_Gregorian = model.DemiseDate_Gregorian,
                DemiseDate_Hebrew = model.DemiseDate_Hebrew,
                DemiseDate_Iranian = model.DemiseDate_Iranian,
                Year_DemiseDate_English = model.Year_DemiseDate_English,
                Month_DemiseDate_Hebrew = model.Month_DemiseDate_Hebrew,
                
                CityOfDemise = model.CityOfDemise,
                StateOfDemise = model.StateOfDemise,
                CountryOfDemise = model.CountryOfDemise,

                CemetryName = model.CemetryName,
                CemetryAddress = model.CemetryAddress,

                Gravelat = model.Gravelat,
                Gravelng = model.Gravelng,

                Biography_English = model.Biography_English,
                Biography_Hebrew = model.Biography_Hebrew,
                Biography_Persian = model.Biography_Persian,

                Date_Of_Funeral_Gregorian = model.Date_Of_Funeral_Gregorian,
                Date_Of_Funeral_Hebrew = model.Date_Of_Funeral_Hebrew,
                Date_Of_Funeral_Iranian = model.Date_Of_Funeral_Iranian,

                Date_Of_Memorial_Gregorian = model.Date_Of_Memorial_Gregorian,
                Date_Of_Memorial_Hebrew = model.Date_Of_Memorial_Hebrew,
                Date_Of_Memorial_Iranian = model.Date_Of_Memorial_Iranian,

                Location_Of_Memorial = model.Location_Of_Memorial,
                DeceasedReligion = model.DeceasedReligion,
                CreatedOn = DateTime.Now
            };
            return data;
        }
        public static FuneralVideo CreateFuneralVideo(AddDeceasedPersonModel multi)
        {
            var data = new FuneralVideo {
                DeceasedId = multi.Id,
                VideoPath = multi.FileUrl,
                CreatedOn = DateTime.Now
            };
            return data;
        }
        public static FuneralPictures CreateFuneralImage(AddDeceasedPersonModel multi)
        {
            var data = new FuneralPictures
            {
                DeceasedId = multi.Id,
                ImagePath = multi.FileUrl,
                CreatedOn = DateTime.Now
            };
            return data;
        }
        public static MemorialPictures CreateMemorialImage(AddDeceasedPersonModel multi)
        {
            var data = new MemorialPictures
            {
                DeceasedId = multi.Id,
                ImagePath = multi.FileUrl,
                CreatedOn = DateTime.Now
            };
            return data;
        }
        public static MemorialVideo CreateMemorialVideo(AddDeceasedPersonModel multi)
        {
            var data = new MemorialVideo
            {
                DeceasedId = multi.Id,
                VideoPath = multi.FileUrl,
                CreatedOn = DateTime.Now
            };
            return data;
        }
    }
}
