using DWC.Blazor.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWC.Blazor.Pages
{
    public partial class Index
    {
        public List<Developer> DeveloperList { get; set; } = new List<Developer>();
        private SearchParameter searchParameter = new SearchParameter();
        //private readonly IHttpDeveloperRepository _httpDeveloperRepository;
        //public Index(IHttpDeveloperRepository httpDeveloperRepository)
        //{
        //    _httpDeveloperRepository = httpDeveloperRepository;
        //}
        protected override async Task OnInitializedAsync()
        {
            await GetDevelopers();
        }
        private async Task GetDevelopers()
        {
            var pagingResponse = await /*_httpDeveloperRepository.GetDevelopers();*/GetDevelopersAux();
            DeveloperList = pagingResponse.Developers;
        }
        private async Task SearchAction(string searchTerm)
        {
            searchParameter.SearchTerm = searchTerm;
            var pagingResponse = await /*_httpDeveloperRepository.GetDevelopersByNameOrSkill(searchParameter);*/ GetDevelopersSearch(searchParameter);
            DeveloperList = pagingResponse.Developers;
        }

        public async Task<PagingResponse<Developer>> GetDevelopersSearch(SearchParameter searchParameters)
        {
            var developers = await Http.GetJsonAsync<List<Developer>>("data/developers.json");
            var pagingResponse = new PagingResponse<Developer>
            {
                Developers = developers.Where(dev => dev.Name.ToLower().Contains(searchParameters.SearchTerm.ToLower()) || dev.Skills.ToLower().Contains(searchParameters.SearchTerm.ToLower())).ToList()
            };
            return pagingResponse;
        }

        public async Task<PagingResponse<Developer>> GetDevelopersAux()
        {
            var developers = await Http.GetJsonAsync<List<Developer>>("data/developers.json");
            var pagingResponse = new PagingResponse<Developer>
            {
                Developers = developers.ToList()
            };

            return pagingResponse;
        }
    }
}