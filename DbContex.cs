using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DbContex : DbContext
    {
        public DbContex(DbContextOptions<DbContex> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(o => new { o.Id });
            modelBuilder.Entity<Product>().HasKey(o => new { o.Id });
            modelBuilder.Entity<Order>().HasKey(o => new { o.Id });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\DAL\DAL\DB.mdf;Integrated Security=True;Initial Catalog=");

        public void Init()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        public DbContex() : base()
        {
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
