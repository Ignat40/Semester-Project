using System.Diagnostics;
using static WorldOfZuul.Program;
namespace WorldOfZuul
{
    public class Player
    {
        public string? PlayerName;
        public int PlayerScore = 0;
        public int Score
        {
            get { return PlayerScore; }
            set { PlayerScore = value; }
        }
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
            }
            // AnimateIntro("\nThe Mayor will be your personal guide during this mission!"
            //             + "He will give you tasks and check whether you've completed them or not!"
            //             +"Be fast and don't hesitate to type 'help' if you are lost."
            //             +"Bellow is a mini map of the whole quest!"
            //             +$"Good luck {PlayerName}! You are our only hope!", 5000);

            BaseMap baseMap = new();
            baseMap.DisplayMap();
            
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

        public void UpdateScore(int points)
        {
            PlayerScore += points;
        }

        public void DisplayScore()
        {
            Console.WriteLine($"Score: {PlayerScore}");

        }
        public static void AnimateIntro(string inputText, int duration)
        {
            int frames = duration/ 50;
            int startIndex = 0;

            for(int i = 0; i < frames; i++)
            {
                Console.Clear();
                Console.WriteLine(inputText.Substring(startIndex, Math.Min(i * inputText.Length / frames, inputText.Length)));
                Thread.Sleep(50);
            }

            Console.Clear();
            Console.WriteLine(inputText);
        }
    }


}