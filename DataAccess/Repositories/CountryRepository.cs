using DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        readonly ApplicDbContext.DatabaseContext _dbContext;
        readonly ILogger<CountryRepository> _logger;

        readonly string dbgPref = "debug niveau: ";
        readonly string errPref = "error niveau:  ";
        readonly string infoPref = "info niveau: : ";
        readonly string warnPref = "warning niveau:  ";

        public CountryRepository(ApplicDbContext.DatabaseContext dbContext, ILogger<CountryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public List<Country> GetAll()
        {
            var result = _dbContext.Countries.ToList();
            return result; 
        }

        public Country getCountryByIsoCode(string landcodeIso)
        {
            if (landcodeIso == null)
            {
                return null; 
            }
            else
            {
                var result = _dbContext.Countries.SingleOrDefault(c => c.CountryIsoCode == landcodeIso);
                return result; 
            }
        }
    }
}
