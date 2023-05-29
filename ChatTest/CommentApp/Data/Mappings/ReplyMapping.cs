using CommentApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommentApp.Data.Mappings
{
    public class ReplyMapping : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.ToTable("Reply");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Content).IsRequired();
            builder.Property(r => r.CreatedAt).IsRequired();

            builder.HasOne(r => r.Comment)
                   .WithMany(c => c.Replies)
                   .HasForeignKey(r => r.CommentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Account)
                   .WithMany()
                   .HasForeignKey(r => r.AccountId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
