// <copyright file="TeamMember.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using System;

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
        public DateTime BirthDate { get; set; }

        public int GetAge()
        {
            var age = DateTime.Now.Subtract(BirthDate).Days;
            age = age / 365;

            return age;
        }
    }
}