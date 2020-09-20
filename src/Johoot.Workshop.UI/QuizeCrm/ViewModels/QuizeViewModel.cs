using Johoot.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Johoot.Workshop.UI.QuizeCrm.ViewModels
{
  public class QuizeViewModel
  {
    public long Id { get; set; }
    [Required]
    [MinLength(1)]
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Question> Questions { get; set; }
  }
}
