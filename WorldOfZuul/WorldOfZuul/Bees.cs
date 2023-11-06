using System;
using static WorldOfZuul.Program;
namespace WorldOfZuul
{
    public class Task5
    {
        public static void HiveQuiz()
        {
            //Quiz part to obtain materials
            Bees bees = new();
            NPCs communicate = new();
            Hero hero = new Hero();
            int count = 0;
            System.Console.WriteLine("Welcome to last mission.");
            System.Console.WriteLine();
            System.Console.WriteLine("Finally, when you complete this mission, you will have your goals.");
            System.Console.WriteLine();
            System.Console.WriteLine("You need to build new hives to create advanced infrastructure of honey production for bees.");
            System.Console.WriteLine();
            System.Console.WriteLine("   _   _");
            System.Console.WriteLine("  ( | / )");
            System.Console.WriteLine("\\\\ ||/,'");
            System.Console.WriteLine("('')(_)()))=");
            System.Console.WriteLine("    <\\\\\n");
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
                        break;
                    }
                    else if (ans1 == 17)
                    {
                        System.Console.WriteLine("Correct");
                        System.Console.WriteLine();
                        System.Console.WriteLine("You know SDGs. Nice for you!");
                        count++;
                    }
                    else
                    {
                        System.Console.WriteLine($"It's wrong. I am not going to give my tools to you, {hero.PlayerName}");
                        break;
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
                        count++;
                    }
                    else
                    {
                        System.Console.WriteLine($"It's wrong. I am not going to give my tools to you, {hero.PlayerName}");
                        break;
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
                        count++;
                    }
                    else
                    {
                        System.Console.WriteLine($"It's wrong. I am not going to give my tools to you, {hero.PlayerName}");
                        break;
                    }
                    System.Console.WriteLine("Now, I'm asking the final question");
                    System.Console.WriteLine();
                    System.Console.WriteLine("Which honey bees can sting? [Female/Male]");
                    string? ans4 = Console.ReadLine();
                    System.Console.WriteLine();
                    ans4.ToLower();
                    if (ans4 == "female")
                    {
                        System.Console.WriteLine($"Well done {hero.PlayerName}. You passed my quiz :)");
                        System.Console.WriteLine();
                        System.Console.WriteLine("You are deserved my tools and materials within my trust");
                        count++;
                    }
                    else
                    {
                        System.Console.WriteLine($"It's wrong. I am not going to give my tools to you, {hero.PlayerName}"); 
                    }
                    if (count == 4)
                    {
                        System.Console.WriteLine("Now you have the materials for building new hives for bees.");
                        System.Console.WriteLine();
                        System.Console.WriteLine("But you need to communcite with bees for this construction. Bees also have some trust issues to humans.");
                        System.Console.WriteLine();
                        System.Console.WriteLine("I will provide you some sort of notes for making comminication with bees easier.\n");
                        bees.Completed1 = true;

                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("You did not pass my quiz.");
                        bees.Completed1 = false;
                        break;
                        
                    }
                }
            }
           
        }
        //Part 2
        public static void CommunicationWithBees()
        {
            Bees bees = new();
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
            System.Console.WriteLine("Be careful while talking with queen!\n");
            System.Console.WriteLine("   __         .' '.");
            System.Console.WriteLine(" _/__)        .   .       .");
            System.Console.WriteLine("(8|)_}}- .      .        .");
            System.Console.WriteLine(" `\\__)    '. . ' ' .  . '\n");
            communicate.NpcName2 = "Queen";
            System.Console.WriteLine();
            System.Console.WriteLine("Introduce yourself by telling your name first.");
            string? name = Console.ReadLine();
            int count = 0;
            bool cont = true;
            if (name == "")
            {
                System.Console.WriteLine("Why are you not telling your name to her!!");
                System.Console.WriteLine();
                System.Console.WriteLine("You rejected!!!");
                return;
            }
            else
            {
                while (cont)
                {
                    System.Console.WriteLine(communicate.NpcName2);
                    System.Console.WriteLine();
                    System.Console.WriteLine("__Wzzzzzzzzzwz__");
                    System.Console.WriteLine();
                    System.Console.WriteLine(name);
                    string? ans1 = Console.ReadLine();
                    ans1.ToLower();
                    if (ans1 == "hi" || ans1 == "hello")
                    {
                        System.Console.WriteLine("Wzzwwwwz - [Nice to meet you]");
                        count++;
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
                        count++;
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
                        count++;
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
                    if (ans4 == "for bees")
                    {
                        System.Console.WriteLine("G ---- good. L-- eee - lets ----- start");
                        count++;
                    }
                    else
                    {
                        System.Console.WriteLine("WZZZZZZZZZZZZZZZZZZZZ!!! - [Anger]");
                        return;
                    }
                    if (count == 4)
                    {
                        System.Console.WriteLine("You have finished second mission successfully. Well done!\n");
                        bees.Completed2 = true;
                        cont = false;
                        System.Console.WriteLine("         .' '.              __");
                        System.Console.WriteLine(".        .   .             (__\\");
                        System.Console.WriteLine("  .         .         . -{{_(|8)");
                        System.Console.WriteLine("     ' .  . ' ' .  . '     (__/\n");
            
                    }
                    else
                    {
                        System.Console.WriteLine("Communication with bees mission isn't completed. Try again later.");
                        bees.Completed2 = false;
                        return;
                    }
                }
               
            }
        }
        //Final part
        public static void BuildHives()
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