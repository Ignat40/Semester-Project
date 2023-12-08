using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Formats.Asn1;
using System.IO.Compression;
using System.Net;
using System.Reflection.Metadata;
using static WorldOfZuul.Program;

namespace WorldOfZuul
{
    public class Game
    {
        private Room? currentRoom;
        private Room? previousRoom;
        private Room? mainHall;
        //private Room? theatre;
        //private Room? pub;
        private Room? farm;
        private Room? kitchen;
        private Room? localBeach;
        private Room? basement;
        private Room? roof;


        public Game()
        {
            CreateRooms();
        }

        private void CreateRooms()
        {
            mainHall = new("The Main Hall", "This is where you meet with The Mayor and return after a mission.");
            //theatre = new("Theatre", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            //pub = new("Pub", "You've entered the campus pub. It's a cozy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            farm = new("The farm", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            kitchen = new("The Kitchen", "Here all the hungry souls find their peace with the best sandwich maker in the city");
            localBeach = new("The local beach", "This the local beach. Over the year people have been neglecting the importance of keeping free of litter. Unfortunately this has led to wildlife leaving the coast and disrupting the ecosystem");
            basement = new("The Basement", "The town's sewage system. It's been running for ages but unfortunately due to the lack of maintanance the water quality and the pipes have been damaged.");
            roof = new("The roof of the university", "From atop the university rooftop, the panorama is a juxtaposition of academia and the natural world. The roof itself is a sea of technology—sleek, photovoltaic panels arrayed like a modern art installation, engineered to harvest the sun's power.");

            mainHall.SetExits(null, farm, localBeach, roof, basement, null);

            //theatre.SetExit("west", mainHall);

            //pub.SetExit("east", mainHall);

            farm.SetExits(mainHall, kitchen, null, null, localBeach, roof);

            kitchen.SetExit("west", farm);

            currentRoom = mainHall;

        }

        public void Play()
        {
            Parser parser = new();
            Player player = new Player();
            AsciiArt asciiArt = new();
            HoneyHive honeyHive = new("Hive1", 1);
            PrintWelcome(player);

            Console.WriteLine("Are you ready for the challenge? (yes/no)");
            Console.Write(">");
            string? decide = Console.ReadLine().ToLower();
            if (decide != null && decide == "yes")
            {
                AnimateFirstHelp("\nYou need to first enter the university"
                                         + " to find the professor. \nHe'll tell you"
                                         + " what to do from there on! ", 5000);
                bool continuePlaying = true;
                while (continuePlaying)
                {
                    Console.WriteLine(currentRoom?.ShortDescription);
                    player.DisplayScore();
                    asciiArt.MainHall();
                    Console.Write("> ");

                    string? input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Please enter a command.");
                        continue;
                    }

                    Command? command = parser.GetCommand(input);

                    if (command == null)
                    {
                        Console.WriteLine("I don't know that command.");
                        continue;
                    }

                    switch (command.Name)
                    {
                        case "look":
                            Console.WriteLine(currentRoom?.LongDescription);
                            switch (currentRoom?.ShortDescription)
                            {
                                case "The local beach":
                                    asciiArt.Beach();
                                    break;
                                case "The farm":
                                    asciiArt.Cow();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    asciiArt.Horse();
                                    break;
                                case "The roof of the university":
                                    asciiArt.Bridge();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    asciiArt.Town();
                                    break;
                                default:
                                    Console.WriteLine();
                                    break;
                            }

                            break;

                        case "back":
                            if (previousRoom == null)
                                Console.WriteLine("You can't go back from here!");
                            else
                                currentRoom = previousRoom;
                            break;

                        case "university":
                            Console.Clear();
                            Task1 task1 = new();
                            Console.WriteLine("Task 1");
                            Console.WriteLine("Do you wish to accept the mission? (yes/no)");
                            string? yesNo1 = Console.ReadLine().ToLower();
                            if (yesNo1 == "yes")
                            {
                                task1.Sandwich();
                                if (task1.IsCompletedTask())
                                {
                                    player.UpdateScore(10);
                                }
                            }
                            else
                            {
                                Console.WriteLine("You won't be able to finish The Quest this way!");
                            }
                            break;

                        case "basement":
                            if (player.Score == 10)
                            {
                                Move(command.Name);
                                MapTask2 mapTask2 = new();
                                mapTask2.DisplayMap();
                                Console.WriteLine("Task 2");
                                Console.WriteLine("Do you wish to accept the mission? (yes/no)");
                                string? yesNo = Console.ReadLine().ToLower();
                                if (yesNo == "yes")
                                {
                                    WaterPurificaiton waterPurificaiton = new();
                                    waterPurificaiton.BasementTask(waterPurificaiton);
                                    player.UpdateScore(10);
                                }
                                else
                                {
                                    Console.WriteLine("You won't be able to finish The Quest this way!");
                                }
                                currentRoom = previousRoom;
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough score");
                                break;
                            }

                            break;

                        case "rooftop":
                            if (player.Score == 20)
                            {
                                Move(command.Name);
                                MapTask3 mapTask3 = new();
                                mapTask3.DisplayMap();
                                Console.WriteLine("Task 3");
                                RooftopMission rooftopMission = new();
                                Console.WriteLine("Do you wish to accept the mission!(yes/no)");
                                Console.Write(">");
                                string? yesNo = Console.ReadLine().ToLower();
                                if (yesNo == "yes")
                                {
                                    rooftopMission.StartMission(player);
                                    player.UpdateScore(10);
                                }
                                else
                                {
                                    Console.WriteLine("You won't be able to finish The Quest this way!");
                                }
                                break;

                            }
                            else
                            {
                                Console.WriteLine("You don't have enough score");
                                break;
                            }

                        case "beach":
                            if (player.Score == 30)
                            {
                                Move(command.Name);
                                MapTask4 mapTask4 = new();
                                mapTask4.DisplayMap();
                                Console.WriteLine("Task 4");
                                AsciiArt acsiiArt = new();
                                acsiiArt.Beach();

                                Console.WriteLine("Do you wish to accept the mission!(yes/no)");
                                Console.Write(">");
                                string? yesNo = Console.ReadLine().ToLower();
                                if (yesNo == "yes")
                                {
                                    BeachCleanupMission beachCleanupMission = new BeachCleanupMission();
                                    beachCleanupMission.StartMission(player);
                                    currentRoom = previousRoom;
                                    player.UpdateScore(10);
                                }
                                else
                                {
                                    Console.WriteLine("You won't be able to finish The Quest this way!");
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough score");
                                break;
                            }

                        case "farm":
                            if (player.Score == 40)
                            {
                                Move(command.Name);
                                MapTask5 mapTask5 = new();
                                mapTask5.DisplayMap();
                                Console.WriteLine("Task 5");
                                Console.WriteLine("Do you wish to accept the mission!(yes/no)");
                                Console.Write(">");
                                string? yesNo = Console.ReadLine().ToLower();
                                if (yesNo == "yes")
                                {
                                    honeyHive.StartMissionsTask5(player);
                                }
                                else
                                {
                                    Console.WriteLine("You won't be able to finish The Quest this way!");
                                }

                                player.UpdateScore(10);
                                if (player.Score == 50)
                                {
                                    GameEnd gameEnd = new();
                                    gameEnd.GameEnding();
                                    continuePlaying = false;
                                }
                                else
                                {
                                    Console.WriteLine("You didn't score the maximum points!");
                                    Console.WriteLine("That's why you get the looser ending!");
                                    Console.WriteLine("Thank you for playing World Of Zuul!");
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough score");
                                break;
                            }

                        case "quit":
                            continuePlaying = false;
                            break;

                        case "view": //do the upgrade fam
                            if (currentRoom == mainHall)
                            {
                                MapInHall map = new();
                                map.DisplayMap();
                            }
                            else if (currentRoom == basement)
                            {
                                MapTask2 mapTask2 = new();
                                mapTask2.DisplayMap();
                            }
                            else if (currentRoom == roof)
                            {
                                MapTask3 mapTask3 = new();
                                mapTask3.DisplayMap();
                            }
                            else if (currentRoom == localBeach)
                            {
                                MapTask4 mapTask4 = new();
                                mapTask4.DisplayMap();
                            }
                            else if (currentRoom == farm)
                            {
                                MapTask5 mapTask5 = new();
                                mapTask5.DisplayMap();
                            }
                            else
                            {
                                BaseMap baseMap = new();
                                baseMap.DisplayMap();
                            }
                            break;

                        case "help":
                            PrintHelp();
                            break;

                        default:
                            Console.WriteLine("I don't know what command.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("We thought you were the one...");
            }
        }

        private void Move(string direction)
        {
            if (currentRoom?.Exits.ContainsKey(direction) == true)
            {
                previousRoom = currentRoom;
                currentRoom = currentRoom?.Exits[direction];
            }
            
        }

        private static void PrintWelcome(Player player)
        {
            Console.WriteLine("██████╗ ██████╗ ██████╗      ███████╗██╗  ██╗██████╗ ██╗      ██████╗ ██████╗ ███████╗██████╗");
            Console.WriteLine("██╔════╝██╔════╝██╔═══██╗    ██╔════╝╚██╗██╔╝██╔══██╗██║     ██╔═══██╗██╔══██╗██╔════╝██╔══██╗");
            Console.WriteLine("█████╗  ██║     ██║   ██║    █████╗   ╚███╔╝ ██████╔╝██║     ██║   ██║██████╔╝█████╗  ██████╔╝");
            Console.WriteLine("██╔══╝  ██║     ██║   ██║    ██╔══╝   ██╔██╗ ██╔═══╝ ██║     ██║   ██║██╔══██╗██╔══╝  ██╔══██╗");
            Console.WriteLine("███████╗╚██████╗╚██████╔╝    ███████╗██╔╝ ██╗██║     ███████╗╚██████╔╝██║  ██║███████╗██║  ██║");
            Console.WriteLine("╚══════╝ ╚═════╝ ╚═════╝     ╚══════╝╚═╝  ╚═╝╚═╝     ╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝");
            player.DisplayPlayer();
        }


        private static void AnimateFirstHelp(string inputText, int duration)
        {
            int frames = duration / 50;
            int startIndex = 0;

            for (int i = 0; i < frames; i++)
            {
                Console.Clear();
                Console.WriteLine(inputText.Substring(startIndex, Math.Min(i * inputText.Length / frames, inputText.Length)));
                Thread.Sleep(50);
            }

            Console.Clear();
            Console.WriteLine(inputText);
        }
        private static void PrintHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Navigate by typing 'university', 'basement', 'beach', 'rooftop', 'farm'.");
            Console.WriteLine("Type 'look' to look around.");
            Console.WriteLine("Type 'view' for you location on the map.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'quit' to exit the game.");
        }
    }
}