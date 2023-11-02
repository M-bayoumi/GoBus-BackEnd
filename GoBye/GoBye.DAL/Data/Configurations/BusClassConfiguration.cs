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
                    Name="Super Go D"
                },
                new BusClass
                {
                    Id = 2,
                    Name="Business Class DD"
                },
                new BusClass
                {
                    Id = 3,
                    Name="Elite Business Class M"
                },
                new BusClass
                {
                    Id = 4,
                    Name="GoMini"
                },
                new BusClass
                {
                    Id = 5,
                    Name="New Deluxe"
                },
                new BusClass
                {
                    Id = 6,
                    Name="Economy"
                },
                new BusClass
                {
                    Id = 7,
                    Name="Elite Business Class V"
                },
                new BusClass
                {
                    Id = 8,
                    Name="Aero First Class"
                },
                #endregion

            });
            
        }
    }
}
