using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using QuestionsAndAnswers.Models;

namespace QuestionsAndAnswers.Data
{
    public class QuestionsAndAnswersContext : DbContext
    {
        public QuestionsAndAnswersContext(DbContextOptions<QuestionsAndAnswersContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Tags)
                .WithMany()
                .UsingEntity(j =>
                {
                    j.IndexerProperty<long>("Id");
                    j.HasKey("Id");
                    j.Property<DateTime>("CreatedAt").HasDefaultValueSql("CURRENT_TIMESTAMP");
                })
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Tags)
                .WithMany(t => t.Questions)
                .UsingEntity(j =>
                {
                    j.IndexerProperty<long>("Id");
                    j.HasKey("Id");
                    j.Property<DateTime>("CreatedAt").HasDefaultValueSql("CURRENT_TIMESTAMP");
                })
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Tag>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");
        }

        public DbSet<User> User { get; set; } = default!;
        public DbSet<Question> Question { get; set; } = default!;
        public DbSet<Tag> Tag { get; set; } = default!;
    }
}
