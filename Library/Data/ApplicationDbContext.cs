
using Library.Models;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data

{
    public class ApplicationDbContext : IdentityDbContext<AppUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }


        public DbSet<BookModel> Books { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
            this.SeedAdmin(builder);
           
            
        }

       





       
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" }
               
                );
        }



        private void SeedAdmin(ModelBuilder builder)
        {
            var AdminUser = new AppUser
            {
                Id = "71213656-375e-4f26-8cb9-fa34740e6691",
                UserName = "Hasan",
                NormalizedUserName = "HASAN",
                Email = "Hasan@hh.com",
                NormalizedEmail = "HASAN@HH.COM",
                PasswordHash = "AQAAAAIAAYagAAAAECYGjH+g2eH+sZATW3ca4lY7dfkFVVP0+wWciwheIPkvr3+l4hNXanxe/RQI4NuLKA==",
                SecurityStamp = "XN4MNXY2RIUVN6Q6U4IFRE3QMSTQO2J6",
                ConcurrencyStamp = "1394d109-071d-4d0c-a633-194b9a51afc6",
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = true,
                Name = "Hasan",
                Address = "Amman"




            };


            builder.Entity<AppUser>().HasData( AdminUser );


            var AdminRole = new IdentityUserRole<string>
            {
                RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                UserId = AdminUser.Id,
                

            };

            builder.Entity<IdentityUserRole<string>>().HasData( AdminRole );


        }

    }
}

    



  
