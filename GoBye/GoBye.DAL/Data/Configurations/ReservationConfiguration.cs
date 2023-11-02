using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.Quantity)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.Price)
               .HasColumnType("decimal")
               .IsRequired();

            builder.Property(x => x.TotalPrice)
               .HasColumnType("decimal")
               .IsRequired();

            builder.Property(x => x.Date)
               .HasColumnType("datetime")
               .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.Trip)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.TripId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.ToTable("Reservations");

            /*
            builder.HasData(new List<Reservation>
            {
                new Reservation
                {

                },
            });
            */
        }
    }
}
