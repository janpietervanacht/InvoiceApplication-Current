using Model;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ICountryRepository
    {
        List<Country> GetAll(); // For Admin
        Country getCountryByIsoCode(string landcodeIso);
    }
}