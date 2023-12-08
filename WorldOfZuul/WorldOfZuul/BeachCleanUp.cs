using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace WorldOfZuul
{
    public class BeachCleanupMission
    {
        private bool isCompleted = false;

        public bool IsCompleted => isCompleted;
        List<string> trashToPick = new List<string> { "cans", "newspaper", "bottle", "?" };

        public void StartMission(Player player)
        {
            Console.WriteLine("-- Beach Cleanup --");
            Console.WriteLine("You are transported to a local beach covered in plastic waste.");

            InteractiveDialogueWithMarineBiologist(player);
        }

        private void InteractiveDialogueWithMarineBiologist(Player player)
        {
            Console.WriteLine("Scientist: Welcome to the beach mission!");
            Console.WriteLine("Plastic pollution in oceans is a significant problem.");
            Console.WriteLine("Would you like to learn about plastic dangers in oceans? (yes/no)");

            string? response = Console.ReadLine().ToLower();
            if (response == "yes")
            {
                Console.WriteLine("Scientist: *Provides information about plastic dangers*");
            }
            else
            {
                Console.WriteLine("Scientist: Alright, let's get started with the cleanup! But ");
            }

            Console.WriteLine("Scientist: Please collect plastic waste and sort it for recycling or safe disposal.");
            PerformCleanupTask(player);
        }

        private void PerformCleanupTask(Player player)
        {
            Parser parser = new();

            Console.WriteLine("Objective: Pick up as much litter as possible. Look careful for speacial items");
            Console.WriteLine();
            Console.WriteLine($"You: I don't see anything here... Hm...");
            Console.WriteLine("+----------------------------------+");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("+----------------------------------+");

            Console.WriteLine("Scientist: Move around (m) of abort mission (a)? (m/a)");
            Console.Write(">");
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
                Console.WriteLine("use 'pick' and then select which item you want to pick");

                int trash = 5;
                bool leftTrash = true;

                while (leftTrash)
                {
                    Console.Write("> ");
                    string? cmd = Console.ReadLine();
                    trash--;

                    if (cmd != null)
                    {
                        Console.WriteLine($"{ShowTrash()}: {trash}");
                        if (cmd == "pick")
                        {
                            Console.WriteLine("Enter the item to pick: ");
                            string? item = Console.ReadLine();
                            if (item != null)
                            {
                                player.AddToInventory(item);
                                trashToPick.Remove(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid command. Use 'pick'.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a command.");
                        continue;
                    }

                    if (trash == 0)
                        leftTrash = false;

                }
            }

            else
            {
                System.Environment.Exit(0);
            }


            Console.WriteLine("Scientist: WOW! I don't remember it being this clean!");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|      ✨         ✨    ✨        |");
            Console.WriteLine("|   ✨       ✨               ✨  |");
            Console.WriteLine("|                    ✨           |");
            Console.WriteLine("|   ✨                   ✨       |");
            Console.WriteLine("|           ✨                    |");
            Console.WriteLine("|   ✨               ✨           |");
            Console.WriteLine("+--------------------------------+");

            DisposeTrash(player);

            isCompleted = true;
            player.UpdateScore(10);
        }

        public void DisposeTrash(Player player)
        {
            Console.WriteLine("Scientist: Very nicely done! But your job here is not done yet!");
            Console.WriteLine($"Scientist: You have to go to the bins\nand dispose the trash acordingly!");
            Console.WriteLine("Go to the bins or Abord the mission (yes/no)");
            string? input = Console.ReadLine();

            if (input != null && input.ToLower() == "yes")
            {
                string bins = @"
                     ___/-\___     ___/-\___     ___/-\___
                    |---------|   |---------|   |---------|
                     | | | | |     | | | | |     | | | | | 
                     | | 1 | |     | | 2 | |     | | 3 | | 
                     | | | | |     | | | | |     | | | | | 
                     | | | | |     | | | | |     | | | | | 
                     |_______|     |_______|     |_______|";

                Console.WriteLine(bins);
                Console.WriteLine("\nScientist: You have to choose where to throw the trash accordingly!");
                Console.WriteLine("View your inventory and select the index of the item \nand then the index of the bin you want to throw it in!");
                Console.WriteLine();
                player.DisplayInventory();
                int itemsLeftToDispose = 3;

                while (itemsLeftToDispose != 0)
                {
                    Console.WriteLine("Enter the index of the item to throw: ");
                    if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex >= 0 && itemIndex < player.Inventory.Count)
                    {
                        string thrownItem = player.Inventory[itemIndex];

                        Console.WriteLine($"You have '{thrownItem}'.");
                        Console.WriteLine($"Choose the bin to throw it in:");

                        if (int.TryParse(Console.ReadLine(), out int binIndex))
                        {
                            if (thrownItem == "cans" && binIndex == 3)
                            {
                                Console.WriteLine("Correct!");
                                itemsLeftToDispose--;
                            }
                            else if (thrownItem == "newspaper" && binIndex == 1)
                            {
                                Console.WriteLine("Correct!");
                                itemsLeftToDispose--;
                            }
                            else if (thrownItem == "bottle" && binIndex == 2)
                            {
                                Console.WriteLine("Correct!");
                                itemsLeftToDispose--;
                            }
                            else
                            {
                                Console.WriteLine($"You can't throw {thrownItem} in trash can {binIndex}");
                                continue;
                            }

                        }


                    }
                    else
                    {
                        Console.WriteLine("Invalid item index. Please enter a valid index.");
                    }
                }


            }
            else
            {
                Console.WriteLine("You won't be able to continue with the other missions!");
            }

        }

        public string ShowTrash()
        {
            string trashString = string.Join(" ", trashToPick.Select(el => $"['{el}']"));
            return trashString;
        }

    }



}




