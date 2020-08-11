using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DWC.Blazor.Repository
{
    public class HttpDeveloperRepository : IHttpDeveloperRepository
    {
        private readonly HttpClient _client;

        public HttpDeveloperRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<PagingResponse<Developer>> GetDevelopers()
        {
            var developers = await _client.GetJsonAsync<List<Developer>>("data/developers.json");
            var pagingResponse = new PagingResponse<Developer>
            {
                Developers = developers
            };

            return pagingResponse;
        }

        public async Task<PagingResponse<Developer>> GetDevelopersByNameOrSkill(SearchParameter searchParameters)
        {
            var developers = await _client.GetJsonAsync<List<Developer>>("data/developers.json");
            var pagingResponse = new PagingResponse<Developer>
            {
                Developers = developers.Where(dev => dev.Name.ToLower().Contains(searchParameters.SearchTerm.ToLower()) || dev.Skills.ToLower().Contains(searchParameters.SearchTerm.ToLower())).ToList()
            };

            return pagingResponse;
        }
    }
}
