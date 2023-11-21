using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfZuul
{
    public class CommandWords
    {
        public List<string> ValidCommands { get; } = new List<string> { "help", "farm", "university", "beach", "roof", "rooftop", "look", "back", "talk", "accept", "quit", "pick", "drop", "basement"};

        public bool IsValidCommand(string command)
        {
            return ValidCommands.Contains(command);
        }
    }

}
