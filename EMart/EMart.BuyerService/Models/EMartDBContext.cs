﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMart.BuyerService.Models
{
    public partial class EMartDBContext : DbContext
    {
        public EMartDBContext()
        {
        }

        public EMartDBContext(DbContextOptions<EMartDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CHU7B0H\\SQLEXPRESS;Initial Catalog=EMartDB;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasIndex(e => e.EmailId)
                    .HasName("UQ__Buyer__7ED91ACE69494A5F")
                    .IsUnique();

                entity.HasIndex(e => e.MobileNo)
                    .HasName("UQ__Buyer__D6D73A868B4FB673")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Buyer__C9F284567C023648")
                    .IsUnique();

                entity.Property(e => e.BuyerId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SellerId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.StockNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubcategoryId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Cart__CategoryId__3F466844");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__Cart__ItemId__4222D4EF");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__Cart__SellerId__412EB0B6");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.SubcategoryId)
                    .HasConstraintName("FK__Cart__Subcategor__403A8C7D");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__Category__8517B2E0C27B3E3F")
                    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BriefDetails)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Percentage)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__Items__727E838BB2428029");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SellerId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.StockNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubcategoryId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Items__CategoryI__22AA2996");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__Items__SellerId__21B6055D");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SubcategoryId)
                    .HasConstraintName("FK__Items__Subcatego__239E4DCF");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasIndex(e => e.EmailId)
                    .HasName("UQ__Seller__7ED91ACEABFAF170")
                    .IsUnique();

                entity.HasIndex(e => e.Gstin)
                    .HasName("UQ__Seller__0604E65FCEAFCC8A")
                    .IsUnique();

                entity.HasIndex(e => e.MobileNo)
                    .HasName("UQ__Seller__D6D73A8645613E5E")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Seller__C9F28456E457A6FF")
                    .IsUnique();

                entity.Property(e => e.SellerId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BriefDetails)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gstin)
                    .IsRequired()
                    .HasColumnName("GSTIN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PostalAddress)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasIndex(e => e.SubcategoryName)
                    .HasName("UQ__SubCateg__9BAD5E87ADD67C57")
                    .IsUnique();

                entity.Property(e => e.SubcategoryId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BriefDetails)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Gst)
                    .IsRequired()
                    .HasColumnName("GST")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubcategoryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__SubCatego__Categ__1ED998B2");
            });

            modelBuilder.Entity<TransactionHistory>(entity =>
            {
                entity.HasIndex(e => e.TransactionId)
                    .HasName("UQ__Transact__55433A6AAB40B58B")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BuyerId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfItems)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SellerId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.TransactionHistory)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK__Transacti__Buyer__276EDEB3");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TransactionHistory)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__Transacti__ItemI__29572725");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.TransactionHistory)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__Transacti__Selle__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
