using EntityFramework.Applications.CompanyServices;
using EntityFramework.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace EntityFramework.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EntityController : ControllerBase 
    {
        private readonly ICompanyService _companyService;

        public EntityController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<string> CreateCompanyAsync(Company model)
        {
            var result = await _companyService.CreateCompanyAsync(model);

            return result;
        }

        [HttpGet]
        public async Task<List<Company>> GetAllCompanies()
        {
            var result = await _companyService.GetAllCompanyAsync();
            
            return result;
        }

        [HttpGet]
        public async Task<Company> GetCompanyById(int id)
        {
            var result = await _companyService.GetByIdCompanyAsync(id);
            
            return result;
        }

        [HttpGet]
        public async Task<Company> GetCompanyByName(string name)
        {
            var result = await _companyService.GetByNameCompanyAsync(name);

            return result;
        }

        [HttpPut]
        public async Task<Company> UpdateCompaniesById(int id, Company model)
        {
            var result = await _companyService.UpdateCompanyAsync(id, model);

            return result;
        }

        [HttpDelete]
        public async Task<string> DeleteCompanyById(int id)
        {
            var result = await _companyService.DeleteCompanyAsync(id);

            return result;
        }
    }
}
