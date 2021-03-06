
using System;
using System.IO;
using System.Text.Json;

namespace CSharpFeatures
{
    class Program
    {
        static void Main(string[] args)
        {

            TeamMember teamMember = new() { Name = "Member 1" };
            string jsonString = JsonSerializer.Serialize(teamMember);

            Console.WriteLine(jsonString);

            File.WriteAllText("file.json", jsonString);
            var readText = File.ReadAllTextAsync("file.json");
            readText.Wait();
            var expectedOutput = readText.Result;
            var teamMemberDeserialized = JsonSerializer.Deserialize<TeamMember>(expectedOutput);

            Console.WriteLine(teamMemberDeserialized.ToString());

            Console.Write("What would you like? ");
            var customerInput = Console.ReadLine();

            Func<string, string, string, string, Coffe> recipe = (customerInput == "FlatWhite") ? FlatWhite : Espresso;
            Coffe coffe = MakeCoffe("grain", "milk", "water", "sugar", recipe);

            if (coffe == null)
            {
                Console.WriteLine("Sorry, your order cannot be completed.");
            }
            else
            {
                Console.WriteLine($"Here is your coffe: {coffe} .");
            }
    
        }

        static Coffe MakeCoffe(string grains, string milk, string water, string sugar, 
            Func<string, string, string, string, Coffe> recipe)
        {
            Coffe coffe = null;
            try
            {
                Console.WriteLine("Start preparing coffe.");
                coffe = recipe(grains, milk, water, sugar);
            }
            catch (RecipeUnavailableException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong, see exception details: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
            return coffe;
        }

        static Coffe Espresso(string grains, string milk, string water, string sugar)
        {
            throw new ApplicationException();
        }
        static Coffe FlatWhite(string grains, string milk, string water, string sugar)
        {
            return new Coffe("Flat White");
        }
    }
}
