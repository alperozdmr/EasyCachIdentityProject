﻿using Microsoft.AspNetCore.Mvc;

namespace EasyCachIdentityProject.Presentation.ViewComponents.Customer
{
    public class _CustomerLayoutHeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
