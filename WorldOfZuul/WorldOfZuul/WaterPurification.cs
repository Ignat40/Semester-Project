using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace WorldOfZuul
{
    class WaterPurificaiton
    {
        public bool talkedToPlumber = false;
        public static ConsoleColor[] pipeColor = { ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Magenta };
        public static int isComplete = 0;
        public static int beforeChallengeSelection = 0;
        public static int afterTalkSelection = 0;



        public static void DisplayPipe(string[] pipe)
        {
            Console.WriteLine("---------------");
            for (int i = 0; i < pipe.Length; i++)
            {
                if (pipe[i] == "Connected")
                {
                    Console.ForegroundColor = WaterPurificaiton.pipeColor[i];
                }
                Console.WriteLine($"{i + 1}.{pipe[i]}");
                Console.ResetColor();
            }
            Console.WriteLine("---------------");
        }

        public static void ConnectPipe(string[] pipe, int choice)
        {
            if (pipe[choice - 1] == "Disconnected")
            {
                pipe[choice - 1] = "Connected";
                Console.ForegroundColor = WaterPurificaiton.pipeColor[choice - 1];
                Console.WriteLine($"Pipe {choice} connected!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Pipe is already connected");
            }
        }
        public static void ResetPipe(string[] pipe)
        {
            for (int i = 0; i < pipe.Length; i++)
            {
                pipe[i] = "Disconnected";
            }
        }
        public void PlumberTalk()
        {
            string[] bChallenge = { "What are you witing for", "We need to fix the pipes ass soon possible.", "Lets go", "Lets start" };
            string[] aChallenge = { "Thank you for your help", "Thanks!", "There are more things that you can do around the school to make  this place better.", "" };
            if (WaterPurificaiton.isComplete == 0)
            {
                if (WaterPurificaiton.beforeChallengeSelection == 0)
                {
                    Console.WriteLine("This is the  main message that is seen when the player talks with the npc for the fist time");
                    WaterPurificaiton.beforeChallengeSelection++;
                }
                else
                {
                    Random random = new Random();
                    int randomIndex = random.Next(bChallenge.Length);
                    string randomString = bChallenge[randomIndex];
                    Console.WriteLine(randomString);
                }

            }
            else if (WaterPurificaiton.isComplete == 1)
            {
                if (WaterPurificaiton.afterTalkSelection == 0)
                {
                    Console.WriteLine("This is the message that is seen after completing the challenge");
                    WaterPurificaiton.afterTalkSelection++;
                }
                else
                {
                    Random random = new Random();
                    int randomIndex = random.Next(aChallenge.Length);
                    string randomString = aChallenge[randomIndex];
                    Console.WriteLine(randomString);
                }
            }
        }
        public void BasementTask(WaterPurificaiton waterPurificaiton)
        {
            bool plumb = true;
            while (plumb)
            {

                Console.WriteLine("1.Talk\n2.Challenge\n3.Exit");
                string? basementChoice = Console.ReadLine().ToLower();
                if (basementChoice == "talk")
                {
                    PlumberTalk();
                    waterPurificaiton.talkedToPlumber = true;
                }
                else if (basementChoice == "challenge" && !waterPurificaiton.talkedToPlumber)
                {
                    Console.WriteLine("You need to talk with the plumber first!");
                }
                else if (basementChoice == "challenge" && waterPurificaiton.talkedToPlumber)
                {
                    PipePuzzle(waterPurificaiton);
                }
                else if (basementChoice == "exit")
                {
                    Console.WriteLine("Exiting");
                    plumb = false;
                }
                else
                {
                    Console.WriteLine("INCORRECT INPUT!");
                }
            }

        }
        private void PipePuzzle(WaterPurificaiton waterPurificaiton)
        {


            string[] pipe = { "Disconnected", "Disconnected", "Disconnected", "Disconnected", "Disconnected", "Disconnected", "Disconnected" };
            string[] cSequence = { "Blue", "Red", "Green", "Yellow", "Magenta", "Cyan", "White" };
            int sequenceIndex = 0;
            Console.WriteLine("There is a secret sequence to connect all 7 pipes. You need to solve the secret sequence and connect them. If you make a mistake you have to star all over  again so becarefull.");
            while (true)
            {
                WaterPurificaiton.DisplayPipe(pipe);

                Console.WriteLine($"Connect the {cSequence[sequenceIndex]} pipe.");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 7 or 8 to exit.");
                    continue;
                }
                else if (choice == 8)
                    break;

                if (choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid choice. Please choose a number between 1 and 7.");
                    continue;
                }

                if (cSequence[sequenceIndex] == "Blue" && choice == 3 ||
                    cSequence[sequenceIndex] == "Red" && choice == 1 ||
                    cSequence[sequenceIndex] == "Green" && choice == 6 ||
                    cSequence[sequenceIndex] == "Yellow" && choice == 5 ||
                    cSequence[sequenceIndex] == "Magenta" && choice == 7 ||
                    cSequence[sequenceIndex] == "Cyan" && choice == 4 ||
                    cSequence[sequenceIndex] == "White" && choice == 2)
                {
                    WaterPurificaiton.ConnectPipe(pipe, choice);
                    sequenceIndex++;
                }
                else
                {
                    Console.WriteLine("Wrong pipe! All pipes are disconnected. Start over.");
                    WaterPurificaiton.ResetPipe(pipe);
                    sequenceIndex = 0;
                }

                if (sequenceIndex == 7)
                {
                    WaterPurificaiton.DisplayPipe(pipe);
                    Console.WriteLine("Congratulations! You've successfully connected all the pipes.");
                    WaterPurificaiton.isComplete = 1;
                    break;
                }
            }
        }


    }
}