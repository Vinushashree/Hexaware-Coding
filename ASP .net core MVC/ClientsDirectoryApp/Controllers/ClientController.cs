using ClientsDirectoryApp.Models;
using Microsoft.AspNetCore.Mvc;

public class ClientController : Controller
{
    static List<ClientInfo> clients = new List<ClientInfo>();

    public IActionResult ShowAllClientDetails()
    {
        return View(clients);
    }

    public IActionResult GetDetailsByClientId(int id)
    {
        var client = clients.FirstOrDefault(c => c.ClientId == id);
        return View("ClientDetails", client);
    }

    public IActionResult GetDetailsByCompanyName(string name)
    {
        var client = clients.FirstOrDefault(c => c.CompanyName == name);
        return View("ClientDetails", client);
    }

    public IActionResult GetDetailsByEmail(string email)
    {
        var client = clients.FirstOrDefault(c => c.Email == email);
        return View("ClientDetails", client);
    }

    public IActionResult GetDetailsByCategory(string category)
    {
        var client = clients.FirstOrDefault(c => c.Category == category);
        return View("ClientDetails", client);
    }

    public IActionResult GetDetailsByStandard(string standard)
    {
        var client = clients.FirstOrDefault(c => c.Standard == standard);
        return View("ClientDetails", client);
    }

    [HttpGet]
    public IActionResult AddClient()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddClient(ClientInfo clientInfo)
    {
        clients.Add(clientInfo);
        return RedirectToAction("ShowAllClientDetails");
    }
}
