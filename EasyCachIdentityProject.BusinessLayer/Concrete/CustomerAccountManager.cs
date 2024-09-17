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
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public CustomerAccount GetById(int id)
        {
            return _customerAccountDal.GetById(id);
        }

        public void TDelete(CustomerAccount entity)
        {
            _customerAccountDal.Delete(entity);
        }

        public List<CustomerAccount> TGetAll()
        {
            return _customerAccountDal.GetAll();
        }

        public List<CustomerAccount> TGetCustomerAccountsList(int Id)
        {
            return _customerAccountDal.GetCustomerAccountsList(Id);
        }

        public void TInsert(CustomerAccount entity)
        {
            _customerAccountDal.Add(entity);
        }

        public void TUpdate(CustomerAccount entity)
        {
            _customerAccountDal.Update(entity);
        }
    }
}
