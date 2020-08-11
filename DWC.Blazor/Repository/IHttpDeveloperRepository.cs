using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace DWC.Blazor.Repository
{
    public interface IHttpDeveloperRepository
    {
        Task<PagingResponse<Developer>> GetDevelopers();
        Task<PagingResponse<Developer>> GetDevelopersByNameOrSkill(SearchParameter searchParameters);
    }
}
