using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class BusClassConfiguration : IEntityTypeConfiguration<BusClass>
    {
        public void Configure(EntityTypeBuilder<BusClass> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
               .HasColumnType("varchar(max)")
               .IsRequired();

            

            builder.ToTable("BusClasses");


            
            builder.HasData(new List<BusClass>
            {

                #region BusClasses
                new BusClass
                {
                    Id = 1,
                    Name="Super Go D",
                    AveragePrice = "180 EGP - 265 EGP",
                },
                new BusClass
                {
                    Id = 2,
                    Name="Business Class DD",
                    AveragePrice = "165 EGP - 445 EGP",

                },
                new BusClass
                {
                    Id = 3,
                    Name="Elite Business Class M",
                    AveragePrice = "385 EGP - 385 EGP",

                },
                new BusClass
                {
                    Id = 4,
                    Name="New Deluxe",
                    AveragePrice = "225 EGP - 265 EGP",

                },
                new BusClass
                {
                    Id = 5,
                    Name="Economy",
                    AveragePrice = "100 EGP - 180 EGP",

                },
                new BusClass
                {
                    Id = 6,
                    Name="Elite Business Class V",
                    AveragePrice = "130 EGP - 440 EGP",

                },
                new BusClass
                {
                    Id = 7,
                    Name="Aero First Class",
                    AveragePrice = "500 EGP - 545 EGP",

                },
                #endregion

            });
            
        }
    }
}
