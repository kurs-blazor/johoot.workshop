using Johoot.Data;
using Johoot.Workshop.UI.QuizeCrm.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.QuizeCrm.Pages
{
  public class QuizeOverviewBase : ComponentBase
  {
    [Inject]
    public IQuizeService QuizeService { get; set; }
    public IList<Quize> Quizes { get; set; }
    protected override async Task OnInitializedAsync()
    {
      base.OnInitialized();
      Quizes = await QuizeService.GetAll(true);
    }
  }
}
