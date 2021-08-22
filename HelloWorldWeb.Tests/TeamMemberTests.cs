using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace HelloWorldWeb.Tests
{
    public class TeamMemberTests
    {
        private Mock<ITimeService> timeMock;
        public TeamMemberTests()
        {
            InitializeTimeServiceMock();

        }

        private void InitializeTimeServiceMock()
        {
            timeMock = new Mock<ITimeService>();
            timeMock.Setup(_ => _.GetNow()).Returns(new DateTime(2021, 8, 11));

        }

        [Fact]
        public void GettingAge()
        {
            //Assume
            InitializeTimeServiceMock();
            var timeService = timeMock.Object;

            var newTeamMember = new TeamMember("Patrick", timeService);
            newTeamMember.BirthDate = new DateTime(1997, 07, 27);

            //Act
            int age = newTeamMember.GetAge();

            //Assert
            timeMock.Verify(_ => _.GetNow(), Times.AtMostOnce());
            Assert.Equal(24, age);

        }

    }
}