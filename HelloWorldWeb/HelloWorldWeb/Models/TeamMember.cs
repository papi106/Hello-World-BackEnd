// <copyright file="TeamMember.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        private static int idCount = 0;

        public TeamMember(string name)
        {
            this.Id = idCount;
            this.Name = name;
            idCount++;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}