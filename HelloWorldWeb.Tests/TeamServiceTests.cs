using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.SignalR;
using Moq;
using Xunit;

/*namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        private readonly ITimeService timeService = null;
        private Mock<IHubContext<MessageHub>> messageHub = null;

        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());

            // Act
            teamService.AddTeamMember(new Models.TeamMember("Patrick", timeService));

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void DeleteTeamMemberFromTheTeam()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());
            int idCount = TeamMember.GetIdCounter();

            // Act
            teamService.DeleteTeamMember(idCount);

            // Assert
            Assert.Null(teamService.GetTeamMemberById(idCount));
        }


        [Fact]
        public void EditTeamMemberInTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());
            var targetTeamMember = teamService.GetTeamInfo().TeamMembers[0];
            var memberId = targetTeamMember.Id;

            //Act
            teamService.EditTeamMember(memberId, "NewName");

            //Assert
            Assert.Equal("NewName", teamService.GetTeamMemberById(memberId).Name);

        }

        private void InitializeMessageHubMock()
        {
            // https://www.codeproject.com/Articles/1266538/Testing-SignalR-Hubs-in-ASP-NET-Core-2-1
            Mock<IClientProxy> hubAllClients = new();
            Mock<IHubClients> hubClients = new();
            hubClients.Setup(_ => _.All).Returns(hubAllClients.Object);
            messageHub = new Mock<IHubContext<MessageHub>>();



            messageHub.SetupGet(_ => _.Clients).Returns(hubClients.Object);
        }

        private IHubContext<MessageHub> GetMockedMessageHub()
        {
            if (messageHub == null)
            {
                InitializeMessageHubMock();
            }

            return messageHub.Object;
        }
    }
}*/