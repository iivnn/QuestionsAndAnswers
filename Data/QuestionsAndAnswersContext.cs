using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuestionsAndAnswers.Models;
using QuestionsAndAnswers.Models.Interfaces;

namespace QuestionsAndAnswers.Data
{
    public class QuestionsAndAnswersContext : IdentityDbContext<User>
    {
        public QuestionsAndAnswersContext(DbContextOptions<QuestionsAndAnswersContext> options)
            : base(options)
        {
            ChangeTracker.StateChanged += UpdateTimestamps!;
            ChangeTracker.Tracked += UpdateTimestamps!;
        }

        override public DbSet<User> Users { get; set; } = default!;
        public DbSet<Question> Questions { get; set; } = default!;
        public DbSet<Tag> Tags { get; set; } = default!;
        public DbSet<Answer> Answers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(e => e.FollowedTags)
                .WithMany(e => e.Users)
                .UsingEntity(j =>
                {
                    j.IndexerProperty<long>("Id");
                    j.HasKey("Id");
                });

            base.OnModelCreating(builder);
        }

        private static void UpdateTimestamps(object sender, EntityEntryEventArgs e)
        {
            if (e.Entry.Entity is IHasTimestamps entityWithTimestamps)
            {
                switch (e.Entry.State)
                {
                    case EntityState.Deleted:
                        entityWithTimestamps.Deleted = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entityWithTimestamps.Modified = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entityWithTimestamps.Added = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}
