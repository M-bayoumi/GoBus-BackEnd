using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {

            builder.HasOne(x => x.ApplicationUser)
                .WithMany(x => x.ApplicationUserRoles)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.ApplicationRole)
                .WithMany(x => x.ApplicationUserRoles)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();

            //builder.ToTable("ApplicationUserRoles");


            builder.HasData(new List<ApplicationUserRole>
            {
                #region ApplicationUserRoles
                new ApplicationUserRole
                {
                    UserId = "f0fd67a7-a8f6-42d1-924b-4ef2cbfbe7dd",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"

                },
                new ApplicationUserRole
                {
                    UserId = "10ebb4a2-4078-4d38-9c1d-b71731e51813",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "a079a3f1-ddb0-4f6a-a3fb-952fa92c8951",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "69fab494-f64b-4e36-8202-43c8659d6942",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "8341a302-6b87-431b-a252-2ffcd90948a1",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "f95361be-330d-4e79-b667-4981fd7503c7",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "cc6c9526-f50c-4769-91b1-2b0b5bf73acf",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "733ec01e-c84f-4c95-ab8f-d3f73d6b3661",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "b96da449-a77f-49b0-bc3e-01ce46dd991c",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "a0ee769b-5470-44a5-8529-2fa87d254f4a",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "db413fd2-ed42-4eb3-81cb-af1d0f5d34c1",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "4b47560f-1a8e-451d-8088-e2d96df2deca",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "c60ffa8f-57cb-4821-b0a0-5178d12bda71",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "9b915f3e-8ff0-40e1-af96-ed02561ba2b5",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "61db600d-6a31-4c49-9e4f-eff9621218d7",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "a31eabb3-ff8f-4d89-8750-d7d9a2431149",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "1947e428-e7f7-4b72-8333-259683d51737",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "6ab33b1e-42a6-46c0-adf8-dc572a3a4d36",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "20260240-d81d-4eb5-9efa-6750cd5efd78",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "c6cdde60-f783-4542-8f36-443c00cdf41f",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "1305c3a4-d78d-4698-9767-fb6f0be09c0b",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "2ccb170d-598b-4202-86d0-2e30da515914",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "3ac4283c-46f2-412b-848d-abbef6f8f96d",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "2fcd9e91-89f7-48a9-8f0f-33c4af7e8d80",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "45289333-f686-4cc5-a2ed-20d3cb48901b",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "7119d1ad-6f54-421c-99ed-bd1ed7ff3a28",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "e6d0209c-c4f2-4e25-891c-a653e14a21dd",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "8361dfdf-f686-45f4-a45c-7d83a347792d",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "58efc192-1af9-4b71-ab9c-165c96593240",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "ed62cea4-f01a-4283-b098-642299b04776",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "8e449921-33a6-494a-ae62-3de5b2d1f41c",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "a83eeaef-cacf-4848-81c2-a1d5746dc2c8",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "6304764a-9691-4fc9-8070-4b5f464c16dd",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "bcd0a627-1e73-4d60-99bb-5fa4359d1c0d",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "43f816d6-81e7-4ec8-9e7e-a90eb27c60c6",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "829c0f3d-5cc9-470e-a7da-e6f1186a7216",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "9a0f9ad5-2f92-4955-9275-d136728b51a7",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "74a47e09-f97c-4e4b-ad51-3eed7fd6ea0d",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "5aa2d999-f820-46f7-a9bc-d16da40263f9",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                },
                new ApplicationUserRole
                {
                    UserId = "06c4fa4f-f281-4375-a5a5-25f4aaa5fa09",
                    RoleId = "491c779b-92be-4a0c-a1bf-91c28fc20e1e"
                }
                #endregion
            });

        }
    }
}
