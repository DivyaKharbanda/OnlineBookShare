using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<UserDetails>(u => u.UserDetails)
                .WithOne(u => u.User)
                .HasForeignKey<UserDetails>(ud => ud.UserId);

            modelBuilder.Entity<User>()
                .HasOne<BookMaster>(u => u.BookMaster)
                .WithOne(u => u.User)
                .HasForeignKey<BookMaster>(ud => ud.UserId);
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserDetails> UserDeatils { get; set; }
        public DbSet<BookMaster> BookMaster { get; set; }
        public DbSet<TxnTable> TxnTable { get; set; }
    }
}
