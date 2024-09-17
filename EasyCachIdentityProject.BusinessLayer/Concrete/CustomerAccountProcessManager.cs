using EasyCachIdentityProject.BusinessLayer.Abstract;
using EasyCachIdentityProject.DataAccessLayer.Abstract;
using EasyCachIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCachIdentityProject.BusinessLayer.Concrete
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal _customerAccountProcessDal;

        public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
        {
            _customerAccountProcessDal = customerAccountProcessDal;
        }

        public CustomerAccountProcess GetById(int id)
        {
            return _customerAccountProcessDal.GetById(id);
        }

        public void TDelete(CustomerAccountProcess entity)
        {
            _customerAccountProcessDal.Delete(entity);
        }

        public List<CustomerAccountProcess> TGetAll()
        {
            return _customerAccountProcessDal.GetAll(); 
        }

        public void TInsert(CustomerAccountProcess entity)
        {
            _customerAccountProcessDal.Add(entity);
        }

        public List<CustomerAccountProcess> TMyLastProcess(int Id)
        {
            return _customerAccountProcessDal.MyLastProcess(Id);
        }

        public void TUpdate(CustomerAccountProcess entity)
        {
            _customerAccountProcessDal.Update(entity);
        }
    }
}
