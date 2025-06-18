[Route("login")]
public class LoginController : Controller
{
    [Route("")]
    public IActionResult Index() => View();

    [Route("admin")]
    public IActionResult AdminLogin() => View();

    [Route("trainer")]
    public IActionResult TrainerLogin() => View();

    [Route("learner")]
    public IActionResult LearnerLogin() => View();
}
