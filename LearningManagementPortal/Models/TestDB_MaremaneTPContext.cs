using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearningManagementPortal.Models
{
    public partial class TestDB_MaremaneTPContext : DbContext
    {
        public TestDB_MaremaneTPContext()
        {
        }

        public TestDB_MaremaneTPContext(DbContextOptions<TestDB_MaremaneTPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentCourse> StudentCourse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=TestDB_MaremaneTP;Trusted_Connection=True;");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => e.CourseId)
                    .HasName("UQ__Course__C92D71A66F682887")
                    .IsUnique();

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CourseNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[CourseNumber_fn]([CourseName]))");

                //entity.Property(e => e.EndDate).HasColumnType("datetime");

                //entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.StudentId)
                    .HasName("UQ__Student__32C52B98CD8B7444")
                    .IsUnique();

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idnumber)
                    .HasColumnName("IDNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentNumber)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[StudentNumber_fn]([StudentId]))");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.ToTable("Student_Course");

                entity.Property(e => e.StudentCourseId).HasColumnName("StudentCourseID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourse)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Course__Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourse)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Course_Student");
            });
        }
    }
}
