using Johoot.Workshop.QuestionCrm.ViewModels;
using Johoot.Workshop.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Workshop.QuestionCrm.Pages
{
  public class QuestionOverviewBase : ComponentBase
  {
    [Inject]
    public IQuestionService Service { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Parameter]
    public long? QuizeId { get; set; }

    public IList<QuestionViewModel> Questions { get; set; }

    protected override async Task OnInitializedAsync()
    {
      if (QuizeId.HasValue)
      {
        Questions = await Service.FilterByQuize(QuizeId.Value);
      }
      else
      {
        Questions = await Service.GetAll();
      }
    }

    public void CreateQuestion()
    {
      NavigationManager.NavigateTo($"/questionedit/{QuizeId.Value}/0");
    }
  }
}
