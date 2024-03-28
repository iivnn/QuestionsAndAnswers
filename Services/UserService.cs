using Microsoft.EntityFrameworkCore;
using QuestionsAndAnswers.Data;
using QuestionsAndAnswers.Models;

namespace QuestionsAndAnswers.Services
{
    public class UserService
    {
        private readonly QuestionsAndAnswersContext _context;

        public UserService(QuestionsAndAnswersContext context)
        {
            _context = context;
        }

        public async Task<string?> SelectImageNameByUserNameAsync(string userName)
        {
            return await _context.Users.Where(user => user.UserName == userName).Select(user => user.ImageName).FirstOrDefaultAsync();
        }

        public async Task<User> SelectByUserNameAsync(string userName, bool includeAll = false)
        {
            ArgumentNullException.ThrowIfNull(userName);

#pragma warning disable CS8603 // Possível retorno de referência nula.
            if (includeAll)
                return await _context.Users.Where(user => user.UserName == userName)
                    .Include(user => user.FollowedTags)
                    .Include(user => user.Questions)
                    .FirstOrDefaultAsync();
            else
                return await _context.Users.Where(user => user.UserName == userName).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }
    }
}
