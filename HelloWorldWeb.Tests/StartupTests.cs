using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class StartupTests
    {

        [Fact]
        public void ConvertHerokuStringToAspNetString()
        {
            //Assume
            string herokuConnectionString = "postgres://fotpmwixemckln:a4ea0f24875cc852c41648ee3b55809b38a9e5b8b1dda7a79a6834db952fe4c4@ec2-34-251-245-108.eu-west-1.compute.amazonaws.com:5432/df8qhbe85eklfi";

            //Act
            
            string aspNetConnectionString = Startup.ConvertHerokuStringToAspNetString(herokuConnectionString);

            //Assert
            Assert.Equal("Host=ec2-34-251-245-108.eu-west-1.compute.amazonaws.com;Port=5432;Database=df8qhbe85eklfi;User Id=fotpmwixemckln;Password=a4ea0f24875cc852c41648ee3b55809b38a9e5b8b1dda7a79a6834db952fe4c4;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;", aspNetConnectionString);
        }

    }
}
