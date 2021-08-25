// <copyright file="TeamMember.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using HelloWorldWeb.Services;
using System;
using System.Diagnostics;

namespace HelloWorldWeb.Models
{
    [DebuggerDisplay("{Name}[{Id}]")]
    public class TeamMember
    {

        private static int idCount = 0;
        private readonly ITimeService timeService;

        public TeamMember()
        {
        }

        public TeamMember(string name, ITimeService timeService)
        {
            Id = idCount++;
            Name = name;

            this.timeService = timeService;
        }

        public int Id { get; set; }

        public string Name { get; set; }
		
        public DateTime BirthDate { get; set; }

        public int GetAge()
        {
            var age = DateTime.Now.Subtract(BirthDate).Days;
            age /= 365;

            return age;
        }
    }
}