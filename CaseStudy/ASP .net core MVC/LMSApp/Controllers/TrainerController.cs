using Microsoft.AspNetCore.Mvc;

[Route("trainer")]
public class TrainerController : Controller
{
    [Route("dashboard")]
    public IActionResult Dashboard() => View();

    [Route("profile")]
    public IActionResult UpdateProfile() => View();

    [Route("content")]
    public IActionResult ManageContent() => View();

    [Route("logout")]
    public IActionResult Logout() => RedirectToAction("Index", "Home");
}
