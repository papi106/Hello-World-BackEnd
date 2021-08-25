// <copyright file="ITeamService.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        int AddTeamMember(TeamMember member);

        public void DeleteTeamMember(int id);

        public void EditTeamMember(int id, string name);
        
        TeamInfo GetTeamInfo();

        TeamMember GetTeamMemberById(int id);
        void SaveChangesAsync();
        void Add(string name);
        void Add(TeamMember teamMember);
    }
}