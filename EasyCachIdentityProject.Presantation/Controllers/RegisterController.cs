using EasyCachIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCachIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace EasyCachIdentityProject.Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int code = random.Next(100000, 1000000);

				AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.UserName,
                    Name = appUserRegisterDto.Name.ToUpper(),
                    Surname = appUserRegisterDto.Surname.ToUpper(),
                    Email = appUserRegisterDto.Email,   
                    ConfirmCode= code,
                };
                var result = await _userManager.CreateAsync(appUser,appUserRegisterDto.Password);
                if (result.Succeeded) {
                    //MAİL GÖNDERMA ONAY KODU ALMA TARZI İŞLEMLER BU ŞEKİLDE YAZILIYOR VE NETCore.MailKit Eklentisini kullanmak gerekiyor
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddress = new MailboxAddress("Easy Cash Admin","alozdemir23@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                    mimeMessage.From.Add(mailboxAddress);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için Onay kodunuz:" + code;
                    mimeMessage.Body= bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Easy Cash Onay Kodu";
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com",587,false);
                    smtpClient.Authenticate("alozdemir23@gmail.com", "yyfy vmjh rsla hwgl");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);
                    ///////////////////////////////////// 
                    TempData["Mail"]= appUserRegisterDto.Email; 
                        
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach( var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View();
        }
    }
}
