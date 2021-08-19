
using System;
using System.IO;
using System.Text.Json;

namespace CSharpFeatures
{
    class Program
    {
        static void Main(string[] args)
        {


            TeamMember teamMember = new TeamMember() { Name = "Member 1" };

            string jsonString = JsonSerializer.Serialize(teamMember);

            Console.WriteLine(jsonString);

            File.WriteAllText("file.txt", jsonString);

            var teamMemberDeserialized = JsonSerializer.Deserialize<TeamMember>(jsonString);
        }
    }
}
