using Johoot.Workshop.QuestionCrm.ViewModels;
using Johoot.Workshop.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Johoot.Workshop.QuizeCrm.Pages
{
  public class QuestionEditBase : ComponentBase
  {
    [Inject]
    public IQuestionService Service { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public long? QuestionId { get; set; }
    [Parameter]
    public long? QuizeId { get; set; }
    public QuestionViewModel Question { get; set; } = new QuestionViewModel();

    protected bool Saved;
    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;


    protected override async Task OnInitializedAsync()
    {

      if (!QuestionId.HasValue || QuestionId.Value == 0) //new Question is being created
      {
        //add some defaults
        Question = new QuestionViewModel { Id = 0 };
      }
      else
      {
        Question = await Service.GetById(QuestionId.Value);
      }
    }

    protected async Task HandleValidSubmit()
    {
      Saved = false;


      if (Question.Id == 0) //new
      {
        Question.QuizeId = QuizeId.Value;
        var addedQuize = await Service.Create(Question);
        if (addedQuize != null)
        {
          //StatusClass = "alert-success";
          //Message = "New Quize added successfully.";
          Saved = true;
          if (addedQuize.Id > 0)
          {
            Question = addedQuize;
            NavigateToOverview();
          }
        }
        else
        {
          Question.QuizeId = Question.Quize.Id;
          StatusClass = "alert-danger";
          Message = "Something went wrong adding the new Quize. Please try again.";
          Saved = false;
        }
      }
      else
      {
        await Service.Update(Question);
        //StatusClass = "alert-success";
        //Message = "Quize updated successfully.";
        Saved = true;
        NavigateToOverview();
      }
    }
    //protected async Task DeleteQuize()
    //{
    //  await QuizeService.DeleteEmployee(Quize.Id);

    //  StatusClass = "alert-success";
    //  Message = "Deleted successfully";

    //  Saved = true;
    //}


    protected void NavigateToOverview()
    {
      NavigationManager.NavigateTo($"/questiondetail/{Question.Id}");
    }
  }
}
