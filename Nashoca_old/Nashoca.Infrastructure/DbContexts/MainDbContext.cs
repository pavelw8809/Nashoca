using Microsoft.EntityFrameworkCore;
using Nashoca.Domain.Entities;

namespace Nashoca.Infrastructure.DbContexts
{
    public class MainDbContext(DbContextOptions<MainDbContext> options) : DbContext(options)
    {
        public DbSet<VerbTr> VerbsTr { get; set; }
        public DbSet<VerbEn> VerbsEn { get; set; }
        public DbSet<VerbTrans> VerbsTrans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VerbTrans>()
                .HasOne(e => e.VerbTr)
                .WithOne(e => e.VerbTrans)
                .HasForeignKey<VerbTrans>(e => e.VtTr)
                .IsRequired();

            modelBuilder.Entity<VerbTrans>()
                .HasOne(e => e.VerbEn)
                .WithOne(e => e.VerbTrans)
                .HasForeignKey<VerbTrans>(e => e.VtEn)
                .IsRequired();

        }
    }
}
