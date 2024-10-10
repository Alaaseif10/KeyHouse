using Microsoft.EntityFrameworkCore;
using KeyHouse.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KeyHouse.container
{
    public class KeyHouseDB : IdentityDbContext <Users>
    {
        public KeyHouseDB() { }
        public KeyHouseDB(DbContextOptions<KeyHouseDB> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Interest>().HasKey(td => new { td.UsersId, td.UnitsId });
            modelBuilder.Entity<Interest>().HasIndex(td => new { td.UsersId, td.UnitsId }).IsUnique();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Units>().Property(p => p.Type_Rent).HasConversion<string>();
            modelBuilder.Entity<Units>().Property(p => p.Under_constracting_Status).HasConversion<string>();
            //modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Agencies> Agencies { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }

        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<BenefitsServices> BenefitsServices { get; set; }
        public virtual DbSet<Governments> Governments { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Blocks> Blocks { get; set; }
        public virtual DbSet<Interest> Interest { get; set; }

    }
}
