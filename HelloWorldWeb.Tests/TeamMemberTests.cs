using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamMemberTests
    {
        [Fact]
        public void GettingAge()
        {
            //Assume
            var newTeamMember = new TeamMember("Sergiu");
            newTeamMember.BirthDate = new DateTime(1997, 07, 27);

            //Act
            int age = newTeamMember.GetAge();

            //Assert
            Assert.Equal(24, age);

        }
    }
}
