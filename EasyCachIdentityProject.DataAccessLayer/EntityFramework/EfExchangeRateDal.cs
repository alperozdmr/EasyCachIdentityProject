using EasyCachIdentityProject.DataAccessLayer.Abstract;
using EasyCachIdentityProject.DataAccessLayer.Repositories;
using EasyCachIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCachIdentityProject.DataAccessLayer.EntityFramework
{
    public class EfExchangeRateDal :GenericRepository<ExchangeRate>,IExchangeRateDal
    {
    }
}
