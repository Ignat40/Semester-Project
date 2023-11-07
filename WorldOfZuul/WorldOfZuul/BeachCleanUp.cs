using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldOfZuul
{
    public class BeachCleanupMission
    {
        private bool isCompleted = false;

        public bool IsCompleted => isCompleted;

        public void StartMission(Player player)
        {
            Console.WriteLine("-- Beach Cleanup --");
            Console.WriteLine("You are transported to a local beach covered in plastic waste.");

            InteractiveDialogueWithMarineBiologist(player);
        }

        private void InteractiveDialogueWithMarineBiologist(Player player)
        {
            Console.WriteLine("Scientist: Welcome to the beach cleanup mission!");
            Console.WriteLine(">        : Plastic pollution in oceans is a significant problem.");
            Console.WriteLine(">        : Would you like to learn about plastic dangers in oceans? (yes/no)");

            string response = Console.ReadLine().ToLower();
            if (response == "yes")
            {
                Console.WriteLine("Scientist: *Provides information about plastic dangers*");
            }
            else
            {
                Console.WriteLine("Scientist: Alright, let's get started with the cleanup!");
            }

            Console.WriteLine("Marine Biologist: Please collect plastic waste and sort it for recycling or safe disposal.");
            PerformCleanupTask(player);
        }

        private void PerformCleanupTask(Player player)
        {
            Parser parser = new();

            // Implement logic for the player to collect and sort plastic waste
            // Provide feedback to the player based on their actions
            // Update player's inventory or mission progress accordingly

            Console.WriteLine("Objective: Pick up as much litter as possible. Transport it to recycle bins");
            Console.WriteLine();
            Console.WriteLine($"{player}: I don't see anything here... Hm...");
            Console.WriteLine("+----------------------------------+");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("+----------------------------------+");

            Console.WriteLine("Scientist: Move around (m) of abort mission (a)? (m/a)");
            string? userchoice = Console.ReadLine().ToLower();
            if (userchoice == "m")
            {
                Console.WriteLine($"{player}: Ohh! There is so much trash here!");
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine("|      🥤         📚    🍌         |");
                Console.WriteLine("|   🚬       🥡               🍎   |");
                Console.WriteLine("|                    🍃            |");
                Console.WriteLine("|   🛒                   🔧        |");
                Console.WriteLine("|           🛢️                     |");
                Console.WriteLine("|   🐟               📦            |");
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine();
                Console.WriteLine("Let's get started!");
                Console.WriteLine("use 'pick' or 'drop");

                int trash = 12;

                while (player.Inventory.Count < 12) // Changed the condition to continue until the inventory is full
                {
                    Console.Write("> ");
                    string? cmd = Console.ReadLine();
                    trash--;

                    if (cmd != null)
                    {
                        Console.WriteLine($"Items left to be collected: {trash}");
                        if (cmd == "pick")
                        {
                            player.AddToInventory("trash");
                        }
                        else if (cmd == "drop")
                        {
                            player.RemoveFromIntentory();
                        }
                        else
                        {
                            Console.WriteLine("Invalid command. Use 'pick' or 'drop'.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a command.");
                        continue;
                    }
                }
            }
            else
            {
                System.Environment.Exit(0);
            }

            Console.WriteLine("Scientist: WOW! I don't remember it this clean!");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|      ✨         ✨    ✨       |");
            Console.WriteLine("|   ✨       ✨               ✨ |");
            Console.WriteLine("|                    ✨          |");
            Console.WriteLine("|   ✨                   ✨      |");
            Console.WriteLine("|           ✨                   |");
            Console.WriteLine("|   ✨               ✨          |");
            Console.WriteLine("+--------------------------------+");


            // Assume the cleanup task is completed successfully
            isCompleted = true;
        }

    }
}
