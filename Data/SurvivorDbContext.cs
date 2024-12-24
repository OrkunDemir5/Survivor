using Microsoft.EntityFrameworkCore;
using Survivor.Entities;

namespace Survivor.Data
{
    public class SurvivorDbContext : DbContext
    {
        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Competitor> Competitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // PostgreSQL için bağlantı dizesi
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=SurvivorDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category için yapılandırmalar
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(200).IsRequired();

            // Competitor için yapılandırmalar
            modelBuilder.Entity<Competitor>()
                .Property(c => c.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Competitor>()
                .Property(c => c.LastName)
                .HasMaxLength(100)
                .IsRequired();

            // One-to-Many ilişki: Bir kategori, birden fazla yarışmacıya sahip olabilir
            modelBuilder.Entity<Competitor>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Competitors)
                .HasForeignKey(c => c.CategoryId);

            // Örnek veriler (Seed Data)
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Ünlüler" },
                new Category() { Id = 2, Name = "Gönüllüler" }
            );

            modelBuilder.Entity<Competitor>().HasData(
                new Competitor() { Id = 1, FirstName = "Acun", LastName = "Ilıcalı", CategoryId = 1 },
                new Competitor() { Id = 2, FirstName = "Aleyna", LastName = "Avcı", CategoryId = 1 },
                new Competitor() { Id = 3, FirstName = "Hadise", LastName = "Açıkgöz", CategoryId = 1 },
                new Competitor() { Id = 4, FirstName = "Ahmet", LastName = "Yılmaz", CategoryId = 2 },
                new Competitor() { Id = 5, FirstName = "Elif", LastName = "Demirtaş", CategoryId = 2 }
            );
        }
    }
}
