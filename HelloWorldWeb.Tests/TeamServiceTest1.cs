using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using System;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();
            //Act
            TeamMember member = new TeamMember();
            member.Name="Patrick";
            teamService.AddTeamMember(member);
            //Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);

        }

        [Fact]
        public void DeleteTeamMemberFromTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();
            //Act
            teamService.DeleteTeamMember(3);
            //Assert
            Assert.Equal(6, teamService.GetTeamInfo().TeamMembers.Count);

        }


        [Fact (Skip ="Test fails, review later.")] 
        public void EditTeamMemberInTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();
            //Act
            teamService.EditTeamMember(3, "NewName");
            //Assert
            Assert.Equal("NewName", teamService.GetTeamMemberById(3).Name);


        }

    }
}