using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppOceanShop.Models
{
    public partial class OceanCartDbContext : DbContext
    {
        public OceanCartDbContext()
        {
        }

        public OceanCartDbContext(DbContextOptions<OceanCartDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TCategory> TCategories { get; set; } = null!;
        public virtual DbSet<TMember> TMembers { get; set; } = null!;
        public virtual DbSet<TOrder> TOrders { get; set; } = null!;
        public virtual DbSet<TOrderDetail> TOrderDetails { get; set; } = null!;
        public virtual DbSet<TProduct> TProducts { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCategory>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tCategory");

                entity.HasIndex(e => e.FCategory, "IX_tCategory")
                    .IsUnique();

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FCategory).HasColumnName("fCategory");

                entity.Property(e => e.FCategoryName)
                    .HasMaxLength(25)
                    .HasColumnName("fCategoryName");
            });

            modelBuilder.Entity<TMember>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tMember");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FPwd)
                    .HasMaxLength(50)
                    .HasColumnName("fPwd");

                entity.Property(e => e.FUserId)
                    .HasMaxLength(50)
                    .HasColumnName("fUserId");
            });

            modelBuilder.Entity<TOrder>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tOrder");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FAddress)
                    .HasMaxLength(50)
                    .HasColumnName("fAddress");

                entity.Property(e => e.FDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fDate");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FOrderGuid)
                    .HasMaxLength(50)
                    .HasColumnName("fOrderGuid");

                entity.Property(e => e.FReceiver)
                    .HasMaxLength(50)
                    .HasColumnName("fReceiver");

                entity.Property(e => e.FUserId)
                    .HasMaxLength(50)
                    .HasColumnName("fUserId");
            });

            modelBuilder.Entity<TOrderDetail>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tOrderDetail");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FDiscount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("fDiscount");

                entity.Property(e => e.FIsApproved)
                    .HasMaxLength(10)
                    .HasColumnName("fIsApproved");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FOrderGuid)
                    .HasMaxLength(50)
                    .HasColumnName("fOrderGuid");

                entity.Property(e => e.FPid)
                    .HasMaxLength(50)
                    .HasColumnName("fPId");

                entity.Property(e => e.FPrice).HasColumnName("fPrice");

                entity.Property(e => e.FQty).HasColumnName("fQty");

                entity.Property(e => e.FTotal).HasColumnName("fTotal");

                entity.Property(e => e.FUserId)
                    .HasMaxLength(50)
                    .HasColumnName("fUserId");
            });

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tProduct");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FCategory).HasColumnName("fCategory");

                entity.Property(e => e.FDescription)
                    .HasMaxLength(250)
                    .HasColumnName("fDescription");

                entity.Property(e => e.FImagePath)
                    .HasMaxLength(500)
                    .HasColumnName("fImagePath");

                entity.Property(e => e.FIsActiveFlag).HasColumnName("fIsActiveFlag");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FPid)
                    .HasMaxLength(25)
                    .HasColumnName("fPId");

                entity.Property(e => e.FPrice).HasColumnName("fPrice");

                entity.HasOne(d => d.FCategoryNavigation)
                    .WithMany(p => p.TProducts)
                    .HasPrincipalKey(p => p.FCategory)
                    .HasForeignKey(d => d.FCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tProduct_tCategory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
