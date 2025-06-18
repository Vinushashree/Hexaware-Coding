using Microsoft.AspNetCore.Mvc;

[Route("learner")]
public class LearnerController : Controller
{
    [Route("dashboard")]
    public IActionResult Dashboard() => View();

    [Route("profile")]
    public IActionResult UpdateProfile() => View();

    [Route("search")]
    public IActionResult SearchContent() => View();

    [Route("logout")]
    public IActionResult Logout() => RedirectToAction("Index", "Home");
}

