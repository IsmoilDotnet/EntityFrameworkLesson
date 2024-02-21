using EntityFramework.Infrastructure;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Applications.CompanyServices
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;
        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateCompanyAsync(Company model)
        {

            await _context.Companies.AddAsync(model);
            await _context.SaveChangesAsync();

            return "Malumot Yaratildi";
        }

        public async Task<string> DeleteCompanyAsync(int id)
        {
            var result = _context.Companies.FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                _context.Companies.Remove(result.Result);
                await _context.SaveChangesAsync();
                return "OK!";
            }
            return "Sorry!";
        }

        public Task<List<Company>> GetAllCompanyAsync()
        {
            var companies = _context.Companies.ToListAsync();

            return companies;
        }

        public Task<Company> GetByIdCompanyAsync(int id)
        {
            var result = _context.Companies.FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Task<Company> GetByNameCompanyAsync(string name)
        {
            var result = _context.Companies.FirstOrDefaultAsync(x => x.Name == name);

            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Company> UpdateCompanyAsync(int id, Company model)
        {
            var result = _context.Companies.FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                result.Result.Name = model.Name;
                result.Result.Location = model.Location;
                result.Result.Year = model.Year;

                await _context.SaveChangesAsync();
                return model;
            }
            return null;
        }
    }
}
