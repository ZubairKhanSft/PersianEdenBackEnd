using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersianEden.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.DataLayer.EntityConfiguration
{
    public class MemorialPicturesConfiguration : IEntityTypeConfiguration<MemorialPictures>
    {
        public void Configure(EntityTypeBuilder<MemorialPictures> builder)
        {
            builder.ToTable("MemorialPictures");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ImagePath).IsRequired();
            builder.Property(x => x.DeceasedId).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}
