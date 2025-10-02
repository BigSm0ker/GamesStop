using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gamess.Core.Entities;

namespace Games.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id).HasName("PK_User");

            builder.ToTable("User");

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Telephone)
                .HasMaxLength(15);

            builder.Property(u => u.IsActive)
                .IsRequired();

            // Relaciones
            builder.HasMany(u => u.UploadedGames)
                .WithOne(g => g.Uploader)
                .HasForeignKey(g => g.UploaderUserId)
                .HasConstraintName("FK_Game_User");

            builder.HasMany(u => u.Review)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .HasConstraintName("FK_Review_User");
        }
    }
}
