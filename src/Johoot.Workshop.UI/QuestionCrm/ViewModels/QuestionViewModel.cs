using Johoot.Data;
using System.ComponentModel.DataAnnotations;

namespace Johoot.Workshop.QuestionCrm.ViewModels
{
  public class QuestionViewModel
  {
    public QuestionViewModel() : base()
    {
    }

    public long Id { get; set; }

    public Quize Quize { get; set; }
    public long QuizeId { get; set; }
    [Required]
    [MinLength(1)]
    public string Text { get; set; }
    [Required]
    public int Points { get; set; } = 100;
    [Required]
    public int TimeLimitSeconds { get; set; } = 30;
    //public List<Answer> Answers { get; set; }

    public bool HasCorrectAnswer { get; set; }
    public bool IsOpenQuestion { get; set; }

    //public string ImageUri { get; set; }
  }
}