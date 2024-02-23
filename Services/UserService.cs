using Microsoft.EntityFrameworkCore;
using QuestionsAndAnswers.Data;

namespace QuestionsAndAnswers.Services
{
    public class UserService
    {
        private readonly QuestionsAndAnswersContext _context;

        public UserService(QuestionsAndAnswersContext context)
        {
            _context = context;
        }

        public async Task<string?> SelectImagePathByUserNameAsync(string userName)
        {
            return await _context.User.Where(user => user.UserName == userName).Select(user => user.ImageName).FirstOrDefaultAsync();
        }
    }
}
