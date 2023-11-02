using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AvailableSeats)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.DepartureDate)
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(x => x.ArrivalDate)
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(x => x.Price)
               .HasColumnType("decimal")
               .IsRequired();

            builder.HasOne(x => x.StartBranch)
                .WithMany(x => x.Trips)
                .HasForeignKey(x => x.StartBranchId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.EndBranch)
                .WithMany(x => x.Trips)
                .HasForeignKey(x => x.EndBranchId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.ToTable("Trips");

            /*
            public DateTime DepartureDate { get; set; }
            public DateTime ArrivalDate { get; set; }
            public decimal Price { get; set; }
            public int BusId { get; set; }
            public int StartBranchId { get; set; }
            public int EndBranchId { get; set; }
            */

            /*
            var now = DateTime.Now;
            builder.HasData(new List<Trip>
            {
                new Trip
                {
                    Id = 1,
                    DepartureDate = DateTime.Now.AddDays(1).AddHours(0),
                    ArrivalDate = DateTime.Now.AddDays(1).AddHours(0),
                    Price = 300,
                    BusId = 1,
                    StartBranchId = 1,
                    EndBranchId = 14
                },
            });
            
            */
        }
    }
}
