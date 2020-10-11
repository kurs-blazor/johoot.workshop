using Johoot.Workshop.QuestionCrm.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Johoot.Workshop.Services
{
  public interface IQuestionService
  {
    Task<IList<QuestionViewModel>> GetAll(bool includeAll = true);
    Task<QuestionViewModel> GetById(long id);
    Task<QuestionViewModel> GetVmById(long id);
    Task<QuestionViewModel> Create(QuestionViewModel item);
    Task Update(QuestionViewModel item);

    Task<IList<QuestionViewModel>> FilterByQuize(
      long quizeId,
      bool includeAll = true);
  }
}