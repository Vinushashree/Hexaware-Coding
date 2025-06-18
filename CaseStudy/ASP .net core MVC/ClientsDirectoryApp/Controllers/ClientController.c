using ClientsDirectoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ClientsDirectoryApp.Controllers
{
    [Route("client")]
    public class ClientController : Controller
    {
        static List<ClientInfo> clients = new List<ClientInfo>();

        [Route("all")]
        public IActionResult ShowAllClientDetails()
        {
            return View(clients);
        }

        [Route("id/{id}")]
        public IActionResult GetDetailsByClientId(int id)
        {
            var client = clients.FirstOrDefault(c = > c.ClientId == id);
            return View("ClientDetails", client);
        }

        [Route("name/{name}")]
        public IActionResult GetDetailsByCompanyName(string name)
        {
            var client = clients.FirstOrDefault(c = > c.CompanyName == name);
            return View("ClientDetails", client);
        }

        [Route("email/{email}")]
        public IActionResult GetDetailsByEmail(string email)
        {
            var client = clients.FirstOrDefault(c = > c.Email == email);
            return View("ClientDetails", client);
        }

        [Route("category/{category}")]
        public IActionResult GetDetailsByCategory(string category)
        {
            var client = clients.FirstOrDefault(c = > c.Category == category);
            return View("ClientDetails", client);
        }

        [Route("standard/{standard}")]
        public IActionResult GetDetailsByStandard(string standard)
        {
            var client = clients.FirstOrDefault(c = > c.Standard == standard);
            return View("ClientDetails", client);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddClient(ClientInfo clientInfo)
        {
            clients.Add(clientInfo);
            return RedirectToAction("ShowAllClientDetails");
        }
    }
}

