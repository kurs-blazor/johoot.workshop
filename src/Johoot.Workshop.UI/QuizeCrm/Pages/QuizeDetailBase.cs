using Johoot.Workshop.UI.QuizeCrm.Services;
using Johoot.Workshop.UI.QuizeCrm.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Johoot.QuizeCrm.Pages
{
  public class QuizeDetailBase : ComponentBase
  {
    [Inject]
    public IQuizeService QuizeService { get; set; }

    [Parameter]
    public long QuizeId { get; set; }
    public QuizeViewModel Quize { get; set; } = new QuizeViewModel();

    protected override async Task OnInitializedAsync()
    {
      Quize = await QuizeService.GetById(QuizeId);
    }
  }
}
