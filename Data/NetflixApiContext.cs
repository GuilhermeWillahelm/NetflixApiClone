using NetflixApiClone.Identity;
using NetflixApiClone.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NetflixApiClone.Data
{
    public class NetflixApiContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public NetflixApiContext(DbContextOptions<NetflixApiContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<MyList> MyLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role).WithMany(r => r.UserRoles)
                .HasForeignKey(u => u.RoleId).IsRequired();

                userRole.HasOne(ur => ur.User).WithMany(r => r.UserRoles)
                .HasForeignKey(u => u.UserId).IsRequired();
            });
        }
        public DbSet<NetflixApiClone.Models.MyList> MyList { get; set; } = default!;
    }
}
