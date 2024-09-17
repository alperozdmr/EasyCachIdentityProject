using EasyCachIdentityProject.DataAccessLayer.Abstract;
using EasyCachIdentityProject.DataAccessLayer.Concrete;
using EasyCachIdentityProject.DataAccessLayer.Repositories;
using EasyCachIdentityProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCachIdentityProject.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
        public List<CustomerAccountProcess> MyLastProcess(int Id)
        {
            using var context = new Context();
            var values = context.CustomerAccountsProcesses.Include(y=>y.SenderCustomer).Include(w=>w.ReceiverCustomer).ThenInclude(z=>z.AppUser).Where(x => x.ReceiverID == Id || x.SenderID == Id).ToList(); 
            return values;
        }
    }
}
