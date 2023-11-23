using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class ClassImageConfiguration : IEntityTypeConfiguration<ClassImage>
    {
        public void Configure(EntityTypeBuilder<ClassImage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ImageURL)
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder.HasOne(x => x.BusClass)
                .WithMany(x => x.ClassImages)
                .HasForeignKey(x => x.BusClassId)
                .IsRequired();

            builder.ToTable("ClassImages");

            
            builder.HasData(new List<ClassImage>
            {
                #region Super Go D Images
                new ClassImage
                {
                    Id = 1,
                    BusClassId =1,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/deluxe-plus/4.png",
                },
                new ClassImage
                {
                    Id = 2,
                    BusClassId =1,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/deluxe-plus/3.jpg",
                },
                new ClassImage
                {
                    Id = 3,
                    BusClassId =1,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/deluxe-plus/2.jpg",
                },
                #endregion

                #region Business Class DD Images
                new ClassImage
                {
                    Id = 4,
                    BusClassId =2,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/elite-DD/4.png",
                },
                new ClassImage
                {
                    Id = 5,
                    BusClassId =2,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/elite-DD/3.jpg",
                },
                new ClassImage
                {
                    Id = 6,
                    BusClassId =2,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/elite-DD/2.jpg",
                },
                #endregion

                #region Elite Business Class M Images
                new ClassImage
                {
                    Id = 7,
                    BusClassId =3,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/elite-plus/4.png",
                },
                new ClassImage
                {
                    Id = 8,
                    BusClassId =3,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/elite-plus/3.jpg",
                },
                new ClassImage
                {
                    Id = 9,
                    BusClassId =3,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/elite-plus/2.jpg",
                },
                #endregion

                #region New Deluxe Images
                new ClassImage
                {
                    Id = 10,
                    BusClassId =4,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/new-deluxe/4.png",
                },
                new ClassImage
                {
                    Id = 11,
                    BusClassId =4,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/new-deluxe/3.jpg",
                },
                new ClassImage
                {
                    Id = 12,
                    BusClassId =4,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/new-deluxe/2.jpg",
                },
                #endregion

                #region Economy Images
                new ClassImage
                {
                    Id = 13,
                    BusClassId =5,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/economic/4.png",
                },
                new ClassImage
                {
                    Id = 14,
                    BusClassId =5,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/economic/3.jpg",
                },
                new ClassImage
                {
                    Id = 15,
                    BusClassId =5,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/economic/2.jpg",
                },
                #endregion

                #region Elite Business Class V Images
                new ClassImage
                {
                    Id = 16,
                    BusClassId =6,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/elite-plus-plus/4.png",
                },
                new ClassImage
                {
                    Id = 17,
                    BusClassId =6,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/elite-plus-plus/3.jpg",
                },
                new ClassImage
                {
                    Id = 18,
                    BusClassId =6,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/elite-plus-plus/2.jpg",
                },
                #endregion

                #region Aero First Class Images
                new ClassImage
                {
                    Id = 19,
                    BusClassId =7,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/aero-class/4.png",
                },
                new ClassImage
                {
                    Id = 20,
                    BusClassId =7,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/aero-class/3.jpg",
                },
                new ClassImage
                {
                    Id = 21,
                    BusClassId =7,
                    ImageURL = "https://go-bus.com/images/new-bus-classes/aero-class/2.jpg",
                },
                #endregion
                
            });
            
            
        }
    }
}
