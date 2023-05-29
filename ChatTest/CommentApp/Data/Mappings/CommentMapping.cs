using CommentApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommentApp.Data.Mappings
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Content).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();

            builder.HasOne(c => c.Post)
                   .WithMany(p => p.Comments)
                   .HasForeignKey(c => c.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Account)
                   .WithMany()
                   .HasForeignKey(c => c.AccountId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
