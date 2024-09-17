using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCachIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccount
    {
        public int CustomerAccountId { get; set; }
        public string CustomerAccountNumber { get; set; } = "";
        public string CustomerAccountCurrrency { get; set;} = "";
		public decimal CustomerAccountBalance { get; set;}
        public string BankBranch { get; set;} = "";
		public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } = new();
        public List<CustomerAccountProcess> CustomerSenders { get; set; }
        public List<CustomerAccountProcess> CustomerReceiver  { get; set; }
    }
}
