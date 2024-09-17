using EasyCachIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCachIdentityProject.BusinessLayer.Abstract
{
    public interface ICustomerAccountProcessService : IGenericService<CustomerAccountProcess>
    {
        public List<CustomerAccountProcess> TMyLastProcess(int Id);
    }
}
