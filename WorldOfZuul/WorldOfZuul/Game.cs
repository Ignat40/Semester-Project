using System.Formats.Asn1;
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
            Room? farm = new("Farm", "There is a farm in front of you. Beautfiul flowers and huge trees are covering all way around. If you look more carefully, you can see that there are lots of hives for bees But why honey is not existing inside the hives? Interesting!");
            Room? beach = new("Beach", "Your are now locating on a local beach. The gold color sand and beautiful sea covers all around you. But it looks very dirty. People didn't behave excellently to this beach.");
            Room? lab = new("Lab", "You're in university's lab. It contains lots of equipment, for instance,  broken water filtration system and other tools. There is a stairs to the rooftop of the university east of the lab. Labs are useful rooms for development, this one is also looking good.\nYou saw Professor next to the mainframe computers. Should you talk wit him?"); 
            Room? rooftop = new("Rooftop", "That's the highest point of university. It's mostly empty. Only one red light is situating next to the edge of the rooftop. When looking at around, this empty part can be useful for building something there ...... something cool.");
            Room? basement = new("Basement","base...");
            outside.SetExits(basement, farm, lab, beach); // North, East, South, West
            //Need to create visual map for the rooms
            farm.SetExit("west", outside);

            beach.SetExit("east", outside);

            lab.SetExits(outside, rooftop, null, null);

            rooftop.SetExit("west", lab);

            currentRoom = outside;
        }

        public void Play()
        {
            Parser parser = new();

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
                            HiveQuiz();
                            ComminicationWithBees();
                            BuildHives();
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
            System.Console.WriteLine("▄█▀▀║░▄█▀▄║▄█▀▄║██▀▄║");
            System.Console.WriteLine("██║▀█║██║█║██║█║██║█║");
            System.Console.WriteLine("▀███▀║▀██▀║▀██▀║███▀║");
            System.Console.WriteLine("───────────────────────");
            System.Console.WriteLine("───▐█▀▄─ ▀▄─▄▀ █▀▀──█───");
            System.Console.WriteLine("───▐█▀▀▄ ──█── █▀▀──▀───");
            System.Console.WriteLine("───▐█▄▄▀ ──▀── ▀▀▀──▄───");
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
                default: System.Console.WriteLine("There is nobody to talk with.");
                break;
            }
            
        }

        private static void Accept()
        {
            System.Console.WriteLine("You had accepted the mission.");
            
        }

        //Mission 5 - Development start point
        //Part 1
        private static void HiveQuiz()
        {
            //Quiz part to obtain materials
            NPCs communicate = new();
            Hero hero = new Hero();
            int count = 0;
            System.Console.WriteLine("Welcome to last mission.");
            System.Console.WriteLine();
            System.Console.WriteLine("Finally, when you complete this mission, you will have reached your goal.");
            System.Console.WriteLine();
            System.Console.WriteLine("You need to build new hives to create advanced infrastructure of honey production for bees.");
            System.Console.WriteLine();
            System.Console.WriteLine("For this, you will need materials. You need to gain beekeeper trust to obtain materails and build hives.");
            System.Console.WriteLine();
            System.Console.WriteLine("GOOD LUCK!!!");
            communicate.NpcName = "Beekeeper Wazolski";
            communicate.Sentence = "Welcome to my farm. My name is Wazolski. To obtain my tools and materials for hives, you need to pass my quiz. You know..... trust issues.";
            System.Console.WriteLine($"Hey this is {communicate.NpcName}, standing next to the truck.");
            System.Console.WriteLine();
            System.Console.WriteLine("Go and talk with him.");
            string? helper = Console.ReadLine();
            helper.ToLower();
            if (helper == "talk")
            {
                System.Console.WriteLine($"Hi! {communicate.Sentence}");
            }
            else
            {
                System.Console.WriteLine("You don't want to talk? Ok then, another time.");
                return;
            }
            bool cont = true;
            while (cont)
            {
                System.Console.WriteLine("First question.");
                System.Console.WriteLine();
                System.Console.WriteLine("But before that, what is your name?");
                hero.PlayerName = Console.ReadLine();
                if (hero.PlayerName == "")
                {
                    System.Console.WriteLine("I am not going to give my tools to no name person.");
                    break;
                }
                else
                {
                    System.Console.WriteLine($"Nice to meet you {hero.PlayerName}");
                    System.Console.WriteLine();
                    System.Console.WriteLine("How many SDGs are existing?");
                    if (!int.TryParse(Console.ReadLine(), out int ans1))
                    {
                        System.Console.WriteLine("Invalid data entry");
                        System.Console.WriteLine("You need to learn the difference between texts and numbers");
                        cont = false;
                    }
                    else if (ans1 == 17)
                    {
                        System.Console.WriteLine("Correct");
                        System.Console.WriteLine();
                        System.Console.WriteLine("You know SDGs. Nice for you!");
                        //continue;
                        count++;
                    }
                    else
                    {
                        System.Console.WriteLine($"It's wrong. I am not going to give my tools to you, {hero.PlayerName}");
                        cont = false;
                    }
                    System.Console.WriteLine("Second question.");
                    System.Console.WriteLine();
                    System.Console.WriteLine("Which SDG is supported in this task (Name of the SDG)");
                    string? ans2 = Console.ReadLine();
                    ans2.ToLower();
                    if (ans2 == "life on land")
                    {
                        System.Console.WriteLine("Correct");
                        System.Console.WriteLine();
                        System.Console.WriteLine("Did you prepare for this?");
                        //continue;
                        count++;
                    }
                    else
                    {
                        System.Console.WriteLine($"It's wrong. I am not going to give my tools to you, {hero.PlayerName}");
                        cont = false;
                    }
                    System.Console.WriteLine("Third question");
                    System.Console.WriteLine();
                    System.Console.WriteLine("What is the purpose of the SDGs?");
                    System.Console.WriteLine("a)\tIncrease population.");
                    System.Console.WriteLine("b)\tAim to transform our world.");
                    System.Console.WriteLine("c\tMake United Nations rich.");
                    string? ans3 = Console.ReadLine();
                    if (ans3 == "b")
                    {
                        System.Console.WriteLine("CORRECT!!");
                        System.Console.WriteLine();
                        System.Console.WriteLine("Let's go!!!");
                        //continue;
                        count++;
                    }
                    else
                    {
                        System.Console.WriteLine($"It's wrong. I am not going to give my tools to you, {hero.PlayerName}");
                        cont = false;
                    }
                    System.Console.WriteLine("Now, I'm asking the final question");
                    System.Console.WriteLine();
                    System.Console.WriteLine("Which honey bees can sting? [Female/Male]");
                    string? ans4 = Console.ReadLine();
                    System.Console.WriteLine();
                    if (ans4 == "Female")
                    {
                        System.Console.WriteLine($"Well done {hero.PlayerName}. You passed my quiz :)");
                        System.Console.WriteLine();
                        System.Console.WriteLine("You are deserved my tools and materials within my trust");
                        count++;
                        continue;
                    }
                    else
                    {
                        System.Console.WriteLine($"It's wrong. I am not going to give my tools to you, {hero.PlayerName}");
                    cont = false; 
                    }
                    if (count == 4)
                    {
                        System.Console.WriteLine("Now you have the materials for building new hives for bees.");
                        System.Console.WriteLine();
                        System.Console.WriteLine("But you need to communcite with bees for this construction. Bees also have some trust issues to humans.");
                        System.Console.WriteLine();
                        System.Console.WriteLine("I will provide you some sort of notes for making comminication with bees easier.");
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("You did not pass my quiz. So,");
                        System.Console.WriteLine();
                        System.Console.WriteLine($"I am not going to give my tools to you, {hero.PlayerName}");
                        cont = false;
                    }
                }
            }
           
        }
        //Part 2
        private static void ComminicationWithBees()
        {
            NPCs communicate = new();
            communicate.NpcName = "Wazolski";
            communicate.Sentence = "I'm bringing you my secret friendship receipt, which contains tips about how to communicate with bees. Good Luck! Do not make them angry.";
            System.Console.WriteLine($"Hi, it's me, {communicate.NpcName}.\n {communicate.Sentence}");
            System.Console.WriteLine();
            System.Console.WriteLine($"{communicate.NpcName}'s secret friendship receipt!");
            System.Console.WriteLine();
            System.Console.WriteLine("You are going to talk with queen bee.");
            System.Console.WriteLine();
            System.Console.WriteLine("1-\t[Wzzzzzzzzzwz] = Hi, You need to say hello or hi to queen bee.");
            System.Console.WriteLine("2-\t[WzWzWzWz] = What is your purpose of visiting my kingdom, You need to tell her about SDG and honey - both of them");
            System.Console.WriteLine("3-\t[Wzzzzzzzzzzzzzzzz] = I understand, You can either say nice, okay or good.");
            System.Console.WriteLine("-\t[WzzzzzzWzz] = I accept your offer, I hope she is going to say this sentence to you. You must say [For bees] to caress her soul.");
            System.Console.WriteLine();
            System.Console.WriteLine("Be careful while talking with queen!");
            communicate.NpcName2 = "Queen";
            System.Console.WriteLine();
            System.Console.WriteLine("Introduce yourself by telling your name first.");
            string? name = Console.ReadLine();
            if (name == "")
            {
                System.Console.WriteLine("Why are you not telling your name to her!!");
                System.Console.WriteLine();
                System.Console.WriteLine("You rejected!!!");
                return;
            }
            else
            {
                System.Console.WriteLine(communicate.NpcName2);
                System.Console.WriteLine();
                System.Console.WriteLine("___Wzzzzzzzzzwz___");
                System.Console.WriteLine();
                System.Console.WriteLine(name);
                string? ans1 = Console.ReadLine();
                ans1.ToLower();
                if (ans1 == "hi" || ans1 == "hello")
                {
                    System.Console.WriteLine("Wzzwwwwz - [Nice to meet you]");
                }
                else
                {
                    System.Console.WriteLine("WZZZZZZZZZZZZZZZZZZZZ!!! - [Anger]");
                    return;
                }
                System.Console.WriteLine(communicate.NpcName2);
                System.Console.WriteLine();
                System.Console.WriteLine("WzWzWzWz");
                System.Console.WriteLine();
                System.Console.WriteLine(name);
                string? ans2 = Console.ReadLine();
                ans2.ToLower();
                if (ans2.Contains("sdg") && ans2.Contains("honey"))
                {
                    System.Console.WriteLine("WzzHoneyWzz - [Honey is improtant for us].");
                }
                else
                {
                    System.Console.WriteLine("WZZZZZZZZZZZZZZZZZZZZ!!! - [Anger]");
                    return;
                }
                System.Console.WriteLine(communicate.NpcName2);
                System.Console.WriteLine();
                System.Console.WriteLine("Wzzzzzzzzzzzzzzzz");
                System.Console.WriteLine();
                System.Console.WriteLine(name);
                string? ans3 = Console.ReadLine();
                ans3.ToLower();
                if (ans3 == "nice" || ans3 == "okay" || ans3 == "good")
                {
                    System.Console.WriteLine("Wzwwwzz - [You're good at listening].");
                }
                else
                {
                    System.Console.WriteLine("WZZZZZZZZZZZZZZZZZZZZ!!! - [Anger]");
                    return;
                }
                System.Console.WriteLine(communicate.NpcName2);
                System.Console.WriteLine();
                System.Console.WriteLine("WzzzzzzWzz");
                System.Console.WriteLine();
                System.Console.WriteLine(name);
                string? ans4 = Console.ReadLine();
                ans4.ToLower();
                if (ans4 == "For bees")
                {
                    System.Console.WriteLine("G ---- good. L-- eee - lets ----- start");
                }
                else
                {
                    System.Console.WriteLine("WZZZZZZZZZZZZZZZZZZZZ!!! - [Anger]");
                    return;
                }
            }
        }

        private static void BuildHives()
        {
            NPCs communicate = new();
            communicate.NpcName = "Wazolski";
            communicate.NpcName2 = "Queen";
            System.Console.WriteLine(communicate.NpcName2);
            System.Console.WriteLine();
            System.Console.WriteLine("Wzzzwzzzzzzzzzzzz - [Now you can build hives for our kingdom].");
            System.Console.WriteLine();
            System.Console.WriteLine(communicate.NpcName);
            System.Console.WriteLine();
            System.Console.WriteLine("Well, use my tools to build hives for honey bees.");
            Random random = new();
            int totalHives = random.Next(4,10);
            Bees bees = new();
            bees.HiveID = 0;
            System.Console.WriteLine(communicate.NpcName2);
            System.Console.WriteLine();
            System.Console.WriteLine("Wzzzzzzzzzzwzzzzzzzz");
            System.Console.WriteLine();
            System.Console.WriteLine(communicate.NpcName);
            System.Console.WriteLine();
            System.Console.WriteLine($"She is trying to tell you that you must build {totalHives} hives for improving infrastructure of honey production.");
            System.Console.WriteLine();
            System.Console.WriteLine("Let's start.");
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Building hives...");
            for(int i = 0; i <= totalHives; i++)
            {
                bees.HiveID++;
                System.Console.WriteLine($"Hive number {bees.HiveID} had built!");
                //Timer needed to develop better visual
            }
            System.Console.WriteLine("Mission is completed successfully.");
            System.Console.WriteLine();
            System.Console.WriteLine("Well done!");
        }
    }
}
