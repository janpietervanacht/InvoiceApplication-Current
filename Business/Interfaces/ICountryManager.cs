using System.Collections.Generic;
using Model;

namespace Business.Interfaces
{
    public interface ICountryManager
    {
        List<Country> GetAll();
    }
}