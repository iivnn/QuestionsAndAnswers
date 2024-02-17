using Microsoft.EntityFrameworkCore;
using QuestionsAndAnswers.Data;
using QuestionsAndAnswers.Models;

namespace QuestionsAndAnswers.Services
{
    public class QuestionsService
    {
        private readonly QuestionsAndAnswersContext _context;

        public QuestionsService(QuestionsAndAnswersContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> SelectByTitleAsync(string title)
        {
            return await _context.Question.Where(x => string.IsNullOrEmpty(title) || x.Title.Contains(title))
                .Include(x => x.Tag).ToListAsync();
        }
    }
}
