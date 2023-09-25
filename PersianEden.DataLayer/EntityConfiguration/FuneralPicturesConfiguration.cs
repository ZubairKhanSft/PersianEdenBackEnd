using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersianEden.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.DataLayer.EntityConfiguration
{
    public class FuneralPicturesConfiguration : IEntityTypeConfiguration<FuneralPictures>
    {
        public void Configure(EntityTypeBuilder<FuneralPictures> builder)
        {
            builder.ToTable("FuneralPictures");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ImagePath).IsRequired();
            builder.Property(x => x.DeceasedId).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}
