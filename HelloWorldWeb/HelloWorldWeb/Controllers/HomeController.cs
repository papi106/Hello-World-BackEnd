using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TeamInfo teamInfo;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            teamInfo = new TeamInfo();
            teamInfo.Name = "Team 1";
            teamInfo.TeamMembers = new List<string>();
            teamInfo.TeamMembers.Add("Emma");
            teamInfo.TeamMembers.Add("Fineas");
            teamInfo.TeamMembers.Add("Radu P");
            teamInfo.TeamMembers.Add("Tudor");
            teamInfo.TeamMembers.Add("Patrick");

        }

        public IActionResult Index()
        {
            return View(teamInfo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
