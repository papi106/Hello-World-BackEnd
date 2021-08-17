// <copyright file="ITeamService.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        int AddTeamMember(string name);

        TeamInfo GetTeamInfo();

        void DeleteTeamMember(int id);

        void EditTeamMember(int id, string name);

        TeamMember GetTeamMemberById(int id);
        void SaveChangesAsync();
        void Add(string name);
        void Add(TeamMember teamMember);
    }
}