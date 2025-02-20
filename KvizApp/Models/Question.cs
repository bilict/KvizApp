namespace KvizApp.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty; // Initialize as empty string
    public List<Option> Options { get; set; } = new(); // Initialize as an empty list
    public int CorrectOptionId { get; set; }
}


