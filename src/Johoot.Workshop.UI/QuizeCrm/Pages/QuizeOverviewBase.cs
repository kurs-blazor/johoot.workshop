using Johoot.Workshop.UI.QuizeCrm.Services;
using Johoot.Workshop.UI.QuizeCrm.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Workshop.QuizeCrm.Pages
{
  public class QuizeOverviewBase : ComponentBase
  {
    [Inject]
    public IQuizeService QuizeService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public IList<QuizeViewModel> Quizes { get; set; }
    protected override async Task OnInitializedAsync()
    {
      Quizes = await QuizeService.GetAll(true);
    }
    public void CreateQuize()
    {
      NavigationManager.NavigateTo($"/quizeedit/0");
    }
  }
}
