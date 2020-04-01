using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch02MiniWeb.Model;

namespace Ch02MiniWeb.Repository
{
    interface ICountryRespository
    {
        IQueryable<Country> All();
        Country Find(string code);
        IQueryable<Country> AllBy(string filter);
    }
}
