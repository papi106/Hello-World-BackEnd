using HelloWorldWeb.Services;
using System;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();
            //Act
            teamService.AddTeamMember("Patrick");
            //Assert
            Assert.Equal(6, teamService.GetTeamInfo().TeamMembers.Count);

        }

        [Fact]
        public void DeleteTeamMemberFromTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();
            //Act
            teamService.DeleteTeamMember(2);
            //Assert
            Assert.Equal(4, teamService.GetTeamInfo().TeamMembers.Count);

        }

    }
}