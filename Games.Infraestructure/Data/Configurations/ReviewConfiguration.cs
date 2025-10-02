using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gamess.Core.Entities;

namespace Games.Infrastructure.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id).HasName("PK_Review");

            builder.ToTable("Review");

            builder.Property(r => r.Content)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(r => r.Score)
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .IsRequired();

            builder.Property(r => r.IsActive)
                .IsRequired();

            // Relaciones
            builder.HasOne(r => r.Game)
                .WithMany(g => g.Reviews)
                .HasForeignKey(r => r.GameId)
                .HasConstraintName("FK_Review_Game");

            builder.HasOne(r => r.User)
                .WithMany(u => u.Review)
                .HasForeignKey(r => r.UserId)
                .HasConstraintName("FK_Review_User");
        }
    }
}
