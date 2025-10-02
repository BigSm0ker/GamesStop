using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gamess.Core.Entities;

namespace Games.Infrastructure.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id).HasName("PK_Game");

            builder.ToTable("Game");

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(g => g.Genre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(g => g.AgeRating)
                .HasMaxLength(10);

            builder.Property(g => g.CoverUrl)
                .HasMaxLength(500);

            builder.Property(g => g.IsActive)
                .IsRequired();

            // Relaciones
            builder.HasOne(g => g.Uploader)
                .WithMany(u => u.UploadedGames)
                .HasForeignKey(g => g.UploaderUserId)
                .HasConstraintName("FK_Game_User");

            builder.HasMany(g => g.Reviews)
                .WithOne(r => r.Game)
                .HasForeignKey(r => r.GameId)
                .HasConstraintName("FK_Review_Game");
        }
    }
}
