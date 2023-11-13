using System.Diagnostics;
using static WorldOfZuul.Program;
namespace WorldOfZuul
{
    public class Player
    {
        public string? PlayerName;
        public List<string> Inventory = new List<string>();

        public void DisplayPlayer()
        {
            Console.WriteLine("Enter your name Hero: ");
            Console.Write(">");
            string? inputName = Console.ReadLine();
            if (inputName != null)
            {
                PlayerName = inputName;
                Console.WriteLine($"You are our only hope {PlayerName}!");
            }
            else
            {
                PlayerName = "Mr. Eco";
                Console.WriteLine($"You are our only hope {PlayerName}!");
            }
        }

        public void DisplayInventory()
        {
            foreach(var el in Inventory)
            {
                Console.Write($" [{el}]");
            }
        }
        public void AddToInventory(string item)
        {
            Inventory.Add(item);
            Console.WriteLine($"Picked {item}");
        }
        public void RemoveFromIntentory()
        {
            Int32 inventoryCapacity = Inventory.Count;
            if(inventoryCapacity <= 0)
            {
                Console.WriteLine("You don't have anything at the moment!");
            }
            else
            {
                System.Console.WriteLine("Enter index for the item you want to drop!");
                for(int i = 0; i < Inventory.Count; i++)
                {
                    Console.WriteLine($"{i}. {Inventory[i]}");
                }
                Console.Write(">");
                string? dropItem = Console.ReadLine();
                Inventory.Remove(dropItem);
            }
        }

        //Add score system for the player
    }


}