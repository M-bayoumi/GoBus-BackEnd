using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FirstName)
               .HasColumnType("varchar")
               .HasMaxLength(10)
               .IsRequired();

            builder.Property(x => x.LastName)
               .HasColumnType("varchar")
               .HasMaxLength(10)
               .IsRequired();

            builder.Property(x => x.Blocked)
               .HasColumnType("bit")
               .IsRequired();



            builder.HasData(new List<ApplicationUser>
            {
                #region Admin
                new ApplicationUser
                {
                    Id = "38e2719d-2c73-4451-b386-32673b9798f4",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi",
                    UserName = "mbayoumi151",
                    NormalizedUserName= "MBAYOUMI151",
                    Email = "mbayoumi151@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "AQAAAAIAAYagAAAAEMkgLtsF9ReuCfvVRFoB4D+raq+vPryyqw9F4mHf5jk6cwSd2VwJHJjPAxa8UdTkOg==",
                    NormalizedEmail = "MBAYOUMI151@GMAIL.COM"
                },
               
                #endregion

                #region Drivers
                new ApplicationUser
                {
                    Id = "f0fd67a7-a8f6-42d1-924b-4ef2cbfbe7dd",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi1",
                    UserName = "Driver1",
                    Email = "Driver1@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "10ebb4a2-4078-4d38-9c1d-b71731e51813",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi2",
                    UserName = "Driver2",
                    Email = "Driver2@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "a079a3f1-ddb0-4f6a-a3fb-952fa92c8951",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi3",
                    UserName = "Driver3",
                    Email = "Driver3@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "69fab494-f64b-4e36-8202-43c8659d6942",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi4",
                    UserName = "Driver4",
                    Email = "Driver4@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "8341a302-6b87-431b-a252-2ffcd90948a1",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi5",
                    UserName = "Driver5",
                    Email = "Driver5@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "f95361be-330d-4e79-b667-4981fd7503c7",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi6",
                    UserName = "Driver6",
                    Email = "Driver6@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "cc6c9526-f50c-4769-91b1-2b0b5bf73acf",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi7",
                    UserName = "Driver7",
                    Email = "Driver7@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "733ec01e-c84f-4c95-ab8f-d3f73d6b3661",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi8",
                    UserName = "Driver8",
                    Email = "Driver8@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "b96da449-a77f-49b0-bc3e-01ce46dd991c",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi9",
                    UserName = "Driver9",
                    Email = "Driver9@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "a0ee769b-5470-44a5-8529-2fa87d254f4a",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi10",
                    UserName = "Driver10",
                    Email = "Driver10@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "db413fd2-ed42-4eb3-81cb-af1d0f5d34c1",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi11",
                    UserName = "Driver11",
                    Email = "Driver11@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "4b47560f-1a8e-451d-8088-e2d96df2deca",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi12",
                    UserName = "Driver12",
                    Email = "Driver12@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "c60ffa8f-57cb-4821-b0a0-5178d12bda71",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi13",
                    UserName = "Driver13",
                    Email = "Driver13@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "9b915f3e-8ff0-40e1-af96-ed02561ba2b5",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi14",
                    UserName = "Driver14",
                    Email = "Driver14@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "61db600d-6a31-4c49-9e4f-eff9621218d7",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi15",
                    UserName = "Driver15",
                    Email = "Driver15@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "a31eabb3-ff8f-4d89-8750-d7d9a2431149",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi16",
                    UserName = "Driver16",
                    Email = "Driver16@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "1947e428-e7f7-4b72-8333-259683d51737",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi17",
                    UserName = "Driver17",
                    Email = "Driver17@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "6ab33b1e-42a6-46c0-adf8-dc572a3a4d36",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi18",
                    UserName = "Driver18",
                    Email = "Driver18@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "20260240-d81d-4eb5-9efa-6750cd5efd78",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi19",
                    UserName = "Driver19",
                    Email = "Driver19@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "c6cdde60-f783-4542-8f36-443c00cdf41f",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi20",
                    UserName = "Driver20",
                    Email = "Driver20@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "1305c3a4-d78d-4698-9767-fb6f0be09c0b",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi21",
                    UserName = "Driver21",
                    Email = "Driver21@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "2ccb170d-598b-4202-86d0-2e30da515914",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi22",
                    UserName = "Driver22",
                    Email = "Driver22@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "3ac4283c-46f2-412b-848d-abbef6f8f96d",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi23",
                    UserName = "Driver23",
                    Email = "Driver23@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "2fcd9e91-89f7-48a9-8f0f-33c4af7e8d80",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi24",
                    UserName = "Driver24",
                    Email = "Driver24@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "45289333-f686-4cc5-a2ed-20d3cb48901b",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi25",
                    UserName = "Driver25",
                    Email = "Driver25@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "7119d1ad-6f54-421c-99ed-bd1ed7ff3a28",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi26",
                    UserName = "Driver26",
                    Email = "Driver26@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "e6d0209c-c4f2-4e25-891c-a653e14a21dd",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi27",
                    UserName = "Driver27",
                    Email = "Driver27@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "8361dfdf-f686-45f4-a45c-7d83a347792d",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi28",
                    UserName = "Driver28",
                    Email = "Driver28@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "58efc192-1af9-4b71-ab9c-165c96593240",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi29",
                    UserName = "Driver29",
                    Email = "Driver29@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "ed62cea4-f01a-4283-b098-642299b04776",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi30",
                    UserName = "Driver30",
                    Email = "Driver30@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "8e449921-33a6-494a-ae62-3de5b2d1f41c",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi31",
                    UserName = "Driver31",
                    Email = "Driver31@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "a83eeaef-cacf-4848-81c2-a1d5746dc2c8",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi32",
                    UserName = "Driver32",
                    Email = "Driver32@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "6304764a-9691-4fc9-8070-4b5f464c16dd",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi33",
                    UserName = "Driver33",
                    Email = "Driver33@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "bcd0a627-1e73-4d60-99bb-5fa4359d1c0d",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi34",
                    UserName = "Driver34",
                    Email = "Driver34@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "43f816d6-81e7-4ec8-9e7e-a90eb27c60c6",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi35",
                    UserName = "Driver35",
                    Email = "Driver35@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "829c0f3d-5cc9-470e-a7da-e6f1186a7216",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi36",
                    UserName = "Driver36",
                    Email = "Driver36@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "9a0f9ad5-2f92-4955-9275-d136728b51a7",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi37",
                    UserName = "Driver37",
                    Email = "Driver37@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "74a47e09-f97c-4e4b-ad51-3eed7fd6ea0d",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi38",
                    UserName = "Driver38",
                    Email = "Driver38@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "5aa2d999-f820-46f7-a9bc-d16da40263f9",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi39",
                    UserName = "Driver39",
                    Email = "Driver39@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                },
                new ApplicationUser
                {
                    Id = "06c4fa4f-f281-4375-a5a5-25f4aaa5fa09",
                    FirstName = "Mohamed",
                    LastName = "Bayoumi40",
                    UserName = "Driver40",
                    Email = "Driver40@gmail.com",
                    PhoneNumber = "01093996245",
                    PasswordHash = "Sm612147?",
                }
                #endregion
            });
        }
    }
}
