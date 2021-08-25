// <copyright file="HomeController.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using System.Diagnostics;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using HelloWorldWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITeamService teamService;
        private readonly ITimeService timeService;
        private readonly IBroadcastService broadcastService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService, ITimeService timeService, IBroadcastService broadcastService)
        {
            this.logger = logger;
            this.teamService = teamService;
            this.timeService = timeService;
            this.broadcastService = broadcastService;
        }

        [HttpPost]
        public int AddTeamMember(string name)
        {

            TeamMember member = new TeamMember() { Name = name };

            teamService.AddTeamMember(member);
            broadcastService.NewTeamMemberAdded(member.Name, member.Id);

            return member.Id;

        }

        [HttpDelete]
        public void DeleteTeamMember(int id)
        {
            teamService.DeleteTeamMember(id);
            this.broadcastService.DeleteTeamMember(id);
        }

        [HttpPost]
        public void EditTeamMember(int id, string name)
        {
            teamService.EditTeamMember(id, name);
            broadcastService.EditTeamMember(name, id);
        }

        [HttpGet]
        public int GetCount()
        {
            return teamService.GetTeamInfo().TeamMembers.Count;
        }

        public IActionResult Index()
        {
            return this.View(teamService.GetTeamInfo());
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

        public IActionResult Chat()
        {

            return this.View();
        }
    }
}