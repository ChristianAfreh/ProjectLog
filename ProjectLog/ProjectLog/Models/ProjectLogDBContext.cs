using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProjectLog.Models
{
    public partial class ProjectLogDBContext : DbContext
    {
        public ProjectLogDBContext()
        {
        }

        public ProjectLogDBContext(DbContextOptions<ProjectLogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectPhoto> ProjectPhotos { get; set; }
        public virtual DbSet<Sdg> Sdgs { get; set; }
        public virtual DbSet<Sdgproject> Sdgprojects { get; set; }
        public virtual DbSet<StaffProject> StaffProjects { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<staff> staff { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ProjectLogDB;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK4")
                    .IsClustered(false);

                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK2")
                    .IsClustered(false);

                entity.ToTable("Project");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ProjectManager)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefStatus7");
            });

            modelBuilder.Entity<ProjectPhoto>(entity =>
            {
                entity.ToTable("ProjectPhoto");

                entity.Property(e => e.ProjectPhotoId).HasColumnName("ProjectPhotoID");

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectPhotos)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ref_Project");
            });

            modelBuilder.Entity<Sdg>(entity =>
            {
                entity.HasKey(e => e.GoalId)
                    .HasName("PK1")
                    .IsClustered(false);

                entity.ToTable("SDG");

                entity.Property(e => e.GoalId).HasColumnName("GoalID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Sdgproject>(entity =>
            {
                entity.HasKey(e => e.SdgprojectId)
                    .HasName("PK3")
                    .IsClustered(false);

                entity.ToTable("SDGProject");

                entity.Property(e => e.SdgprojectId).HasColumnName("SDGProjectID");

                entity.Property(e => e.GoalId).HasColumnName("GoalID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Goal)
                    .WithMany(p => p.Sdgprojects)
                    .HasForeignKey(d => d.GoalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefSDG1");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Sdgprojects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProject2");
            });

            modelBuilder.Entity<StaffProject>(entity =>
            {
                entity.HasKey(e => e.StaffProjectId)
                    .HasName("PK8")
                    .IsClustered(false);

                entity.ToTable("StaffProject");

                entity.Property(e => e.StaffProjectId).HasColumnName("StaffProjectID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.StaffProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefProject4");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.StaffProjects)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefStaff5");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK9")
                    .IsClustered(false);

                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK7")
                    .IsClustered(false);

                entity.ToTable("Staff");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OtherNames)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefDepartment3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
