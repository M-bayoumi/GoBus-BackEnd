using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(x => x.ImageURL)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.HasMany(x => x.StartBranchs)
                .WithOne(x => x.Destination)
                .HasForeignKey(x => x.DestinationId)
                .IsRequired();

            builder.HasMany(x => x.EndBranchs)
                .WithOne(x => x.Destination)
                .HasForeignKey(x => x.DestinationId)
                .IsRequired();

            builder.ToTable("Destinations");

            
            builder.HasData(new List<Destination>
            {

                #region Destinations
                new Destination
                {
                    Id=1,
                    Name="Cairo",
                    ImageURL = "https://lp-cms-production.imgix.net/news/2019/02/Cairo-market.jpg"
                },

                new Destination
                {
                    Id=2,
                    Name="Red Sea",
                    ImageURL = "https://go-bus.com:8181/wp-content/uploads/2019/04/Sharm-hero.jpg"
                },

                new Destination
                {
                    Id=3,
                    Name="South Sinai",
                    ImageURL = "https://go-bus.com:8181/wp-content/uploads/2019/04/sokhna-hero-1.jpg"
                },

                new Destination
                {
                    Id=4,
                    Name="Alexandria",
                    ImageURL = "https://go-bus.com:8181/wp-content/uploads/2018/05/Alex-hero.jpg"
                },

                new Destination
                {
                    Id=5,
                    Name="North Coast",
                    ImageURL = "https://www.carolsbeaurivage.com/medias/slide/big/5/img-9257.jpg"
                },

                new Destination
                {
                    Id=6,
                    Name="Suez",
                    ImageURL = "https://planetofhotels.com/guide/sites/default/files/styles/paragraph__live_banner__lb_image__1880bp/public/live_banner/Suez.jpg"
                },

                new Destination
                {
                    Id=7,
                    Name="Qena",
                    ImageURL = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/7d/c0/f6/qena.jpg?w=500&h=300&s=1"
                },

                new Destination
                {
                    Id=8,
                    Name="Gharbia",
                    ImageURL = "https://media.odyfolio.com/pho/145/uae-uae-al-gharbia-liwa-desert-qasr-al-sarab-hotel_m-1-169.jpeg"
                },

                new Destination
                {
                    Id=9,
                    Name="Port Said",
                    ImageURL = "https://cdn.britannica.com/10/126710-050-8E814ED9/building-Suez-Canal-Authority-Port-Said-Egypt.jpg"
                },

                new Destination
                {
                    Id=10,
                    Name="Assiut",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/commons/4/4d/AsyutUniversityMainBldg.jpg"
                },

                new Destination
                {
                    Id=11,
                    Name="Menia",
                    ImageURL = "https://facts.net/wp-content/uploads/2023/07/40-facts-about-menia-1689735034.jpeg"
                },

                new Destination
                {
                    Id=12,
                    Name="Luxor",
                    ImageURL = "https://www.introducingegypt.com/f/egipto/egipto/guia/luxor-m.jpg"
                },

                new Destination
                {
                    Id=13,
                    Name="Dakahlia",
                    ImageURL = "https://t3.ftcdn.net/jpg/03/63/61/66/360_F_363616600_zenx3HVCXEVDAYhBYhYglFYU9xTRYKMO.jpg"
                },

                new Destination
                {
                    Id=14,
                    Name="Ismailia",
                    ImageURL = "https://mercure.accor.com/local-stories/media/ismailia_desk.jpg"
                },
                #endregion

            });
            
        }
    }
}
