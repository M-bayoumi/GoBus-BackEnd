using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ReservationNumber)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.Message)
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.ToTable("Reports");

            /*
            public int ReservationNumber { get; set; }
            public string Message { get; set; } = string.Empty;
            public string UserId { get; set; } = string.Empty;
            */

            /*
            builder.HasData(new List<Report>
            {
                new Report
                {

                },
            });
            */
            
        }
    }
}
