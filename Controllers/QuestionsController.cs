﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionsAndAnswers.Data;
using QuestionsAndAnswers.Models;
using QuestionsAndAnswers.Models.ViewModels;
using QuestionsAndAnswers.Services;

namespace QuestionsAndAnswers.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly QuestionsAndAnswersContext _context;
        private readonly QuestionService _questionsService;
        private readonly SignInManager<User> _signInManager;

        public QuestionsController(
            QuestionsAndAnswersContext context, 
            QuestionService questionsService,
            SignInManager<User> signInManager)
        {
            _context = context;
            _questionsService = questionsService;
            _signInManager = signInManager;
        }

        // GET: Questions
        public async Task<IActionResult> Index(string title)
        {
            @ViewData["SearchString"] = title;
            var questions = await _questionsService.SelectByTitleAsync(title);

            var viewModel = new QuestionViewModel()
            {
                Questions = questions.ToList()
            };

            return View(viewModel);
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            var alreadyLogged = _signInManager.IsSignedIn(User);
            return alreadyLogged ? View() : Redirect("/SignUp");
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,InsertedAt,UpdatedAt")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Description,InsertedAt,UpdatedAt")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var question = await _context.Question.FindAsync(id);
            if (question != null)
            {
                _context.Question.Remove(question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(long id)
        {
            return _context.Question.Any(e => e.Id == id);
        }
    }
}
