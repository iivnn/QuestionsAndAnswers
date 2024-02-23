﻿using Microsoft.EntityFrameworkCore;
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
            return await _context.Tag.ToListAsync();
        }

        public async Task<IEnumerable<Tag>> SelectTagByIdsAsync(params int[] id)
        {
            return await _context.Tag.Where(tag => id.Contains(tag.Id)).ToListAsync();
        }
    }
}
