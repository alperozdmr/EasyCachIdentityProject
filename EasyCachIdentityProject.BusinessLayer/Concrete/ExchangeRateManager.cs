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
    public class ExchangeRateManager : IExchangeRateService
    {
        private readonly IExchangeRateDal _exchangeRateDal;

        public ExchangeRateManager(IExchangeRateDal exchangeRateDal)
        {
            _exchangeRateDal = exchangeRateDal;
        }

        public ExchangeRate GetById(int id)
        {
            return _exchangeRateDal.GetById(id);
        }

        public void TDelete(ExchangeRate entity)
        {
            _exchangeRateDal.Delete(entity);
        }

        public List<ExchangeRate> TGetAll()
        {
            return _exchangeRateDal.GetAll();
        }

        public void TInsert(ExchangeRate entity)
        {
            _exchangeRateDal.Add(entity);
        }

        public void TUpdate(ExchangeRate entity)
        {
            _exchangeRateDal.Update(entity);
        }
    }
}
