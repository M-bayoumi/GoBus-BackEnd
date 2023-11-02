using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {


            //builder.ToTable("ApplicationRoles");

            
            builder.HasData(new List<ApplicationRole>
            {
                #region ApplicationRoles
                new ApplicationRole
                {
                    Id= "1837ae0a-7274-4acc-8165-65aced540cd2",
                    Name = "User",
                },
                new ApplicationRole
                {
                    Id= "491c779b-92be-4a0c-a1bf-91c28fc20e1e",
                    Name = "Driver",
                },
                new ApplicationRole
                {
                    Id= "b79f5098-1212-492e-853b-0ea294f0ec2d",
                    Name = "Admin",
                },
                #endregion
            });
            
        }
    }
}
