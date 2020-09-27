using Johoot.Workshop.UI.QuizeCrm.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Johoot.Workshop.UI.QuizeCrm.Services
{
  public class QuizeService : IQuizeService
  {
    private readonly HttpClient _httpClient;

    public QuizeService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<IList<QuizeViewModel>> GetAll(bool includeAll = true)
    {
      string relativeUri = $"?includeAll={includeAll}";
      var uri = new System.Uri(_httpClient.BaseAddress, relativeUri);
      return await JsonSerializer.DeserializeAsync<IList<QuizeViewModel>>(
        await _httpClient.GetStreamAsync(uri),
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<QuizeViewModel> GetById(long id)
    {
      string relativeUri = $"QuizesDefinition/{id}?includeAll=true";
      return await JsonSerializer.DeserializeAsync<QuizeViewModel>(
        await _httpClient.GetStreamAsync(relativeUri),
        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<QuizeViewModel> Create(QuizeViewModel item)
    {
      string relativeUri = $"QuizesDefinition";
      var bodyJson =
             new StringContent(JsonSerializer.Serialize(item),
             Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync(relativeUri, bodyJson);

      if (response.IsSuccessStatusCode)
      {
        return await JsonSerializer.DeserializeAsync<QuizeViewModel>(
          await response.Content.ReadAsStreamAsync(),
          new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
      }

      return null;
    }

    public async Task Update(QuizeViewModel item)
    {
      string relativeUri = $"QuizesDefinition/{item.Id}";
      var bodyJson =
                 new StringContent(JsonSerializer.Serialize(item), 
                 Encoding.UTF8, "application/json");

      await _httpClient.PutAsync(relativeUri, bodyJson);
    }
  }
}
