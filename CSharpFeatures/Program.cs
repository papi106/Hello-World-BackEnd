
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

            File.WriteAllText("file.json", jsonString);

            var readText = File.ReadAllTextAsync("file.json");
            readText.Wait();
            var expectedOutput = readText.Result;

            var teamMemberDeserialized = JsonSerializer.Deserialize<TeamMember>(expectedOutput);
            Console.WriteLine(teamMemberDeserialized);
        }
    }
}
