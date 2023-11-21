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
            farm = new("Lab", "You're in a computing lab. Desks with computers line the walls, and there's an office to the east. The hum of machines fills the room.");
            kitchen = new("Office", "You've entered what seems to be an administration office. There's a large desk with a computer on it, and some bookshelves lining one wall.");
            localBeach = new("The local beach", "This the local beach. Over the year people have been neglecting the importance of keeping free of litter. Unfortunately this has led to wildlife leaving the coast and disrupting the ecosystem");
            basement = new("The Basement", "asljdfhaljksdhflajksdhfljkasdhflkjsadhfljk");
            roof = new("The roof of the university", "From atop the university rooftop, the panorama is a juxtaposition of academia and the natural world. The roof itself is a sea of technology—sleek, photovoltaic panels arrayed like a modern art installation, engineered to harvest the sun's power.");

            mainHall.SetExits(null, theatre, farm, pub, localBeach, roof, basement);

            theatre.SetExit("west", mainHall);

            pub.SetExit("east", mainHall);

            farm.SetExits(mainHall, kitchen, null, null, null, null, null);

            kitchen.SetExit("west", farm);

            currentRoom = mainHall;

            //We need to decide room names and contents to develop faster
            //Direction information in descriptions should be added
            // Room? outside = new("Outside", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub.");
            // Room? farm = new("Farm", "There is a farm in front of you. Beautfiul flowers and huge trees are covering all way around. If you look more carefully, you can see that there are lots of hives for bees But why honey is not existing inside the hives? Interesting\n");
            // Room? beach = new("Beach", "Your are now locating on a local beach. The gold color sand and beautiful sea covers all around you. But it looks dirty. People didn't behave excellently to this beach.");
            // Room? lab = new("Lab", "You're in university's lab. It contains lots of equipment, for instance,  broken water filtration system, lots of scientific calculator and other tools. There is a stairs to the rooftop of the university east of the lab. Labs are useful rooms for development, this one is also looking good.\nYou saw Professor next to the mainframe computers. Should you talk wit him?");
            // Room? rooftop = new("Rooftop", "That's the highest point of university. It's mostly empty. Only one red light is situating next to the edge of the rooftop. When looking at around, this empty part can be useful for building something there ...... something cool. Also, you can see all the city on this point.");
            // Room? basement = new("Basement", "base...");
            // Room? station = new("Station", "You are standing opposite the city's only train station. There is no one there except a young man.\nApparently there are no trains passing through here today except an old one standing left side of the station. Still, this place is clean.");
            // outside.SetExits(basement, farm, lab, beach); // North, East, South, West
            // //Need to create visual map for the rooms
            // farm.SetExit("west", outside);

            // beach.SetExit("east", outside);

            // basement.SetExit("south", outside);

            // lab.SetExits(outside, rooftop, null, station);

            // rooftop.SetExit("west", lab);

            // station.SetExit("east", lab);

            // currentRoom = outside;
        }

        public void Play()
        {
            //Bees bees = new();
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
                            task1.Sandwich();
                            player.UpdateScore(10);
                            break;

                        case "basement":
                            if (player.Score == 10)
                            {
                                Move(command.Name);
                                
                                WaterPurificaiton waterPurificaiton = new();
                                waterPurificaiton.BasementTask(waterPurificaiton);
                                player.UpdateScore(10);
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
                                RooftopMission rooftopMission = new();
                                Console.WriteLine("Do you wish to accept the mission!");
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
                                AcsiiArt acsiiArt = new();
                                acsiiArt.Beach();

                                Console.WriteLine("Do you wish to accept the mission!");
                                Console.Write(">");
                                string? yesNo = Console.ReadLine().ToLower();
                                if (yesNo == "yes")
                                {
                                    BeachCleanupMission beachCleanupMission = new BeachCleanupMission();
                                    beachCleanupMission.StartMission(player);
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
                                Console.WriteLine("Do you wish to accept the mission!");
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
            System.Console.WriteLine();
            System.Console.WriteLine("We hope you enjoyed and gain educational information about SDGs.");
            System.Console.WriteLine();
            System.Console.WriteLine("Creators are:");
            System.Console.WriteLine();
            System.Console.WriteLine("___Vedat Esendag___");
            Thread.Sleep(1000);
            System.Console.WriteLine("___Altan Esmer___");
            Thread.Sleep(1000);
            System.Console.WriteLine("___Frederik Handberg___");
            Thread.Sleep(1000);
            System.Console.WriteLine("___Ignat Bozhinov___");
            Thread.Sleep(1000);
            System.Console.WriteLine("___Leonardo Gianola___");
            Thread.Sleep(1000);
            System.Console.WriteLine("___Habib Ahmed Wasi___\n");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("            ^^                   @@@@@@@@@");
            System.Console.WriteLine("       ^^       ^^            @@@@@@@@@@@@@@@");
            System.Console.WriteLine("                           @@@@@@@@@@@@@@@@@@              ^^");
            System.Console.WriteLine("                           @@@@@@@@@@@@@@@@@@@@");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine(" ~~~~ ~~ ~~~~~ ~~~~~~~~ ~~ &&&&&&&&&&&&&&&&&&&& ~~~~~~~ ~~~~~~~~~~~ ~~~");
            System.Console.WriteLine(" ~         ~~   ~  ~       ~~~~~~~~~~~~~~~~~~~~ ~       ~~     ~~ ~");
            System.Console.WriteLine("   ~      ~~      ~~ ~~ ~~  ~~~~~~~~~~~~~ ~~~~  ~     ~~~    ~ ~~~  ~ ~~");
            System.Console.WriteLine("   ~  ~~     ~         ~      ~~~~~~  ~~ ~~~       ~~ ~ ~~  ~~ ~");
            System.Console.WriteLine(" ~  ~       ~ ~      ~           ~~ ~~~~~~  ~      ~~  ~             ~~");
            System.Console.WriteLine("       ~             ~        ~      ~      ~~   ~             ~\n");
            Console.ResetColor();
            System.Console.WriteLine("▄█▀▀║░▄█▀▄║▄█▀▄║██▀▄║");
            System.Console.WriteLine("██║▀█║██║█║██║█║██║█║");
            System.Console.WriteLine("▀███▀║▀██▀║▀██▀║███▀║");
            System.Console.WriteLine("───────────────────────");
            System.Console.WriteLine("───▐█▀▄─ ▀▄─▄▀ █▀▀──█───");
            System.Console.WriteLine("───▐█▀▀▄ ──█── █▀▀──▀───");
            System.Console.WriteLine("───▐█▄▄▀ ──▀── ▀▀▀──▄───");
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
            Console.WriteLine("Type 'look' for more details.");
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
                    System.Console.WriteLine($"This is {communicate.NpcName}.");
                    System.Console.WriteLine();
                    System.Console.WriteLine("|Professor|");
                    System.Console.WriteLine(communicate.Sentence);
                    break;

                case "outside":
                    communicate.NpcName = "Mayor";
                    communicate.Sentence = "Someting......";
                    System.Console.WriteLine($"{communicate.NpcName} is standing in front of you.");
                    System.Console.WriteLine();
                    System.Console.WriteLine($"|{communicate.NpcName}|");
                    break;
                case "Station":
                    communicate.NpcName = "Jackson";
                    communicate.Sentence = "";
                    break;
                default:
                    System.Console.WriteLine("There is nobody to talk with.");
                    break;
            }
        }
    }
}