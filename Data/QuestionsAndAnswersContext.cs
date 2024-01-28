using Microsoft.EntityFrameworkCore;

namespace QuestionsAndAnswers.Data
{
    public class QuestionsAndAnswersContext : DbContext
    {
        public QuestionsAndAnswersContext (DbContextOptions<QuestionsAndAnswersContext> options)
            : base(options)
        {
        }

        public DbSet<QuestionsAndAnswers.Models.Question> Question { get; set; } = default!;
    }
}
