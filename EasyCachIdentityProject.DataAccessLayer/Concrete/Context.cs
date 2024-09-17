using EasyCachIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCachIdentityProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-AMHHP22\\MSSQLSERVER01;Database=EasyCache;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountsProcesses { get; set; }
        public DbSet<ElectricBill> ElectricBills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerAccountProcess>()
                .HasOne(x => x.SenderCustomer)
                .WithMany(y => y.CustomerSenders)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<CustomerAccountProcess>()
                .HasOne(x=>x.ReceiverCustomer)
                .WithMany(y=>y.CustomerReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(builder);
        }
    }
}
