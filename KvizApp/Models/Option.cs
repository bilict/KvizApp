namespace KvizApp.Models;

public class Option
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty; // Initialize as empty string
    public bool IsCorrect { get; set; }
}
