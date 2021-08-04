// <copyright file="ITeamService.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        void AddTeamMember(string name);

        TeamInfo GetTeamInfo();
    }
}