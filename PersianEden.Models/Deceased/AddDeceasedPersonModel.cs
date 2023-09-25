using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.Models.Deceased
{
    public class AddDeceasedPersonModel
    {
        #region Relative detail
        public int Id { get; set; }
       /* public string Name { get; set; }
        public string FamilyName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string RelationToDeceased { get; set; }
        public int? LandLineNumber { get; set; }
        public int? MobileNumber { get; set; }*/

        #endregion
        public string Deceased_Name_English { get; set; }
        public string Deceased_Name_Persian { get; set; }
        public string Deceased_Name_Hebrew { get; set; }
        
        public string Deceased_FatherName_English { get; set; }
        public string Deceased_FatherName_Persian { get; set; }
        public string Deceased_FatherName_Hebrew { get; set; }
       
        public string Deceased_MotherName_Engish { get; set; }
        public string Deceased_MotherName_Persian { get; set; }
        public string Deceased_MotherName_Hebrew { get; set; }

        public DateTime? DemiseDate_Gregorian { get; set; }
        public string DemiseDate_Iranian { get; set; }
        public string DemiseDate_Hebrew { get; set; }
        public string Month_DemiseDate_Hebrew { get; set; }
        public string Year_DemiseDate_English { get; set; }

        public string CityOfDemise { get; set; }
        public string StateOfDemise { get; set; }
        public string CountryOfDemise { get; set; }
        
        public string CemetryName { get; set; }
        public string CemetryAddress { get; set; }
       
        public double? Gravelat { get; set; }
        public double? Gravelng { get; set; }
       
        public string Biography_English { get; set; }
        public string Biography_Persian { get; set; }
        public string Biography_Hebrew { get; set; }
       
        public DateTime? Date_Of_Funeral_Gregorian { get; set; }
        public string Date_Of_Funeral_Iranian { get; set; }
        public string Date_Of_Funeral_Hebrew { get; set; }
       
        public DateTime? Date_Of_Memorial_Gregorian { get; set; }
        public string Date_Of_Memorial_Iranian { get; set; }
        public string Date_Of_Memorial_Hebrew { get; set; }
       
        public string Location_Of_Memorial { get; set; }
        public string DeceasedReligion { get; set; }
       
        public List<string> FuneralVideo { get; set; }
        public List<string> MemorialVideo { get; set; }
        public List<string> FuneralImage { get; set; }
        public List<string> MemorialImage { get; set; }
        public string FileUrl { get; set; }
    }
}
