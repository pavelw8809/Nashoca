using Microsoft.EntityFrameworkCore;
using Nashoca.Domain.Entities;

namespace Nashoca.Intrastructure
{
    public class MainDbContext : DbContext
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
                .HasForeignKey<VerbTrans>(e => e.VtrSymbol)
                .IsRequired();

            modelBuilder.Entity<VerbTrans>()
                .HasOne(e => e.VerbEn)
                .WithOne(e => e.VerbTrans)
                .HasForeignKey<VerbTrans>(e => e.VenSymbol)
                .IsRequired();
        }
    }
}
