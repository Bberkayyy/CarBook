using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.RentACarFilterViewComponents;

public class _RentACarFilterComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke(string v)
    {
        v = "asdsadas";
        TempData["value"] = v;
        return View();
    }
}
