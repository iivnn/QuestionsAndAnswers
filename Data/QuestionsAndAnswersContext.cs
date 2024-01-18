using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestionsAndAnswers.Models;

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
