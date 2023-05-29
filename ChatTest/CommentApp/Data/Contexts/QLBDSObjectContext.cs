using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CommentApp.Data.Mappings;
using CommentApp.Domain;
using CommentApp.Domain.Entities;

namespace CommentApp.Data.Contexts
{
    public class QLBDSObjectContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public QLBDSObjectContext(DbContextOptions<QLBDSObjectContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public QLBDSObjectContext(DbContextOptions<QLBDSObjectContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostMapping());
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new CommentMapping());
            modelBuilder.ApplyConfiguration(new ReplyMapping());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConnectionString"));
            }
        }
    }
}
