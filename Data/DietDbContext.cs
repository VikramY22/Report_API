using Microsoft.EntityFrameworkCore;
using Report_API.Models;

public class DietDbContext : DbContext
{
    public DietDbContext(DbContextOptions<DietDbContext> options)
        : base(options) { }

    public DbSet<NutritionAssessment> NutritionAssessments { get; set; }
    public DbSet<Nutrient> Nutrients { get; set; }
    public DbSet<NutrientIntake> NutrientIntakes { get; set; }
    public DbSet<Supplement> Supplements { get; set; }
    public DbSet<NutritionAssessmentSupplement> NutritionAssessmentSupplements { get; set; }
    public DbSet<SupplementImage> SupplementImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NutritionAssessmentSupplement>()
            .HasKey(nas => new { nas.NutritionAssessmentId, nas.SupplementId });

        modelBuilder.Entity<NutritionAssessmentSupplement>()
            .HasOne(nas => nas.NutritionAssessment)
            .WithMany(n => n.NutritionAssessmentSupplements)
            .HasForeignKey(nas => nas.NutritionAssessmentId);

        modelBuilder.Entity<NutritionAssessmentSupplement>()
            .HasOne(nas => nas.Supplement)
            .WithMany(s => s.NutritionAssessmentSupplements)
            .HasForeignKey(nas => nas.SupplementId);

        modelBuilder.Entity<SupplementImage>()
            .HasOne(si => si.Supplement)
            .WithMany(s => s.Images)
            .HasForeignKey(si => si.SupplementId);
    }
}
