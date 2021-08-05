// <copyright file="HomeController.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using System.Diagnostics;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ILogger<HomeController> _logger;

        // private readonly TeamInfo teamInfo;
        private readonly ITeamService teamService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService)
        {
            this._logger = logger;
            this.teamService = teamService;
        }

        [HttpPost]
        public void AddTeamMember(string teamMember)
        {
            this.teamService.AddTeamMember(teamMember);
        }

        [HttpDelete]
        public void DeleteTeamMember(int index)
        {
            this.teamService.DeleteTeamMember(index);
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamService.GetTeamInfo().TeamMembers.Count;
        }

        public IActionResult Index()
        {
            return this.View(this.teamService.GetTeamInfo());
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}