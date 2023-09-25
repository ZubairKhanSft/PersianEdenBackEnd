using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersianEden.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.DataLayer.EntityConfiguration
{
    public class DeceasedPersonConfiguration : IEntityTypeConfiguration<DeceasedPerson>
    {
        public void Configure(EntityTypeBuilder<DeceasedPerson> builder)
        {
            builder.ToTable("DeceasedPerson");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

           /* builder.Property(x => 
            * 
            * x.Name).IsRequired(false);
            builder.Property(x => x.FamilyName).IsRequired(false);
            builder.Property(x => x.CompanyName).IsRequired(false);
            builder.Property(x => x.Email).IsRequired(false);
            builder.Property(x => x.Address).IsRequired(false);
            builder.Property(x => x.LandLineNumber).IsRequired(false);
            builder.Property(x => x.MobileNumber).IsRequired(false);
            builder.Property(x => x.RelationToDeceased).IsRequired(false);*/

            builder.Property(x => x.Deceased_Name_English).IsRequired(false);
            builder.Property(x => x.Deceased_Name_Persian).IsRequired(false);
            builder.Property(x => x.Deceased_Name_Hebrew).IsRequired(false);

            builder.Property(x => x.Deceased_FatherName_English).IsRequired(false);
            builder.Property(x => x.Deceased_FatherName_Hebrew).IsRequired(false);
            builder.Property(x => x.Deceased_FatherName_Persian).IsRequired(false);

            builder.Property(x => x.Deceased_MotherName_Engish).IsRequired(false);
            builder.Property(x => x.Deceased_MotherName_Hebrew).IsRequired(false);
            builder.Property(x => x.Deceased_MotherName_Persian).IsRequired(false);


            builder.Property(x => x.DemiseDate_Gregorian).IsRequired(false);
            builder.Property(x => x.DemiseDate_Hebrew).IsRequired(false);
            builder.Property(x => x.DemiseDate_Iranian).IsRequired(false);
            builder.Property(x => x.Month_DemiseDate_Hebrew).IsRequired(false);
            builder.Property(x => x.Year_DemiseDate_English).IsRequired(false);

            builder.Property(x => x.CityOfDemise).IsRequired(false);
            builder.Property(x => x.StateOfDemise).IsRequired(false);
            builder.Property(x => x.CountryOfDemise).IsRequired(false);

            builder.Property(x => x.Gravelat).IsRequired(false);
            builder.Property(x => x.Gravelng).IsRequired(false);

            builder.Property(x => x.Biography_English).IsRequired(false);
            builder.Property(x => x.Biography_Hebrew).IsRequired(false);
            builder.Property(x => x.Biography_Persian).IsRequired(false);

            builder.Property(x => x.Date_Of_Funeral_Gregorian).IsRequired(false);
            builder.Property(x => x.Date_Of_Funeral_Hebrew).IsRequired(false);
            builder.Property(x => x.Date_Of_Funeral_Iranian).IsRequired(false);

            builder.Property(x => x.Date_Of_Memorial_Gregorian).IsRequired(false);
            builder.Property(x => x.Date_Of_Memorial_Hebrew).IsRequired(false);
            builder.Property(x => x.Date_Of_Memorial_Iranian).IsRequired(false);

            builder.Property(x => x.Location_Of_Memorial).IsRequired(false);
            builder.Property(x => x.DeceasedReligion).IsRequired(false);


            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.UpdatedOn).IsRequired(false);
        }
    }
}
