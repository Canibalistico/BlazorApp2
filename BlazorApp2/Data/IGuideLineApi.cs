using BlazorApp2.Models;
using Microsoft.AspNetCore.Http.Timeouts;
using Refit;

namespace BlazorApp2.Data
{
    public interface IGuideLineApi
    {
        [Get("/api/templates")]
        [DisableRequestTimeout]
        Task<List<GuideLineTemplate>> GetTemplatesAsync();

        [Get("/api/templates/{id}")]
        Task<GuideLineTemplate> GetTemplateAsync(int id);
    }
}
