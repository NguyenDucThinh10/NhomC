using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiProject.Repositories.Entities;

public partial class FengShuiKoiDbContext : DbContext
{
    public FengShuiKoiDbContext()
    {
    }

    public FengShuiKoiDbContext(DbContextOptions<FengShuiKoiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }  // Giữ tên này nhất quán

    public virtual DbSet<KoiOwnership> KoiOwnerships { get; set; }

    public virtual DbSet<PaymentHistory> PaymentHistories { get; set; }

    public virtual DbSet<PondDetail> PondDetails { get; set; }

    public virtual DbSet<PondMaintenance> PondMaintenances { get; set; }

    public virtual DbSet<Recommendation> Recommendations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code.
        optionsBuilder.UseSqlServer("Server=DESKTOP-QFUFB46;Database=FengShuiKoiDB;User Id=sa;Password=123123;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFAAAF02B780");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CommentText).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RecommendationId).HasColumnName("RecommendationID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Recommendation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.RecommendationId)
                .HasConstraintName("FK_Comment_Recommendation");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Comment_User");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__KoiFish__E03435B8683112E3");

            entity.ToTable("KoiFish");

            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FengShuiMeaning).HasMaxLength(255);
            entity.Property(e => e.KoiName).HasMaxLength(100);
            entity.Property(e => e.SizeCm)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("SizeCM");
            entity.Property(e => e.SuitableForBmenh).HasMaxLength(50);
        });

        modelBuilder.Entity<KoiOwnership>(entity =>
        {
            entity.HasKey(e => e.OwnershipId).HasName("PK__KoiOwner__A0D871E9DB052F08");

            entity.ToTable("KoiOwnership");

            entity.Property(e => e.OwnershipId).HasColumnName("OwnershipID");
            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Koi).WithMany(p => p.KoiOwnerships)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK_Ownership_Koi");

            entity.HasOne(d => d.Pond).WithMany(p => p.KoiOwnerships)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK_Ownership_Pond");

            entity.HasOne(d => d.User).WithMany(p => p.KoiOwnerships)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Ownership_User");
        });

        modelBuilder.Entity<PaymentHistory>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__PaymentH__9B556A589517A035");

            entity.ToTable("PaymentHistory");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.PaymentHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Payment_User");
        });

        modelBuilder.Entity<PondDetail>(entity =>
        {
            entity.HasKey(e => e.PondId).HasName("PK__PondDeta__D18BF854C6E01DC4");

            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepthCm)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("DepthCM");
            entity.Property(e => e.Direction).HasMaxLength(50);
            entity.Property(e => e.LengthCm)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("LengthCM");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Shape).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WidthCm)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("WidthCM");

            entity.HasOne(d => d.User).WithMany(p => p.PondDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Pond_User");
        });

        modelBuilder.Entity<PondMaintenance>(entity =>
        {
            entity.HasKey(e => e.MaintenanceId).HasName("PK__PondMain__E60542B5C6F822E0");

            entity.ToTable("PondMaintenance");

            entity.Property(e => e.MaintenanceId).HasColumnName("MaintenanceID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.PondId).HasColumnName("PondID");

            entity.HasOne(d => d.Pond).WithMany(p => p.PondMaintenances)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK_Maintenance_Pond");
        });

        modelBuilder.Entity<Recommendation>(entity =>
        {
            entity.HasKey(e => e.RecommendationId).HasName("PK__Recommen__AA15BEC430EE9EC1");

            entity.Property(e => e.RecommendationId).HasColumnName("RecommendationID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.RecommendationText).HasMaxLength(1000);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Koi).WithMany(p => p.Recommendations)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK_Recommendation_Koi");

            entity.HasOne(d => d.Pond).WithMany(p => p.Recommendations)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK_Recommendation_Pond");

            entity.HasOne(d => d.User).WithMany(p => p.Recommendations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Recommendation_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACF2612071");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Bmenh).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__UserRole__8AFACE3AC7277786");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
