using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCachIdentityProject.EntityLayer.Concrete
{
    public class ExchangeRate 
    {
        public int Id { get; set; } = 0;
        public string? Isim { get; set; }
        public string? CurrencyCode { get; set; }
        public int Unit { get; set; }
        public string? CurrencyName { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
        public decimal BanknoteBuying { get; set; }
        public decimal BanknoteSelling { get; set; }
    }
}
