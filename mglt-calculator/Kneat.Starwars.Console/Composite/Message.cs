using System.Collections;
using System.Collections.Generic;

namespace Kneat.Starwars.Console.Composite
{
    /// <summary>
    /// This class implements the use of Composite design pattern, to display the message in a kind of tree view
    /// </summary>
    public class Message : IMessage
    {
        private readonly List<IMessage> _list = new List<IMessage>();
       public string Name { get; set; }
        public char Simbol { get; set; }

        public Message(string name, char simbol = '.')
        {
            Name = name;
            Simbol = simbol;
        }

        public void AddChild(IMessage childMessage) => _list.Add(childMessage);

        public void DisplayMessages(int sub)
        {
            System.Console.WriteLine(new string(Simbol, sub) + Name);

            foreach (var message in _list)
            {
                message.DisplayMessages(sub + 2);
            }
        }
    }
}