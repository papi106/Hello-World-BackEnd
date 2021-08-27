// <copyright file="TeamService.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using HelloWorldWebApp.Services;
using Microsoft.AspNetCore.SignalR;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;
        private readonly ITimeService timeService;
        private readonly IBroadcastService broadcastService;

        public TeamService(IBroadcastService broadcastService)
        {
            this.broadcastService = broadcastService;

            this.teamInfo = new TeamInfo
            {
                Name = "Team 1",
                TeamMembers = new List<TeamMember>(),
            };

            string[] teamMembersData = new string[]
           {
                "Ema",
                "Sorina",
                "Fineas",
                "Patrick",
                "Radu P.",
                "Tudor",
           };

            foreach (string name in teamMembersData)
            {
                AddTeamMember(name);
            }
        }

        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public void DeleteTeamMember(int id)
        {
            TeamMember member = GetTeamMemberById(id);
            teamInfo.TeamMembers.Remove(member);
            this.broadcastService.DeleteTeamMember(id);
        }

        public int AddTeamMember(string name)
        {

            TeamMember newMember = new(name, timeService);

            teamInfo.TeamMembers.Add(newMember);

            broadcastService.NewTeamMemberAdded(newMember.Name, newMember.Id);

            return newMember.Id;
			
        }

        public void EditTeamMember(int id, string name)
        {
            TeamMember member = GetTeamMemberById(id);
            member.Name = name;

            broadcastService.EditTeamMember(name, id);
        }

        public TeamMember GetTeamMemberById(int id)
        {
            return teamInfo.TeamMembers.Find(x => x.Id == id);
        }

        public void SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public int AddTeamMember(TeamMember member)
        {
            int id = teamInfo.TeamMembers.Max(memmber => member.Id) + 1;
            member.Id = id;
            this.teamInfo.TeamMembers.Add(member);
            return member.Id;
        }
    }
}