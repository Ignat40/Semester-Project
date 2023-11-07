using System.ComponentModel;
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

        public Game()
        {
            CreateRooms();
        }

        private void CreateRooms()
        {
            //We need to decide room names and contents to develop faster
            //Direction information in descriptions should be added
            Room? outside = new("Outside", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub.");
            Room? farm = new("Farm", "There is a farm in front of you. Beautfiul flowers and huge trees are covering all way around. If you look more carefully, you can see that there are lots of hives for bees But why honey is not existing inside the hives? Interesting\n");
            Room? beach = new("Beach", "Your are now locating on a local beach. The gold color sand and beautiful sea covers all around you. But it looks dirty. People didn't behave excellently to this beach.");
            Room? lab = new("Lab", "You're in university's lab. It contains lots of equipment, for instance,  broken water filtration system, lots of scientific calculator and other tools. There is a stairs to the rooftop of the university east of the lab. Labs are useful rooms for development, this one is also looking good.\nYou saw Professor next to the mainframe computers. Should you talk wit him?"); 
            Room? rooftop = new("Rooftop", "That's the highest point of university. It's mostly empty. Only one red light is situating next to the edge of the rooftop. When looking at around, this empty part can be useful for building something there ...... something cool. Also, you can see all the city on this point.");
            Room? basement = new("Basement","base...");
            Room? station = new("Station","You are standing opposite the city's only train station. There is no one there except a young man.\nApparently there are no trains passing through here today except an old one standing left side of the station. Still, this place is clean.");
            outside.SetExits(basement, farm, lab, beach); // North, East, South, West
            //Need to create visual map for the rooms
            farm.SetExit("west", outside);

            beach.SetExit("east", outside);

            basement.SetExit("south", outside);

            lab.SetExits(outside, rooftop, null, station);

            rooftop.SetExit("west", lab);

            station.SetExit("east", lab);

            currentRoom = outside;
        }

        public void Play()
        {
            Bees bees = new();
            Parser parser = new();
            Task5 task5 = new();

            PrintWelcome();

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

                switch(command.Name)
                {
                    case "look":
                        Console.WriteLine(currentRoom?.LongDescription);
                        switch (currentRoom?.ShortDescription)
                        {
                            case "Station":
                                string ascii_Station = "Ascii.txt";
                                string text = File.ReadAllText(ascii_Station);
                                System.Console.WriteLine(text);
                                break;
                            case "Beach":
                                string ascii_Beach = "Ascii2.txt";
                                string text2 = File.ReadAllText(ascii_Beach);
                                System.Console.WriteLine(text2);
                                System.Console.WriteLine();
                                System.Console.WriteLine("Wonderfull view.");
                                break;
                            case "Lab":
                                string ascii_Lab = "Ascii3.txt";
                                string text3 = File.ReadAllText(ascii_Lab);
                                System.Console.WriteLine(text3);
                                break;
                            case "Farm":
                                string ascii_Farm = "Ascii4.txt";
                                string text4 = File.ReadAllText(ascii_Farm);
                                System.Console.WriteLine(text4);
                                System.Console.WriteLine();
                                System.Console.WriteLine("Love animals");
                                break;
                            case "Rooftop":
                                string ascii_Rooftop = "Ascii5.txt";
                                string text5 = File.ReadAllText(ascii_Rooftop);
                                System.Console.WriteLine(text5);
                                System.Console.WriteLine();
                                System.Console.WriteLine("What a gorgeous city");
                                break;
                            default: System.Console.WriteLine();
                                break;
                        }
                        break;

                    case "back":
                        if (previousRoom == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                            currentRoom = previousRoom;
                        break;

                    case "north":
                    case "south":
                    case "east":
                    case "west":
                        Move(command.Name);
                        break;

                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    case "talk":
                        Talk(currentRoom?.ShortDescription);
                    break;
                    
                    case "accept":
                        Accept();
                        switch (currentRoom?.ShortDescription)
                        {
                            case "Farm":
                            task5.StartMissionsTask5();
                            
                            break;
                            case "Basement":
                                Move(command.Name);
                                WaterPurificaiton waterPurificaiton = new();
                                waterPurificaiton.BasementTask(waterPurificaiton);
                                break;
                            
                            default: System.Console.WriteLine("There is no mission in this area(room)");
                            break;
                        }
                        break;

                    default:
                        Console.WriteLine("I don't know what command.");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing World of Zuul!");
            System.Console.WriteLine();
            System.Console.WriteLine("We hope you enjoyed and gain educational information about SDGs.");
            System.Console.WriteLine();
            System.Console.WriteLine("Creators are:");
            System.Console.WriteLine();
            System.Console.WriteLine("___Vedat Esendag___");
            System.Console.WriteLine("___Altan Esmer___");
            System.Console.WriteLine("___Frederik Handberg___");
            System.Console.WriteLine("___Ignat Bozhinov___");
            System.Console.WriteLine("___Leonardo Gianola___");
            System.Console.WriteLine("___Habib Ahmed Wasi___\n");
            System.Console.WriteLine("            ^^                   @@@@@@@@@");   
            System.Console.WriteLine("       ^^       ^^            @@@@@@@@@@@@@@@");
            System.Console.WriteLine("                           @@@@@@@@@@@@@@@@@@              ^^");
            System.Console.WriteLine("                           @@@@@@@@@@@@@@@@@@@@");
            System.Console.WriteLine(" ~~~~ ~~ ~~~~~ ~~~~~~~~ ~~ &&&&&&&&&&&&&&&&&&&& ~~~~~~~ ~~~~~~~~~~~ ~~~");
            System.Console.WriteLine(" ~         ~~   ~  ~       ~~~~~~~~~~~~~~~~~~~~ ~       ~~     ~~ ~");
            System.Console.WriteLine("   ~      ~~      ~~ ~~ ~~  ~~~~~~~~~~~~~ ~~~~  ~     ~~~    ~ ~~~  ~ ~~");
            System.Console.WriteLine("   ~  ~~     ~         ~      ~~~~~~  ~~ ~~~       ~~ ~ ~~  ~~ ~");
            System.Console.WriteLine(" ~  ~       ~ ~      ~           ~~ ~~~~~~  ~      ~~  ~             ~~");
            System.Console.WriteLine("       ~             ~        ~      ~      ~~   ~             ~\n");
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


        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the World of Zuul! :)");
            System.Console.WriteLine("╔╦╦╦═╦╗╔═╦═╦══╦═╗");
            System.Console.WriteLine("║║║║╩╣╚╣═╣║║║║║╩╣");
            System.Console.WriteLine("╚══╩═╩═╩═╩═╩╩╩╩═╝");
            System.Console.WriteLine("I'm the mayor of this city");
            System.Console.WriteLine();
            Console.WriteLine("World of Zuul is a text-based adventure game, \nwhich focus to contribute UN SDGs and educate players to improve life infrastructure in the world");
            System.Console.WriteLine();
            System.Console.WriteLine("Do not forget! Your aim is to apply SDGs to future people and save the city. Good Luck!");
            System.Console.WriteLine();
            System.Console.WriteLine("First enter your name hero!!");
            //I used public struct to define name of hero globally
            Hero hero = new Hero();
            hero.PlayerName = Console.ReadLine();
            System.Console.WriteLine();
            if (hero.PlayerName == "")//if name is empty, Mr Eco name is tagged to the user
            {
                System.Console.WriteLine("You dont prefer to say your name ____ OK.");
                System.Console.WriteLine();
                System.Console.WriteLine("I'm going to call you Mr Eco");
                hero.PlayerName = "Mr Eco";
                System.Console.WriteLine();
                System.Console.WriteLine($"Good to see you {hero.PlayerName}");
            }
            else
            {
                System.Console.WriteLine("Nice name :)");
                System.Console.WriteLine();
                System.Console.WriteLine($"Good to see you {hero.PlayerName}");
            }
            System.Console.WriteLine("Note: When the game ends for any reason, you are going to hear a voice. This is a message that tells you the game reached the end.");
            PrintHelp();
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.WriteLine("You are lost. You are alone. This is not the best moment in your life, is it?");
            System.Console.WriteLine();
            Console.WriteLine("You wander around the Sønderborg city, which located in South Denmark next to the Baltic Sea.");
            System.Console.WriteLine();
            System.Console.WriteLine("You need to search for something or ... someone to save yourself in this situation.");
            Console.WriteLine();
            Console.WriteLine("Navigate by typing 'north', 'south', 'east', or 'west'.");
            Console.WriteLine("Type 'look' for more details about environment.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'help' to print this message again.");
            System.Console.WriteLine("Type 'talk' to talk with NPCs.");
            System.Console.WriteLine("Type accept to accept missions that are given by NPCs.");
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
                default: System.Console.WriteLine("There is nobody to talk with.");
                break;
            }
            
        }

        private static void Accept()
        {
            System.Console.WriteLine("You had accepted the mission.");
            System.Console.WriteLine();
        }
    }
}
