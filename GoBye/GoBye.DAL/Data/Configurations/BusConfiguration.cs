using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;
using System.ComponentModel;
using System.Security.Claims;
using System.Collections.Generic;

namespace GoBye.DAL.Data.Configurations
{
    public class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Capacity)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Model)
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder.Property(x => x.Year)
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder.Property(x => x.CurrentBranch)
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder.Property(x => x.Available)
               .HasColumnType("bit")
               .IsRequired();

            builder.HasOne(x => x.BusClass)
                .WithMany(x => x.Buses)
                .HasForeignKey(x => x.BusClassId)
                .IsRequired();

            builder.HasOne(x => x.Driver)
                .WithMany(x => x.Buses)
                .HasForeignKey(x => x.DriverId)
                .IsRequired();

            builder.HasMany(x => x.Trips)
                .WithOne(x => x.Bus)
                .HasForeignKey(x => x.BusId)
                .IsRequired();

            builder.ToTable("Buses");

            
            builder.HasData(new List<Bus>
            {
                #region Super Go D Buses
                new Bus
                {
                    Id = 1,
                    Number =101,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 1,
                    DriverId = "f0fd67a7-a8f6-42d1-924b-4ef2cbfbe7dd"
                },

                new Bus
                {
                    Id =2,
                    Number =102,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 1,
                    DriverId = "10ebb4a2-4078-4d38-9c1d-b71731e51813"
                },

                new Bus
                {
                    Id =3,
                    Number =103,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 1,
                    DriverId = "a079a3f1-ddb0-4f6a-a3fb-952fa92c8951"
                },

                new Bus
                {
                    Id =4,
                    Number =104,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 1,
                    DriverId = "69fab494-f64b-4e36-8202-43c8659d6942"
                },

                new Bus
                {
                    Id =5,
                    Number =105,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 1,
                    DriverId = "8341a302-6b87-431b-a252-2ffcd90948a1"
                },
                #endregion

                #region Business Class DD Buses
                new Bus
                {
                    Id=6,
                    Number =201,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 2,
                    DriverId = "f95361be-330d-4e79-b667-4981fd7503c7"
                },

                new Bus
                {
                    Id = 7,
                    Number =202,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 2,
                    DriverId = "cc6c9526-f50c-4769-91b1-2b0b5bf73acf"
                },

                new Bus
                {
                    Id=8,
                    Number =203,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 2,
                    DriverId = "733ec01e-c84f-4c95-ab8f-d3f73d6b3661"
                },

                new Bus
                {
                    Id=9,
                    Number =204,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 2,
                    DriverId = "b96da449-a77f-49b0-bc3e-01ce46dd991c"
                },

                new Bus
                {
                    Id=10,
                    Number =205,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 2,
                    DriverId = "a0ee769b-5470-44a5-8529-2fa87d254f4a"
                },
                #endregion

                #region Elite Business Class M Buses
                new Bus
                {
                    Id=11,
                    Number =301,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 3,
                    DriverId = "db413fd2-ed42-4eb3-81cb-af1d0f5d34c1"
                },

                new Bus
                {
                    Id=12,
                    Number =302,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 3,
                    DriverId = "4b47560f-1a8e-451d-8088-e2d96df2deca"
                },

                new Bus
                {
                    Id=13,
                    Number =303,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 3,
                    DriverId = "c60ffa8f-57cb-4821-b0a0-5178d12bda71"
                },

                new Bus
                {
                    Id=14,
                    Number =304,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 3,
                    DriverId = "9b915f3e-8ff0-40e1-af96-ed02561ba2b5"
                },


                new Bus
                {
                    Id=15,
                    Number =305,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 3,
                    DriverId = "61db600d-6a31-4c49-9e4f-eff9621218d7"
                },
                #endregion

                #region New Deluxe Buses
                new Bus
                {
                    Id=16,
                    Number =501,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 4,
                    DriverId = "1305c3a4-d78d-4698-9767-fb6f0be09c0b"
                },

                new Bus
                {
                    Id=17,
                    Number =502,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 4,
                    DriverId = "2ccb170d-598b-4202-86d0-2e30da515914"
                },

                new Bus
                {
                    Id=18,
                    Number =503,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 4,
                    DriverId = "3ac4283c-46f2-412b-848d-abbef6f8f96d"
                },

                new Bus
                {
                    Id=19,
                    Number =504,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 4,
                    DriverId = "2fcd9e91-89f7-48a9-8f0f-33c4af7e8d80"
                },

                new Bus
                {
                    Id=20,
                    Number =505,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 4,
                    DriverId = "45289333-f686-4cc5-a2ed-20d3cb48901b"
                },
                #endregion

                #region Economy Buses
                new Bus
                {
                    Id=21,
                    Number =601,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 5,
                    DriverId = "7119d1ad-6f54-421c-99ed-bd1ed7ff3a28"
                },

                new Bus
                {
                    Id=22,
                    Number =602,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 5,
                    DriverId = "e6d0209c-c4f2-4e25-891c-a653e14a21dd"
                },

                new Bus
                {
                    Id=23,
                    Number =603,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 5,
                    DriverId = "8361dfdf-f686-45f4-a45c-7d83a347792d"
                },

                new Bus
                {
                    Id=24,
                    Number =604,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 5,
                    DriverId = "58efc192-1af9-4b71-ab9c-165c96593240"
                },

                new Bus
                {
                    Id=25,
                    Number =605,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 5,
                    DriverId = "ed62cea4-f01a-4283-b098-642299b04776"
                },
                #endregion

                #region Elite Business Class V Buses
                new Bus
                {
                    Id=26,
                    Number =701,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 6,
                    DriverId = "8e449921-33a6-494a-ae62-3de5b2d1f41c"
                },

                new Bus
                {
                    Id=27,
                    Number =702,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 6,
                    DriverId = "a83eeaef-cacf-4848-81c2-a1d5746dc2c8"
                },

                new Bus
                {
                    Id=28,
                    Number =703,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 6,
                    DriverId = "6304764a-9691-4fc9-8070-4b5f464c16dd"
                },

                new Bus
                {
                    Id=29,
                    Number =704,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 6,
                    DriverId = "bcd0a627-1e73-4d60-99bb-5fa4359d1c0d"
                },

                new Bus
                {
                    Id=30,
                    Number =705,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 6,
                    DriverId = "43f816d6-81e7-4ec8-9e7e-a90eb27c60c6"
                },
                #endregion

                #region Aero First Class Buses
                new Bus
                {
                    Id=31,
                    Number =801,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 7,
                    DriverId = "829c0f3d-5cc9-470e-a7da-e6f1186a7216"
                },

                new Bus
                {
                    Id=32,
                    Number =802,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 7,
                    DriverId = "9a0f9ad5-2f92-4955-9275-d136728b51a7"
                },

                new Bus
                {
                    Id=33,
                    Number =803,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 7,
                    DriverId = "74a47e09-f97c-4e4b-ad51-3eed7fd6ea0d"
                },

                new Bus
                {
                    Id=34,
                    Number =804,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 7,
                    DriverId = "5aa2d999-f820-46f7-a9bc-d16da40263f9"
                },

                new Bus
                {
                    Id=35,
                    Number =805,
                    Capacity = 49,
                    Model = "Mercedes",
                    Year = "2023",
                    BusClassId = 7,
                    DriverId = "06c4fa4f-f281-4375-a5a5-25f4aaa5fa09"
                },
                #endregion

            });
        }
    }
}
