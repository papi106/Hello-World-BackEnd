namespace CSharpFeatures
{
    internal class Coffe
    {
        public Coffe()
        {

        }
        public Coffe(string type)
        {
            CoffeType = type;
        }
        public string CoffeType { get; set; }

        public override string ToString()
        {
            return CoffeType;
        }

    }
}