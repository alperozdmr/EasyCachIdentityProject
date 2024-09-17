using Microsoft.AspNetCore.Mvc;

namespace EasyCachIdentityProject.Presentation.ViewComponents.Customer
{
    public class _CustomerLayoutScriptPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
