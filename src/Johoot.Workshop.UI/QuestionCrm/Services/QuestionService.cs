using AutoMapper;
using Johoot.Workshop.QuestionCrm.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Johoot.Workshop.Services
{
  public class QuestionService : IQuestionService
  {
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly string mainPath = "QuestionsDefinition";

    public QuestionService(HttpClient httpClient, IMapper mapper)
    {
      _httpClient = httpClient;
      _mapper = mapper;      
    }

    public async Task<IList<QuestionViewModel>> GetAll(bool includeAll = true)
    {
      string relativeUri = $"{mainPath}?includeAll={includeAll}";
      return await JsonSerializer.DeserializeAsync<IList<QuestionViewModel>>(
        await _httpClient.GetStreamAsync(relativeUri),
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<IList<QuestionViewModel>> FilterByQuize(
      long quizeId,
      bool includeAll = true)
    {
      string relativeUri = $"{mainPath}/find/{quizeId}?includeAll={includeAll}";
      return await JsonSerializer.DeserializeAsync<IList<QuestionViewModel>>(
        await _httpClient.GetStreamAsync(relativeUri),
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<QuestionViewModel> GetById(long id)
    {
      string relativeUri = $"{mainPath}/{id}?includeAll=true";
      return await JsonSerializer.DeserializeAsync<QuestionViewModel>(
        await _httpClient.GetStreamAsync(relativeUri),
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<QuestionViewModel> Create(QuestionViewModel item)
    {
      string relativeUri = $"{mainPath}";
      var bodyJson =
             new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync(relativeUri, bodyJson);

      if (response.IsSuccessStatusCode)
      {
        return await JsonSerializer.DeserializeAsync<QuestionViewModel>(
          await response.Content.ReadAsStreamAsync(),
          new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
      }

      return null;
    }

    public async Task Update(QuestionViewModel item)
    {
      string relativeUri = $"{mainPath}/{item.Id}";
      var bodyJson =
                 new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

      await _httpClient.PutAsync(relativeUri, bodyJson);
    }

    public async Task<QuestionViewModel> GetVmById(long id)
    {
      return _mapper.Map<QuestionViewModel>(await GetById(id));
    }
  }
}
