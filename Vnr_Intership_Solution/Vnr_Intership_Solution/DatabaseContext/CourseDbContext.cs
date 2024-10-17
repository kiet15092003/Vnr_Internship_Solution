using Microsoft.EntityFrameworkCore;
using Vnr_Intership_Solution.Models.Entities;

namespace Vnr_Intership_Solution.DatabaseContext
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<CourseDefinition> Courses { get; set; }
        public DbSet<SubjectDefinition> Subjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseDefinition>(entity =>
            {
                entity.ToTable("KhoaHoc");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("TenKhoaHoc")
                    .HasMaxLength(30);
            });
            modelBuilder.Entity<SubjectDefinition>(entity =>
            {
                entity.ToTable("MonHoc");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("TenMonHoc")
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasColumnName("MoTa")
                    .HasMaxLength(100);

                entity.Property(e => e.CourseId).HasColumnName("KhoaHocID");

                entity.HasOne(e => e.Course)
                    .WithMany()
                    .HasForeignKey(e => e.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
