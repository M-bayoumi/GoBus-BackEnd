using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
               .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(x => x.Answer)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.ToTable("Questions");

            
            builder.HasData(new List<Question>
            {

                #region Questions
                new Question
                {
                    Id = 1,
                    Title="I didn’t receive my mTicket. Can you re-send it?",
                    Answer="The system automatically resends the e-ticket that has not been successfully delivered to the client." +
                    " E-tickets can also be found in “my tickets” tab once you are logged on to your account."
                },

                new Question
                {
                    Id = 2,
                    Title="Does the company stipulate a maximum speed for divers?",
                    Answer="Go Bus abides by safety protocols and security standards," +
                    " under the auspices of the Ministry of Transportation." +
                    " We depend on a modern fleet of buses, whose speed is electronically controlled by the agency without drivers’ intervention" +
                    ". We have a whole staff of highly-trained drivers to maintain these protocols and standards."
                },

                new Question
                {
                    Id = 3,
                    Title="Do I need to register to use Go Bus?",
                    Answer="You can easily browse the different trip times and dates," +
                    " however, in order to book a ticket, you need to be registered with Go Bus."
                },

                new Question
                {
                    Id = 4,
                    Title="What are Go Bus driver skill enhancement program and customer safety and satisfaction strategy?",
                    Answer="Go Bus is keen on its staff skills and capacity development." +
                    " The company always seeks to enhance the skills of drivers and employees." +
                    " Therefore, we have recently inked a protocol with the Egyptian Road Safety Training Centre to train 80% of our drivers," +
                    " which is a testament of our vision to develop drivers’ skills and ensure our customers’ safety and satisfaction."
                },

                new Question
                {
                    Id = 5,
                    Title="Earlier you announced that Go Bus owns a central control room, what is its value for the company?",
                    Answer="Go Bus’s strategy considering the customer on the top of our priorities and our endeavor" +
                    " towards offering high-quality services are manifested in the difference Go Bus continues to make in Egypt’s" +
                    " transportation system in general through its peerless control room, which monitors its fleet across Egypt 24/7." +
                    " The purpose of this room is to offer real-time monitoring system for drivers and passengers’ safety," +
                    " and records drivers’ traffic offences, ensuring rapid crisis response and management."
                },

                new Question
                {
                    Id = 6,
                    Title="I entered the wrong mobile number while booking. Can I get my mTicket on a different number?",
                    Answer="Once you have entered your mobile number while booking it can’t be changed for that particular transaction." +
                    " You can however, go back and change your mobile number for further transactions." +
                    " To board the bus, your name has to match the name on the e-ticket."
                },

                new Question
                {
                    Id = 7,
                    Title="I’ve lost my ticket. What should I do now?",
                    Answer="You can easily access “my tickets” tab once you are logged onto the website," +
                    " to view your history of tickets. You can use this history to view your e-ticket and board the bus."
                },

                new Question
                {
                    Id = 8,
                    Title="Is it mandatory to take a printout of the ticket?",
                    Answer="No, it is not mandatory to take a printout of the ticket," +
                    " however, you need to have a copy of the ticket with your name on it on your device," +
                    " or have the e-ticket to board the bus."
                },

                new Question
                {
                    Id = 9,
                    Title="What are the advantages of purchasing a bus ticket with Go Bus?",
                    Answer="Go Bus’ fleet is very distinctive and is not found in any other transportation company." +
                    " When booking online, it is quick and easy with no need to go to the station to make a booking."
                },

                new Question
                {
                    Id = 10,
                    Title="Does booking online cost me more?",
                    Answer="Booking online does not cost you more, to the contrary, it is time effective and quick."
                },
                #endregion

            });
            
        }
    }
}
