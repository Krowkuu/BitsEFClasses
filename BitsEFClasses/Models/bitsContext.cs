using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BitsEFClasses.Models
{
    public partial class bitsContext : DbContext
    {
        public bitsContext()
        {
        }

        public bitsContext(DbContextOptions<bitsContext> options)
            : base(options)
        {
        }


        public virtual DbSet<AppConfig> AppConfigs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigDB.GetMySqlConnectionString();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 

            modelBuilder.Entity<AppConfig>(entity =>
            {
                entity.HasKey(e => e.BreweryId)
                    .HasName("PRIMARY");

                entity.ToTable("app_config");

                entity.Property(e => e.BreweryId).HasColumnName("brewery_id");

                entity.Property(e => e.BreweryLogo)
                    .HasMaxLength(50)
                    .HasColumnName("brewery_logo");

                entity.Property(e => e.BreweryName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("brewery_name");

                entity.Property(e => e.Color1)
                    .HasMaxLength(10)
                    .HasColumnName("color_1");

                entity.Property(e => e.Color2)
                    .HasMaxLength(10)
                    .HasColumnName("color_2");

                entity.Property(e => e.Color3)
                    .HasMaxLength(10)
                    .HasColumnName("color_3");

                entity.Property(e => e.ColorBlack)
                    .HasMaxLength(10)
                    .HasColumnName("color_black");

                entity.Property(e => e.ColorWhite)
                    .HasMaxLength(10)
                    .HasColumnName("color_white");

                entity.Property(e => e.DefaultUnits)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("default_units")
                    .HasDefaultValueSql("'metric'");

                entity.Property(e => e.HomePageBackgroundImage)
                    .HasMaxLength(50)
                    .HasColumnName("home_page_background_image");

                entity.Property(e => e.HomePageText)
                    .HasColumnType("varchar(5000)")
                    .HasColumnName("home_page_text");
            });

 

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}