using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers;

public class ExtrasController : Controller
{
    public IActionResult Bs()
    {
        return View();
    }
}