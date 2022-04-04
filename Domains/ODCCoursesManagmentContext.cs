using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Domains
{
    public partial class ODCCoursesManagmentContext : DbContext
    {
        public ODCCoursesManagmentContext()
        {
        }

        public ODCCoursesManagmentContext(DbContextOptions<ODCCoursesManagmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<TbCategroie> TbCategroies { get; set; }
        public virtual DbSet<TbCourse> TbCourses { get; set; }
        public virtual DbSet<TbEnroll> TbEnrolls { get; set; }
        public virtual DbSet<TbExam> TbExams { get; set; }
        public virtual DbSet<TbQuestion> TbQuestions { get; set; }
        public virtual DbSet<TbRevision> TbRevisions { get; set; }
        public virtual DbSet<TbTeaching> TbTeachings { get; set; }
        public virtual DbSet<TbTrainer> TbTrainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-62P7HA1\\SQLEXPRESS;Database=ODC Courses Managment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.StudentCreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<TbCategroie>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCourse>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.CourseLevel).IsRequired();

                entity.Property(e => e.CourseName).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbCourses)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbCourses_TbCategroies");
            });

            modelBuilder.Entity<TbEnroll>(entity =>
            {
                entity.ToTable("TbEnroll");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TbEnrolls)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbEnroll_TbCourses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TbEnrolls)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbEnroll_AspNetUsers");
            });

            modelBuilder.Entity<TbExam>(entity =>
            {
                entity.HasKey(e => e.ExamId);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TbExams)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbExams_TbCourses");
            });

            modelBuilder.Entity<TbQuestion>(entity =>
            {
                entity.Property(e => e.FirstChoice).IsRequired();

                entity.Property(e => e.FourthChoice).IsRequired();

                entity.Property(e => e.QuestionContent).IsRequired();

                entity.Property(e => e.QuestionRightAnswer).IsRequired();

                entity.Property(e => e.SecondChoice).IsRequired();

                entity.Property(e => e.ThirdChoice).IsRequired();

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.TbQuestions)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbQuestions_TbExams");
            });

            modelBuilder.Entity<TbRevision>(entity =>
            {
                entity.ToTable("TbRevision");

                entity.Property(e => e.StudentDegree).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.TotalRightDegrees).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.TotalWrongDegrees).HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.TbRevisions)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbRevision_TbExams");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TbRevisions)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbRevision_AspNetUsers");
            });

            modelBuilder.Entity<TbTeaching>(entity =>
            {
                entity.ToTable("TbTeaching");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TbTeachings)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbTeaching_TbCourses");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TbTeachings)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbTeaching_TbTrainers");
            });

            modelBuilder.Entity<TbTrainer>(entity =>
            {
                entity.HasKey(e => e.TrainerId);

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
