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
            teamService.DeleteTeamMember(3);
            //Assert
            Assert.Equal(4, teamService.GetTeamInfo().TeamMembers.Count);

        }

<<<<<<< HEAD:HelloWorldWeb.Tests/HelloWorldWebUnitTest1.cs

        [Fact]
        public void EditTeamMemberInTheTeam()
=======
        [Fact]
        public void EditTeamMemberFromTheTeam()
>>>>>>> 8636a83df7953b80bda3405efad7c75d8db2b662:HelloWorldWeb.Tests/TeamServiceTest1.cs
        {
            //Assume
            ITeamService teamService = new TeamService();
            //Act
<<<<<<< HEAD:HelloWorldWeb.Tests/HelloWorldWebUnitTest1.cs
            teamService.EditTeamMember(3, "NewName");
            //Assert
            Assert.Equal("NewName", teamService.GetTeamMemberById(3).Name);


=======
            teamService.EditTeamMember(3,"NewName");
            //Assert
            Assert.Equal("NewName", teamService.GetTeamMemberById(3).Name);

>>>>>>> 8636a83df7953b80bda3405efad7c75d8db2b662:HelloWorldWeb.Tests/TeamServiceTest1.cs
        }

    }
}