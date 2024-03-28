using Microsoft.EntityFrameworkCore;
using QuestionsAndAnswers.Data;
using QuestionsAndAnswers.Models;

namespace QuestionsAndAnswers.Services
{
    public class TagService
    {
        private readonly QuestionsAndAnswersContext _context;

        public TagService(QuestionsAndAnswersContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> SelectAllAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<IEnumerable<Tag>> SelectByIdsAsync(params int[] id)
        {
            return await _context.Tags.Where(tag => id.Contains(tag.Id)).ToListAsync();
        }

        public async Task<Tag?> SelectByNameAsync(string name)
        {
            return await _context.Tags.FirstOrDefaultAsync(tag => tag.Name == name);
        }
    }
}
