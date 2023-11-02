using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class TermConfiguration : IEntityTypeConfiguration<Term>
    {
        public void Configure(EntityTypeBuilder<Term> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(x => x.SubTitle)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.ToTable("Terms");

            
            builder.HasData(new List<Term>
            {

                #region Terms
                new Term
                {
                    Id = 1,
                    Title="Online payment",
                    SubTitle="Booking Conditions",
                    Description="– No more than eight seats can be booked per trip," +
                    " making a total of 16 seats for the round trip." +
                    " If more seats are needed, please pay for the 16 tickets," +
                    " and then make another booking." +
                    "– The booked ticket can’t be modified through the website." +
                    " The booking through the website is the responsibility of the customer." +
                    "– The booked tickets paid by credit card can be canceled through the website before trip time by 4 hours," +
                    " for a fee of 10% of the ticket price approximated to the nearest 5 pounds." +
                    "– Children above six years must buy a full ticket. We don’t sell half tickets." +
                    "– Points are added every 24 hours with each reservation." +
                    "– Points are added to each seat."
                },
                new Term
                {
                    Id = 2,
                    Title="Fawry",
                    SubTitle="Booking Conditions",
                    Description="– Customers who book through Fawry have 3 hours to pay their tickets; otherwise," +
                    " the reservation will be canceled." +
                    "– No more than eight seats can be booked per trip," +
                    " making a total of 16 seats for the round trip. If more seats are needed," +
                    " please pay for the 16 tickets, and then make another booking." +
                    "– Payment has to be done before trip time by 2 hours." +
                    "– The original receipt has to be presented to the agent in any of our stations to receive the booked tickets." +
                    "– If the original receipt is lost, a copy of the national ID and order number has to be presented to receive tickets." +
                    "– Children above six years must buy a full ticket. We don’t sell half tickets." +
                    "– The round-trip discount is not applied to the GoMini trips." +
                    "– Points don’t be added to the account in the case of the Fawry reservation."
                },
                #endregion

            });
            
        }
    }
}
