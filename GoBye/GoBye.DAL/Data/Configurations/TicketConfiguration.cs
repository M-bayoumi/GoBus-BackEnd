using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x =>x.Id);

            builder.Property(x => x.SeatNumber)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(x => x.Reservation)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.ReservationId)
                .IsRequired();

            builder.ToTable("Tickets");
        }
    }
}
