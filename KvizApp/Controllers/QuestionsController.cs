using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KvizApp.Data;
using KvizApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KvizApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: api/questions
        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            // Fetch questions and include their options.
            var questions = await _context.Questions
                .Include(q => q.Options)
                .ToListAsync();
            return Ok(questions);
        }
        
        // POST: api/questions
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddQuestion([FromBody] Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetQuestions), new { id = question.Id }, question);
        }
    }
}