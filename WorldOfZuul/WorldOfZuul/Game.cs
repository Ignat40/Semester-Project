using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Formats.Asn1;
using System.IO.Compression;
using System.Net;
using System.Reflection.Metadata;
//using System.Timers;
using static WorldOfZuul.Program;

namespace WorldOfZuul
{
    public class Game
    {
        private Room? currentRoom;
        private Room? previousRoom;
        private Room? mainHall;
        private Room? theatre;
        private Room? pub;
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
            theatre = new("Theatre", "You find yourself inside a large lecture theatre. Rows of seats ascend up to the back, and there's a podium at the front. It's quite dark and quiet.");
            pub = new("Pub", "You've entered the campus pub. It's a cozy place, with a few students chatting over drinks. There's a bar near you and some pool tables at the far end.");
            farm = new("The farm", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            kitchen = new("The Kitchen", "Here all the hungry souls find their peace with the best sandwich maker in the city");
            localBeach = new("The local beach", "This the local beach. Over the year people have been neglecting the importance of keeping free of litter. Unfortunately this has led to wildlife leaving the coast and disrupting the ecosystem");
            basement = new("The Basement", "The town's sewage system. It's been running for ages but unfortunately due to the lack of maintanance the water quality and the pipes have been damaged.");
            roof = new("The roof of the university", "From atop the university rooftop, the panorama is a juxtaposition of academia and the natural world. The roof itself is a sea of technology—sleek, photovoltaic panels arrayed like a modern art installation, engineered to harvest the sun's power.");

            mainHall.SetExits(null, theatre, farm, pub, localBeach, roof, basement);

            theatre.SetExit("west", mainHall);

            pub.SetExit("east", mainHall);

            farm.SetExits(mainHall, kitchen, null, null, null, null, null);

            kitchen.SetExit("west", farm);

            currentRoom = mainHall;

        }

        public void Play()
        {
            Parser parser = new();
            Player player = new Player();
            HoneyHive honeyHive = new("Hive1", 1);
            PrintWelcome(player);

            Console.WriteLine("Are you ready for the challange? (yes/no)");
            Console.Write(">");
            string? decide = Console.ReadLine().ToLower();
            if (decide != null && decide == "yes")
            {
                bool continuePlaying = true;
                while (continuePlaying)
                {
                    Console.WriteLine(currentRoom?.ShortDescription);
                    player.DisplayScore();
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
                        AsciiArt asciiArt = new();
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
                            // Console.WriteLine(currentRoom?.LongDescription);
                            // switch (currentRoom?.ShortDescription)
                            // {
                            //     case "Station":
                            //         string ascii_Station = "Ascii.txt";
                            //         string text = File.ReadAllText(ascii_Station);
                            //         System.Console.WriteLine(text);
                            //         break;
                            //     case "Beach":
                            //         string ascii_Beach = "Ascii2.txt";
                            //         string text2 = File.ReadAllText(ascii_Beach);
                            //         System.Console.WriteLine(text2);
                            //         System.Console.WriteLine();
                            //         Move(command.Name);
                            //         BeachCleanupMission beachCleanupMission = new();
                            //         beachCleanupMission.StartMission(player);
                            //         break;
                            //     case "Lab":
                            //         string ascii_Lab = "Ascii3.txt";
                            //         string text3 = File.ReadAllText(ascii_Lab);
                            //         System.Console.WriteLine(text3);
                            //         break;
                            //     case "Farm":
                            //         string ascii_Farm = "Ascii4.txt";
                            //         string text4 = File.ReadAllText(ascii_Farm);
                            //         System.Console.WriteLine(text4);
                            //         System.Console.WriteLine();
                            //         System.Console.WriteLine("Love animals");
                            //         break;
                            //     case "Rooftop":
                            //         string ascii_Rooftop = "Ascii5.txt";
                            //         string text5 = File.ReadAllText(ascii_Rooftop);
                            //         System.Console.WriteLine(text5);
                            //         System.Console.WriteLine();
                            //         System.Console.WriteLine("What a gorgeous city");
                            //         Move(command.Name);
                            //         RooftopMission rooftopMission = new();
                            //         rooftopMission.StartMission(player);
                            //         break;
                            //     default:
                            //         System.Console.WriteLine();
                            //         break;
                            // }    
                            break;

                        case "back":
                            if (previousRoom == null)
                                Console.WriteLine("You can't go back from here!");
                            else
                                currentRoom = previousRoom;
                            break;

                        case "university":
                            Task1 task1 = new();
                            Console.WriteLine("Task 1");
                            //task1.Sandwich();
                            player.UpdateScore(10);
                            break;

                        case "basement":
                            if (player.Score == 10)
                            {
                                Move(command.Name);
                                Console.WriteLine("Task 2");
                                // WaterPurificaiton waterPurificaiton = new();
                                // waterPurificaiton.BasementTask(waterPurificaiton);
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough score");
                                break;
                            }
                            player.UpdateScore(10);
                            break;

                        case "rooftop":
                            if (player.Score == 20)
                            {
                                Move(command.Name);
                                Console.WriteLine("Task 3");
                                // RooftopMission rooftopMission = new();
                                // Console.WriteLine("Do you wish to accept the mission!");
                                // Console.Write(">");
                                // string? yesNo = Console.ReadLine().ToLower();
                                // if (yesNo == "yes")
                                // {
                                //     rooftopMission.StartMission(player);
                                player.UpdateScore(10);
                                // }
                                // else
                                // {
                                //     Console.WriteLine("You won't be able to finish The Quest this way!");
                                // }
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
                                Console.WriteLine("Task 4");
                                // AcsiiArt acsiiArt = new();
                                // acsiiArt.Beach();

                                // Console.WriteLine("Do you wish to accept the mission!");
                                // Console.Write(">");
                                // string? yesNo = Console.ReadLine().ToLower();
                                // if (yesNo == "yes")
                                // {
                                //     BeachCleanupMission beachCleanupMission = new BeachCleanupMission();
                                //     beachCleanupMission.StartMission(player);
                                player.UpdateScore(10);
                                // }
                                // else
                                // {
                                //     Console.WriteLine("You won't be able to finish The Quest this way!");
                                // }
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
                                Console.WriteLine("Task 5");
                                // Console.WriteLine("Do you wish to accept the mission!");
                                // Console.Write(">");
                                // string? yesNo = Console.ReadLine().ToLower();
                                // if (yesNo == "yes")
                                // {
                                //     honeyHive.StartMissionsTask5(player);
                                // }
                                // else
                                // {
                                //     Console.WriteLine("You won't be able to finish The Quest this way!");
                                // }

                                player.UpdateScore(10);
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

                        case "view":
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
                            else if (currentRoom == localBeach)
                            {
                                MapTask3 mapTask3 = new();
                                mapTask3.DisplayMap();
                            }
                            else if (currentRoom == localBeach)
                            {
                                MapTask4 mapTask4 = new();
                                mapTask4.DisplayMap();
                            }
                            else if (currentRoom == localBeach)
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

                        case "talk":
                            Talk(currentRoom?.ShortDescription);
                            break;

                        // case "accept":
                        //     switch (currentRoom?.ShortDescription)
                        //     {
                        //         case "Farm":
                        //             honeyHive.StartMissionsTask5(player);
                        //             break;
                        //         case "Basement":
                        //             Move(command.Name);
                        //             WaterPurificaiton waterPurificaiton = new();
                        //             waterPurificaiton.BasementTask(waterPurificaiton);
                        //             break;

                        //         default:
                        //             System.Console.WriteLine("There is no mission in this area(room)");
                        //             break;
                        //     }
                        //break;

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



            Console.WriteLine("Thank you for playing World of Zuul!");
            Console.WriteLine();
            Console.WriteLine("We hope you enjoyed and gain educational information about SDGs.");
            Console.WriteLine();
            Console.WriteLine("Creators are:");
            Console.WriteLine();
            Console.WriteLine("___Vedat Esendag___");
            Thread.Sleep(1000);
            Console.WriteLine("___Altan Esmer___");
            Thread.Sleep(1000);
            Console.WriteLine("___Frederik Handberg___");
            Thread.Sleep(1000);
            Console.WriteLine("___Ignat Bozhinov___");
            Thread.Sleep(1000);
            Console.WriteLine("___Leonardo Gianola___");
            Thread.Sleep(1000);;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("            ^^                   @@@@@@@@@");
            Thread.Sleep(100);
            Console.WriteLine("       ^^       ^^            @@@@@@@@@@@@@@@");
            Thread.Sleep(100);
            Console.WriteLine("                           @@@@@@@@@@@@@@@@@@              ^^");
            Thread.Sleep(100);
            Console.WriteLine("                           @@@@@@@@@@@@@@@@@@@@");
            Thread.Sleep(100);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ~~~~ ~~ ~~~~~ ~~~~~~~~ ~~ &&&&&&&&&&&&&&&&&&&& ~~~~~~~ ~~~~~~~~~~~ ~~~");
            Thread.Sleep(100);
            Console.WriteLine(" ~         ~~   ~  ~       ~~~~~~~~~~~~~~~~~~~~ ~       ~~     ~~ ~");
            Thread.Sleep(100);
            Console.WriteLine("   ~      ~~      ~~ ~~ ~~  ~~~~~~~~~~~~~ ~~~~  ~     ~~~    ~ ~~~  ~ ~~");
            Thread.Sleep(100);
            Console.WriteLine("   ~  ~~     ~         ~      ~~~~~~  ~~ ~~~       ~~ ~ ~~  ~~ ~");
            Thread.Sleep(100);
            Console.WriteLine(" ~  ~       ~ ~      ~           ~~ ~~~~~~  ~      ~~  ~             ~~");
            Thread.Sleep(100);
            Console.WriteLine("       ~             ~        ~      ~      ~~   ~             ~\n");
            Thread.Sleep(100);
            Console.ResetColor();
            Console.WriteLine("▄█▀▀║░▄█▀▄║▄█▀▄║██▀▄║");
            Thread.Sleep(100);
            Console.WriteLine("██║▀█║██║█║██║█║██║█║");
            Thread.Sleep(100);
            Console.WriteLine("▀███▀║▀██▀║▀██▀║███▀║");
            Thread.Sleep(100);
            Console.WriteLine("───────────────────────");
            Thread.Sleep(100);
            Console.WriteLine("───▐█▀▄─ ▀▄─▄▀ █▀▀──█───");
            Thread.Sleep(100);
            Console.WriteLine("───▐█▀▀▄ ──█── █▀▀──▀───");
            Thread.Sleep(100);
            Console.WriteLine("───▐█▄▄▀ ──▀── ▀▀▀──▄───");
            Thread.Sleep(100);
            Console.Beep();
        }

        private void Move(string direction)
        {
            if (currentRoom?.Exits.ContainsKey(direction) == true)
            {
                previousRoom = currentRoom;
                currentRoom = currentRoom?.Exits[direction];
            }
            else
            {
                Console.WriteLine($"You can't go {direction}!");
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



        private static void PrintHelp()
        {
            // MapInHall map = new();
            // map.DisplayMap();
            Console.WriteLine("You need to enter the univesirty");
            Console.WriteLine("to find the professor. He'll tell you.");
            Console.WriteLine("what to do from there on. ");
            Console.WriteLine();
            Console.WriteLine("Navigate by typing 'university', 'basement', 'beach', 'rooftop', 'farm'.");
            Console.WriteLine("Type 'look' for more information.");
            Console.WriteLine("Type 'view' for you location on the map.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'quit' to exit the game.");
        }
        private static void Talk(string? location)
        {
            Game game = new();
            NPCs communicate = new();
            switch (location)
            {
                //Under development, Npc locations and senteces will be dicussed
                case "Lab":
                    communicate.NpcName = "Professor Mike";
                    communicate.Sentence = "[Some Sentences(will discuss during meeting)]";
                    Console.WriteLine($"This is {communicate.NpcName}.");
                    Console.WriteLine();
                    Console.WriteLine("|Professor|");
                    Console.WriteLine(communicate.Sentence);
                    break;

                case "outside":
                    communicate.NpcName = "Mayor";
                    communicate.Sentence = "Someting......";
                    Console.WriteLine($"{communicate.NpcName} is standing in front of you.");
                    Console.WriteLine();
                    Console.WriteLine($"|{communicate.NpcName}|");
                    break;
                case "Station":
                    communicate.NpcName = "Jackson";
                    communicate.Sentence = "";
                    break;
                default:
                    Console.WriteLine("There is nobody to talk with.");
                    break;
            }
        }
    }
}