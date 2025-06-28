[Route("admin")]
public class AdminController : Controller
{
    [Route("dashboard")]
    public IActionResult Dashboard() => View();

    [Route("profile")]
    public IActionResult UpdateProfile() => View();

    [Route("courses")]
    public IActionResult ManageCourses() => View();

    [Route("trainers")]
    public IActionResult ManageTrainers() => View();

    [Route("learners")]
    public IActionResult ManageLearners() => View();

    [Route("logout")]
    public IActionResult Logout() => RedirectToAction("Index", "Home");
}

