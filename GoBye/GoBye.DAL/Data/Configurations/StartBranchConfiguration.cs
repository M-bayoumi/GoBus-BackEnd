using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class StartBranchConfiguration : IEntityTypeConfiguration<StartBranch>
    {
        public void Configure(EntityTypeBuilder<StartBranch> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(x => x.Address)
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder.Property(x => x.Phone)
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder.ToTable("StartBranches");

            
            builder.HasData(new List<StartBranch>
            {

                #region Cairo Branches
                new StartBranch
                {
                    Id=1,
                    Name="Ramses",
                    Address="9 Ramses St. (Railroad Company) in front of Ramses Train station",
                    Phone="01093996245",
                    DestinationId=1,
                },

                new StartBranch
                {
                    Id=2,
                    Name="6 october",
                    Address="The Tourist walkway west of Somid, the central axis in front of 6 october City Hall",
                    Phone="01093996245",
                    DestinationId=1,
                },

                new StartBranch
                {
                    Id=3,
                    Name="Madinaty",
                    Address="Madinaty Gate 1",
                    Phone="01093996245",
                    DestinationId=1,
                },

                new StartBranch
                {
                    Id=4,
                    Name="AbdelMoneim Riyad",
                    Address="4 El Galaa St. AbdelMoneim Riyad square next to Ramses Hilton Hotel Maspero Mall.",
                    Phone="01093996245",
                    DestinationId=1,
                },
                #endregion

                #region Red Sea Branches
                new StartBranch
                {
                    Id=5,
                    Name="Safaga",
                    Address="Next to Safaga Port Open from 7 am to 12 am",
                    Phone="01093996245",
                    DestinationId=2,
                },

                new StartBranch
                {
                    Id=6,
                    Name="Marsa Alam",
                    Address="Next to CIB, 68 El Souq St. - In front of El Gamee Bank . Open from 8 am to 8 pm",
                    Phone="01093996245",
                    DestinationId=2,
                },

                new StartBranch
                {
                    Id=7,
                    Name="El Gouna",
                    Address="Bike and in front of El Gouna School Open from 8.30 am to 12.30 am",
                    Phone="01093996245",
                    DestinationId=2,
                },

                new StartBranch
                {
                    Id=8,
                    Name="Makadi",
                    Address="Inside of Orascom Mall Makadi. Open from 9 am to 7 pm",
                    Phone="01093996245",
                    DestinationId=2,
                },

                new StartBranch
                {
                    Id=9,
                    Name="Sahl Hasheesh",
                    Address="Downtown next to Best Way Market beside the cinema. Getting on and off of the bus from the parking at the waiting hall of Pizatzza Village not from in front of the office. Open from 9 am to 9 pm.",
                    Phone="01093996245",
                    DestinationId=2,
                },

                new StartBranch
                {
                    Id=10,
                    Name="Main Hurghada Office",
                    Address="ElNasr St. next to The Red Sea Hospital and ElHadidy Market and the old Fire station. Open 24 hrs.",
                    Phone="01093996245",
                    DestinationId=2,
                },
                #endregion

                #region South Sinai Branches
                new StartBranch
                {
                    Id=11,
                    Name="Ras Sader Station",
                    Address="Located at Adam Abu Sawira Cafeteria is located directly on the road",
                    Phone="01093996245",
                    DestinationId=3,
                },

                new StartBranch
                {
                    Id=12,
                    Name="La Hacienda",
                    Address="La Hacienda",
                    Phone="01093996245",
                    DestinationId=3,
                },

                new StartBranch
                {
                    Id=13,
                    Name="Dahab",
                    Address="El Mashraba St. beside Dahab Plaza Hotel next to Maabar ElSeel Bride. Open from 7 am to 2 am",
                    Phone="01093996245",
                    DestinationId=3,
                },

                new StartBranch
                {
                    Id=14,
                    Name="Sharm",
                    Address="Shams Mall in front of Elwataneya Gas station - before Sharm ElSheikh International Hospital (International Haram Hospital)",
                    Phone="01093996245",
                    DestinationId=3,
                },
                #endregion

                #region Alexandria Branches
                new StartBranch
                {
                    Id=15,
                    Name="Miami",
                    Address="45 St. Miami Corniche - Next to ElKataa Fish Open from 10 am to 1 am",
                    Phone="01093996245",
                    DestinationId=4,
                },

                new StartBranch
                {
                    Id=16,
                    Name="Moharam Bek",
                    Address="Inside of of the New Station , there are two offices in the building - Bus station is at platform 6 Open 24 hrs.",
                    Phone="01093996245",
                    DestinationId=4,
                },
                #endregion

                #region North Coast Branches
                new StartBranch
                {
                    Id=17,
                    Name="Marina 7",
                    Address="Marina 7 : Before Marina 7 gate with 200 m - next to El Ahly Bank and Allam Auto Motors - the office is on the opposite side of the gate",
                    Phone="01093996245",
                    DestinationId=5,
                },

                new StartBranch
                {
                    Id=18,
                    Name="Sidi Abdelrahman",
                    Address="Stella Sidi Abdelrahman ; Infront of Stella Walk mall Sidi Abdelrahman",
                    Phone="01093996245",
                    DestinationId=5,
                },

                new StartBranch
                {
                    Id=19,
                    Name="Marassi",
                    Address="Marassi : After the traffic point of Sidi Abdelrahman with 300 m in the direction of Alexandria next to ElGezira Coach",
                    Phone="01093996245",
                    DestinationId=5,
                },

                new StartBranch
                {
                    Id=20,
                    Name="Marsa Matruh",
                    Address="At km 2 - next to West Delta Travel station",
                    Phone="01093996245",
                    DestinationId=5,
                },
                #endregion

                #region Suez Branches
                new StartBranch
                {
                    Id=21,
                    Name="Porto EL Sokhna",
                    Address="In Front of El Mahmal Supermarket at Porto Sokhna Entrance Getting on and off of the bus from Gate 2 of Porto EL Sokhna beneath the pedestrian bridge in front of Ragab Sons Supermarket. Go Mini station is in front of Mcdonalds near the office. Open from 6 am to 11 pm",
                    Phone="01093996245",
                    DestinationId=6,
                },
                #endregion

                #region Qena Branches
                new StartBranch
                {
                    Id=22,
                    Name="Qena Sidi Abdelraheem",
                    Address="Next to Sidi Abdelraheem Mosque and El Soltan store. Open 24 hrs",
                    Phone="01093996245",
                    DestinationId=7,
                },
                #endregion

                #region Gharbia Branches
                new StartBranch
                {
                    Id=23,
                    Name="Mahalla",
                    Address="6 Abdel el hay shahin Mansheya El-Bakry El Mahalla 1st Police Department",
                    Phone="01093996245",
                    DestinationId=8,
                },

                new StartBranch
                {
                    Id=24,
                    Name="Tanta",
                    Address="1 Abdel wahab St. with el fateh infront of wholesale market position",
                    Phone="01093996245",
                    DestinationId=8,
                },
                #endregion

                #region Port Said Branches
                new StartBranch
                {
                    Id=25,
                    Name="Port Said Downtown",
                    Address="Downtown mall -next to the fish market - in front of (Gawaher El Bon)",
                    Phone="01093996245",
                    DestinationId=9,
                },
                #endregion

                #region Assiut Branches
                new StartBranch
                {
                    Id=26,
                    Name="El Helaly",
                    Address="El Helaly St.at the beginning of El Helaly bridge next to the Syndicate Of Applicators",
                    Phone="01093996245",
                    DestinationId=10,
                },
                #endregion

                #region Menia Branches
                new StartBranch
                {
                    Id=27,
                    Name="Minya",
                    Address="Shahin neighberhood, 23 Cairo - Aswan agriculture road",
                    Phone="01093996245",
                    DestinationId=11,
                },
                #endregion

                #region Luxor Branches
                new StartBranch
                {
                    Id=28,
                    Name="Luxor",
                    Address="17 Ramses St. Next to the train station. Open 24 hrs",
                    Phone="01093996245",
                    DestinationId=12,
                },
                #endregion

                #region Dakahlia Branches
                new StartBranch
                {
                    Id=29,
                    Name="El Mansoura",
                    Address="El Geish St. next to Cairo bank infront of East Delta Travel",
                    Phone="01093996245",
                    DestinationId=13,
                },
                #endregion

                #region Ismailia Branches
                new StartBranch
                {
                    Id=30,
                    Name="Ismailia",
                    Address="Drop off and pick up at El Gomhoria St.",
                    Phone="01093996245",
                    DestinationId=14,
                },
                #endregion

            });
            
        }
    }
}
