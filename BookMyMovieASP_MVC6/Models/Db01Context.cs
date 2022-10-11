using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class Db01Context : DbContext
    {
        public Db01Context()
        {
        }

        public Db01Context(DbContextOptions<Db01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Akbadmin> Akbadmins { get; set; } = null!;
        public virtual DbSet<Akbcustomer> Akbcustomers { get; set; } = null!;
        public virtual DbSet<Akbmovie> Akbmovies { get; set; } = null!;
        public virtual DbSet<AkbseatMap> AkbseatMaps { get; set; } = null!;
        public virtual DbSet<AkbtransactionDetail> AkbtransactionDetails { get; set; } = null!;
        public virtual DbSet<AkbtransactionSeat> AkbtransactionSeats { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:cldazure.database.windows.net,1433;Initial Catalog=Db01;Persist Security Info=False;User ID=cldazure;Password=b@atch@12345!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Akbadmin>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__AKBAdmin__719FE488A754C3E8");

                entity.ToTable("AKBAdmin");

                entity.HasIndex(e => e.Email, "UQ__AKBAdmin__A9D1053474FAA8B7")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Akbcustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__AKBCusto__A4AE64D809D546D5");

                entity.ToTable("AKBCustomer");

                entity.HasIndex(e => e.Email, "UQ__AKBCusto__A9D1053418429199")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Akbmovie>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("PK__AKBMovie__4BD2941A0528BE02");

                entity.ToTable("AKBMovie");

                entity.Property(e => e.AgeRating)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CostPerSeat).HasDefaultValueSql("((250))");

                entity.Property(e => e.Duration)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Genres)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MovieType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.ShowTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AkbseatMap>(entity =>
            {
                entity.HasKey(e => e.SeatId)
                    .HasName("PK__AKBSeatM__311713F3FE6BCC6D");

                entity.ToTable("AKBSeatMap");

                entity.Property(e => e.SeatNo)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.AkbseatMaps)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__AKBSeatMa__Movie__60BE0156");
            });

            modelBuilder.Entity<AkbtransactionDetail>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__AKBTrans__55433A6BB6CE1D3F");

                entity.ToTable("AKBTransactionDetails");

                entity.Property(e => e.TransactionTime).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AkbtransactionDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__AKBTransa__Custo__648E923A");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.AkbtransactionDetails)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__AKBTransa__Movie__6582B673");
            });

            modelBuilder.Entity<AkbtransactionSeat>(entity =>
            {
                entity.HasKey(e => new { e.TransactionId, e.SeatNo })
                    .HasName("PK_TransactionSeat");

                entity.ToTable("AKBTransactionSeat");

                entity.Property(e => e.SeatNo)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.AkbtransactionSeats)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AKBTransa__Trans__685F231E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
