using Business.Interfaces;
using DataAccess.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessManagers
{
    public class CountryManager : ICountryManager
    {
        private readonly ICountryRepository _countryRepository;

        // In de constructor geven we alle objecten mee
        // die deze class zelf weer gebruikt. 

        public CountryManager(ICountryRepository countryRepository)
        {
            // Bij Dependency Injection in startup.cs is geregeld
            // dat ICountryRepository slechts één keer (lifetime) een 
            // instantie van CountryRepository aanwijst. 
            _countryRepository = countryRepository;
        }
        
        public List<Country> GetAll()
        {
            var result = _countryRepository.GetAll();
            return result; 
        }
        
    }
}
