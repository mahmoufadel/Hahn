
using System;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.Identity.Model;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.July2021.Data
{


    public class EFCoreHahnContext : DbContext
    {
        public EFCoreHahnContext(DbContextOptions<EFCoreHahnContext> options) : base(options)
        {
        }

        protected EFCoreHahnContext()
        {
        }
       
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Address> Address { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
            .HasOne(x => x.Address)
            .WithOne(x => x.User).HasForeignKey<Address>(x => x.UserId);

        }
    }
}
