using HelloWorldWeb.Services;
using HelloWorldWebApp.Services;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamServiceTests
    {
        private Mock<IClientProxy> hubAllClientsMock;
        private Mock<IHubContext<MessageHub>> messageHubMock;

        private void InitializeMessageHubMock()
        {
            // https://www.codeproject.com/Articles/1266538/Testing-SignalR-Hubs-in-ASP-NET-Core-2-1
            hubAllClientsMock = new Mock<IClientProxy>();
            Mock<IHubClients> hubClients = new Mock<IHubClients>();
            hubClients.Setup(_ => _.All).Returns(hubAllClientsMock.Object);
            messageHubMock = new Mock<IHubContext<MessageHub>>();

            messageHubMock.SetupGet(_ => _.Clients).Returns(hubClients.Object);
        }

        private Mock<IHubContext<MessageHub>> GetMockedMessageHub()
        {
            if (messageHubMock == null)
            {
                InitializeMessageHubMock();
            }

            return messageHubMock;
        }
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            //Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            var broadcastService = broadcastServiceMock.Object;
            var teamService = new TeamService(broadcastService);

            //Act
            int initialCount = teamService.GetTeamInfo().TeamMembers.Count;
            teamService.AddTeamMember("Patrick");

            //Assert
            Assert.Equal(initialCount + 1, teamService.GetTeamInfo().TeamMembers.Count);
            broadcastServiceMock.Verify(_ => _.NewTeamMemberAdded(It.IsAny<string>(), It.IsAny<int>()), Times.Exactly(7));
        }

        [Fact]
        public void DeleteMemberFromTheTeam()
        {
            // Assume
            //var teamService = new TeamService(GetMockedMessageHub().Object);
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            var broadcastService = broadcastServiceMock.Object;
            var teamService = new TeamService(broadcastService);

            int initialCount = teamService.GetTeamInfo().TeamMembers.Count;
            var id = teamService.GetTeamInfo().TeamMembers[0].Id;

            // Act
            teamService.DeleteTeamMember(id);

            // Assert
            Assert.Equal(initialCount - 1, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void EditMemberName()
        {
            // Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            var broadcastService = broadcastServiceMock.Object;
            var teamService = new TeamService(broadcastService);
            var id = teamService.GetTeamInfo().TeamMembers[0].Id;

            // Act
            teamService.EditTeamMember(id, "Test");

            // Assert
            var member = teamService.GetTeamMemberById(id);
            Assert.Equal("Test", member.Name);
        }

        [Fact]
        public void CheckIdProblem()
        {
            // Assume
            //var teamService = new TeamService(GetMockedMessageHub().Object);
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            var broadcastService = broadcastServiceMock.Object;
            var teamService = new TeamService(broadcastService);

            var id = teamService.GetTeamInfo().TeamMembers[0].Id;

            // Act
            teamService.DeleteTeamMember(id);
            int memberId = teamService.AddTeamMember("Test");
            teamService.DeleteTeamMember(memberId);

            // Assert
            int lastIndex = teamService.GetTeamInfo().TeamMembers.Count;
            Assert.NotEqual("Test", teamService.GetTeamInfo().TeamMembers[lastIndex - 1].Name);
        }
    }
}