// <copyright file="TeamInfo.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace HelloWorldWeb.Models
{
    public class TeamInfo
    {
        public string Name { get; set; }

        public List<TeamMember> TeamMembers { get; set; }
    }
}