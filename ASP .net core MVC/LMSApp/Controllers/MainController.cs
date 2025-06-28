using Microsoft.AspNetCore.Mvc;

[Route("")]
public class MainController : Controller
{
    [Route("")]
    [Route("home")]
    public IActionResult Index() => View();

    [Route("about")]
    public IActionResult About() => View();

    [Route("contact")]
    public IActionResult Contact() => View();
}
