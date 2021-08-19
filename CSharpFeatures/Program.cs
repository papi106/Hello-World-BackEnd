
using System;
using System.IO;
using System.Text.Json;

namespace CSharpFeatures
{
    class Program
    {
        static void Main(string[] args)
        {

/*            TeamMember teamMember = new TeamMember() { Name = "Member 1" };
            string jsonString = JsonSerializer.Serialize(teamMember);

            Console.WriteLine(jsonString);

            File.WriteAllText("file.json", jsonString);
            var readText = File.ReadAllTextAsync("file.json");
            readText.Wait();
            var expectedOutput = readText.Result;
            var teamMemberDeserialized = JsonSerializer.Deserialize<TeamMember>(expectedOutput);

            Console.WriteLine(teamMemberDeserialized);*/

            Console.Write("What would you like? ");
            var customerInput = Console.ReadLine();

            Func<string, string, string, string, Coffe> recipe = (customerInput == "FlatWhite") ? FlatWhite : Espresso;
            Coffe coffe = MakeCoffe("grain", "milk", "water", "sugar", recipe);
            Console.WriteLine($"Here is your coffe: {coffe} .");
        }

        static Coffe MakeCoffe(string grains, string milk, string water, string sugar, Func<string, string, string, string, Coffe> recipe)
        {
            try
            {
                Console.WriteLine("Start preparing coffe.");
                var coffe = recipe(grains, milk, water, sugar);
                return coffe;
            }
            catch
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        static Coffe Espresso(string grains, string milk, string water, string sugar)
        {
            return new Coffe("Espresso");
        }
        static Coffe FlatWhite(string grains, string milk, string water, string sugar)
        {
            return new Coffe("Flat White");
        }
    }
}
