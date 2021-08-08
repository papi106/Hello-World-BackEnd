// <copyright file="TeamService.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 1",
                TeamMembers = new List<TeamMember>(),
            };
            this.AddTeamMember("Ema");
            this.AddTeamMember("Sorina");
            this.AddTeamMember("Fineas");
            this.AddTeamMember("Radu");
            this.AddTeamMember("Tudor");
            this.AddTeamMember("Patrick");
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            Console.WriteLine(id);
            return this.teamInfo.TeamMembers.Find(x => x.Id == id);
        }

        public int AddTeamMember(string name)
        {
            TeamMember member = new (name);
            this.teamInfo.TeamMembers.Add(member);
            return member.Id;
        }

        public void DeleteTeamMember(int id)
        {
            this.teamInfo.TeamMembers.Remove(this.GetTeamMemberById(id));
        }

        public void EditTeamMember(int id, string name)
        {
            this.GetTeamMemberById(id).Name = name;
        }
    }
}