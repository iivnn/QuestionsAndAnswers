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

        public IEnumerable<Question> SelectByTitle(string title)
        {
            return _context.Question.Where(x => string.IsNullOrEmpty(title) || x.Title == title).ToList();
        }

        public async Task<IEnumerable<Question>> SelectByTitleAsync(string title)
        {
            return await _context.Question.Where(x => string.IsNullOrEmpty(title) || x.Title.Contains(title)).ToListAsync();
        }
    }
}
