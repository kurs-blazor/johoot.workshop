using Johoot.Workshop.UI.QuizeCrm.Services;
using Johoot.Workshop.UI.QuizeCrm.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Johoot.QuizeCrm.Pages
{
  public class QuizeEditBase : ComponentBase
  {
    [Inject]
    public IQuizeService QuizeService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string QuizeId { get; set; }

    public QuizeViewModel Quize { get; set; } = new QuizeViewModel();

    protected bool Saved;
    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;


    protected override async Task OnInitializedAsync()
    {

      int.TryParse(QuizeId, out var quizeId);

      if (quizeId == 0) //new Quize is being created
      {
        //add some defaults
        Quize = new QuizeViewModel { Id = 0 };
      }
      else
      {
        Quize = await QuizeService.GetById(quizeId);
      }
    }

    protected async Task HandleValidSubmit()
    {
      Saved = false;

      if (Quize.Id == 0) //new
      {
        var addedQuize = await QuizeService.Create(Quize);
        if (addedQuize != null)
        {
          //StatusClass = "alert-success";
          //Message = "New Quize added successfully.";
          Saved = true;
          if (addedQuize?.Id > 0)
          {
            Quize = addedQuize;
            NavigateToOverview();
          }
        }
        else
        {
          StatusClass = "alert-danger";
          Message = "Something went wrong adding the new Quize. Please try again.";
          Saved = false;
        }
      }
      else
      {
        await QuizeService.Update(Quize);
        //StatusClass = "alert-success";
        //Message = "Quize updated successfully.";
        Saved = true;
        NavigateToOverview();
      }
    }

    protected void NavigateToOverview()
    {
      NavigationManager.NavigateTo($"/quizedetail/{Quize.Id}");
    }
  }
}
