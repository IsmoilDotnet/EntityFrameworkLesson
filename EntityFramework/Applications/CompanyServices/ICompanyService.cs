using EntityFramework.Models;

namespace EntityFramework.Applications.CompanyServices
{
    public interface ICompanyService
    {
        public Task<string> CreateCompanyAsync(Company model);
        public Task<Company> UpdateCompanyAsync(int id, Company model);
        public Task<string> DeleteCompanyAsync(int id);
        public Task<List<Company>> GetAllCompanyAsync();
        public Task<Company> GetByIdCompanyAsync(int id);
        public Task<Company> GetByNameCompanyAsync(string name);
    }
}
