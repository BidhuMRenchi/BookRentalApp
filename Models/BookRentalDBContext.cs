using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookRentalApp.Models
{
    public partial class BookRentalDBContext : DbContext
    {
        public BookRentalDBContext()
        {
        }

        public BookRentalDBContext(DbContextOptions<BookRentalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Rentals> Rentals { get; set; }

/*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
                See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= BIDHUM\\SQLEXPRESS; Initial Catalog= BookRentalDB; Integrated security=True");
            }
        }
*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BId)
                    .HasName("PK__Books__4E29C30DD44E8251");

                entity.Property(e => e.BId).HasColumnName("b_id");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnName("author")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.BName)
                    .IsRequired()
                    .HasColumnName("b_Name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.GenreId).HasColumnName("Genre_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Publication)
                    .IsRequired()
                    .HasColumnName("publication")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Books__Genre_id__267ABA7A");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Customer__D830D4578A3885B7");

                entity.Property(e => e.CId).HasColumnName("cID");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("cName")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .HasName("PK__Genres__964B240E00C70228");

                entity.Property(e => e.GenreId).HasColumnName("Genre_id");

                entity.Property(e => e.GName)
                    .HasColumnName("gName")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rentals>(entity =>
            {
                entity.HasKey(e => e.RentId)
                    .HasName("PK__Rentals__354E5AA7D796E95F");

                entity.Property(e => e.RentId).HasColumnName("rentID");

                entity.Property(e => e.BId).HasColumnName("b_id");

                entity.Property(e => e.CId).HasColumnName("cID");

                entity.Property(e => e.DaysKept).HasColumnName("daysKept");

                entity.Property(e => e.Fine).HasColumnName("fine");

                entity.HasOne(d => d.B)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.BId)
                    .HasConstraintName("FK__Rentals__b_id__2B3F6F97");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK__Rentals__cID__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
