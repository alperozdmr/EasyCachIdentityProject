using EasyCachIdentityProject.BusinessLayer.Abstract;
using EasyCachIdentityProject.BusinessLayer.Concrete;
using EasyCachIdentityProject.DataAccessLayer.Abstract;
using EasyCachIdentityProject.DataAccessLayer.Concrete;
using EasyCachIdentityProject.DataAccessLayer.EntityFramework;
using EasyCachIdentityProject.EntityLayer.Concrete;
using EasyCachIdentityProject.Presentation.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddScoped<ICustomerAccountProcessDal,EfCustomerAccountProcessDal>();
builder.Services.AddScoped<ICustomerAccountProcessService,CustomerAccountProcessManager>();

builder.Services.AddScoped<ICustomerAccountDal, EfCustomerAccountDal>();
builder.Services.AddScoped<ICustomerAccountService, CustomerAccountManager>();

builder.Services.AddScoped<IExchangeRateDal, EfExchangeRateDal>();
builder.Services.AddScoped<IExchangeRateService, ExchangeRateManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
