using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NaboPlannerAngular.Models.DB
{
    public partial class nabo_planer_dbContext : DbContext
    {
        public nabo_planer_dbContext()
        {
        }

        public nabo_planer_dbContext(DbContextOptions<nabo_planer_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Song> Song { get; set; }
        public virtual DbSet<SongText> SongText { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasKey(e => e.PkSongId);

                entity.Property(e => e.PkSongId).HasColumnName("Pk_Song_Id");

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SongAuthor).HasMaxLength(50);

                entity.Property(e => e.SongName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tags).HasMaxLength(100);
            });

            modelBuilder.Entity<SongText>(entity =>
            {
                entity.HasKey(e => e.PkVerseId);

                entity.Property(e => e.PkVerseId).HasColumnName("Pk_Verse_Id");

                entity.Property(e => e.Bridge).HasMaxLength(500);

                entity.Property(e => e.Chorus).HasMaxLength(1000);

                entity.Property(e => e.FkSongId).HasColumnName("Fk_Song_Id");

                entity.Property(e => e.VerseText).HasMaxLength(2000);

                entity.HasOne(d => d.FkSong)
                    .WithMany(p => p.SongText)
                    .HasForeignKey(d => d.FkSongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SongText_Song");
            });
        }
    }
}
