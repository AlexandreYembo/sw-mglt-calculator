namespace Kneat.Starwars.Console.Composite
{
    public interface IMessage
    {
        string Name {get; set;}
        char Simbol {get; set;}
        void DisplayMessages(int sub);
    }
}