using KvizApp.Data;
using KvizApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase {
    private readonly ApplicationDbContext _context;

    public QuestionsController(ApplicationDbContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetQuestions() {
        var questions = await _context.Questions.Include(q => q.Options).ToListAsync();
        return Ok(questions);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddQuestion([FromBody] Question question) {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetQuestions), new { id = question.Id }, question);
    }
}