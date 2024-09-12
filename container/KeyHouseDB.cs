using Microsoft.EntityFrameworkCore;
using KeyHouse.Models.Entities;

namespace KeyHouse.container
{
    public class KeyHouseDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Agencies> Agencies { get; set; }
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
