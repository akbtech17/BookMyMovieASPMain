using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class BookMyMovieContext : DbContext
    {
        public BookMyMovieContext()
        {
        }

        public BookMyMovieContext(DbContextOptions<BookMyMovieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.\\sqlexpress; database=BookMyMovie; trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.MovieId).HasColumnName("movieId");

                entity.Property(e => e.AgeRating)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ageRating");

                entity.Property(e => e.CostPerSeat)
                    .HasColumnName("costPerSeat")
                    .HasDefaultValueSql("((250))");

                entity.Property(e => e.Duration)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("duration");

                entity.Property(e => e.Genres)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("genres");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.Language)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("language");

                entity.Property(e => e.MovieName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("movieName");

                entity.Property(e => e.MovieType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("movieType");

                entity.Property(e => e.Ratings).HasColumnName("ratings");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("releaseDate");

                entity.Property(e => e.ShowTime)
                    .HasColumnType("datetime")
                    .HasColumnName("showTime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
