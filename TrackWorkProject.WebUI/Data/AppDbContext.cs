using Microsoft.EntityFrameworkCore;
using TrackWorkProject.WebUI.Entities;

namespace TrackWorkProject.WebUI.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Directorate> Directorates { get; set; }
    public DbSet<Duty> Duties { get; set; }
    public DbSet<Personel> Personels { get; set; }
    public DbSet<PersonelDuty> PersonelDuties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure relationships and constraints if needed
    
        modelBuilder.Entity<PersonelDuty>().HasKey(pd => new { pd.PersonelId, pd.DutyId });

        modelBuilder.Entity<PersonelDuty>()
            .HasOne(pd => pd.Personel)
            .WithMany(p => p.PersonelDuties)
            .HasForeignKey(pd => pd.PersonelId);

        modelBuilder.Entity<PersonelDuty>()
            .HasOne(pd => pd.Duty)
            .WithMany(d => d.PersonelDuties)
            .HasForeignKey(pd => pd.DutyId);

        modelBuilder.Entity<Duty>()
            .HasOne(d => d.Directorate)
            .WithMany(dir => dir.Duties)
            .HasForeignKey(d => d.DirectorateId)
            .OnDelete(DeleteBehavior.Cascade);



    }
}