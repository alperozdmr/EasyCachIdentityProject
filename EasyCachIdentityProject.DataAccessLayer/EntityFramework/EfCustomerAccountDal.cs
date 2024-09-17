using EasyCachIdentityProject.DataAccessLayer.Abstract;
using EasyCachIdentityProject.DataAccessLayer.Concrete;
using EasyCachIdentityProject.DataAccessLayer.Repositories;
using EasyCachIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCachIdentityProject.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountDal : GenericRepository<CustomerAccount>, ICustomerAccountDal
    {
        public List<CustomerAccount> GetCustomerAccountsList(int Id)
        {
            using var context = new Context();
            var values = context.CustomerAccounts.Where(x=>x.AppUserId == Id).ToList();
            return values;
        }
    }
}
