using System.Diagnostics;
using System.Drawing;
using System.Formats.Asn1;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace WorldOfZuul
{
    class WaterPurificaiton
    {
        public bool talkedToPlumber = false;
        public static ConsoleColor[] pipeColor =
        {
            ConsoleColor.Red,
            ConsoleColor.White,
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Magenta
        };
        public static int isComplete = 0;
        public static int beforeChallengeSelection = 0;
        public static int afterTalkSelection = 0;
        public static double pipe1pH = 6.8,
            pipe2pH = 7.2,
            pipe3pH = 5.2,
            pipe4pH = 7.5,
            pipe5pH = 9.5,
            pipe6pH = 4.0,
            pipe7pH = 8.0;
        public static double[] pipepH = { 6.8, 7.2, 5.2, 7.5, 9.5, 4.0, 8.0 };
        public static string pipe1Ans = "safe",
            pipe2Ans = "safe",
            pipe3Ans = "unsafe",
            pipe4Ans = "safe",
            pipe5Ans = "unsafe",
            pipe6Ans = "unsafe",
            pipe7Ans = "safe";

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
            string[] bChallenge =
            {
                "What are you witing for",
                "We need to fix the pipes ass soon possible.",
                "Lets go",
                "Lets start"
            };
            string[] aChallenge =
            {
                "Thank you for your help",
                "Thanks!",
                "There are more things that you can do around the school to make  this place better.",
                "you are the best"
            };
            if (WaterPurificaiton.isComplete == 0)
            {
                if (WaterPurificaiton.beforeChallengeSelection == 0)
                {
                    Console.WriteLine(
                        "This is the  main message that is seen when the player talks with the npc for the fist time"
                    );
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
                    Console.WriteLine(
                        "This is the message that is seen after completing the challenge"
                    );
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
    
        
        public void filtrationTest()
        {
            int correctNum = 0;
            Console.WriteLine("Safe water pH level is ranged between 6.5pH and 8.5pH");
            Console.WriteLine(
                "Type safe to  the pH leves range between the safe range and  unsafe the ones that are not in the safe range"
            );
            Console.WriteLine("---------------");
            while (correctNum != 8)
            {
                correctNum = 0;
                Console.WriteLine($"Pipe1-->{pipe1pH}");
                string ans1 = Console.ReadLine().ToLower();
                if (ans1 == pipe1Ans)
                {
                    correctNum++;
                }
                Console.WriteLine($"Pipe2-->{pipe2pH}");
                string ans2 = Console.ReadLine().ToLower();
                if (ans2 == pipe2Ans)
                {
                    correctNum++;
                }
                Console.WriteLine($"Pipe3-->{pipe3pH}");
                string ans3 = Console.ReadLine().ToLower();
                if (ans3 == pipe3Ans)
                {
                    correctNum++;
                }
                Console.WriteLine($"Pipe4-->{pipe4pH}");
                string ans4 = Console.ReadLine().ToLower();
                if (ans4 == pipe4Ans)
                {
                    correctNum++;
                }
                Console.WriteLine($"Pipe5-->{pipe5pH}");
                string ans5 = Console.ReadLine().ToLower();
                if (ans5 == pipe5Ans)
                {
                    correctNum++;
                }
                Console.WriteLine($"Pipe6-->{pipe6pH}");
                string ans6 = Console.ReadLine().ToLower();
                if (ans6 == pipe6Ans)
                {
                    correctNum++;
                }
                Console.WriteLine($"Pipe7-->{pipe7pH}");
                string ans7 = Console.ReadLine().ToLower();
                if (ans7 == pipe7Ans)
                {
                    correctNum++;
                }

                if (correctNum == 7)
                {
                    Console.WriteLine("You have answered all of them correctly");
                    correctNum++;
                    Console.WriteLine("This list shows the pipes that failed the test:");
                    Console.WriteLine("---------------");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("1.Pipe");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("2.Pipe");
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3.Pipe");
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("4.Pipe");
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("5.Pipe");
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("6.Pipe");
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("7.Pipe");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                    Console.WriteLine("---------------");
                    Console.WriteLine();
                    //Filtration();
                    Console.WriteLine("Burasda filtration test olurdu normalde");
                }
                else
                {
                    Console.WriteLine("Answer them again.");
                }
            }
        }
        //burasini filtration test gibin yapip gurtul
        /*
        public void Filtration()
        {
            double target = 7.5;

            Console.WriteLine("This is the list of all the pH levels of the pipes:");
            Console.WriteLine("---------------");
            Console.WriteLine($"Pipe1-->{pipe1pH}");

            Console.WriteLine($"Pipe2-->{pipe2pH}");

            Console.WriteLine($"Pipe3-->{pipe3pH}");

            Console.WriteLine($"Pipe4-->{pipe4pH}");

            Console.WriteLine($"Pipe5-->{pipe5pH}");

            Console.WriteLine($"Pipe6-->{pipe6pH}");

            Console.WriteLine($"Pipe7-->{pipe7pH}");
            Console.WriteLine("---------------");
            Console.WriteLine();
            Console.WriteLine(
                "The optimal ph level is 7.5. We will need to add soda ash or sodium bisulfate  to make all of them the pH level"
            );
            Console.WriteLine();
            Console.WriteLine(
                "For example to increase the pH level from 7 to 7.5 you will need to add 0.5 grams of soda ash."
            );
            Console.WriteLine(
                "To decrase the pH level from 8 to 7.5 you will need to add sodium bisulfate."
            );

            while (true)
            {
                int i = 0;
                int x = 1;
                int z = 0;
                
                while (i < 7 && z == 0)
                {
                    Console.WriteLine($"Pipe{x}-->{pipepH[i]}");
                    x++;
                    Console.Write("Enter what you want to add:");
                    string input = Console.ReadLine();
                    //double num = double.Parse(input);
                    if (!double.TryParse(Console.ReadLine(), out double num))
                    {
                        System.Console.WriteLine("Invalid data entry");
                    }

                    else
                    {
                        double finalNum = num + pipepH[i];
                        if (finalNum == target)
                        {
                            i++;
                            Console.WriteLine("Correct!");
                        }
                        else
                        {
                            
                            Console.WriteLine("Incorrect");
                            z++;
                        }
                    }
                    
                }
                Console.WriteLine("They aint believe in us GOD DID!");
                break;
            }
        }
        */

        private void PipePuzzle(WaterPurificaiton waterPurificaiton)
        {
            string[] pipe =
            {
                "Disconnected",
                "Disconnected",
                "Disconnected",
                "Disconnected",
                "Disconnected",
                "Disconnected",
                "Disconnected"
            };
            string[] cSequence = { "Blue", "Red", "Green", "Yellow", "Magenta", "Cyan", "White" };
            int sequenceIndex = 0;
            Console.WriteLine(
                "There is a secret sequence to connect all 7 pipes. You need to solve the secret sequence and connect them. If you make a mistake you have to star all over  again so becarefull."
            );
            while (true)
            {
                WaterPurificaiton.DisplayPipe(pipe);

                Console.WriteLine($"Connect the {cSequence[sequenceIndex]} pipe.");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine(
                        "Invalid input. Please enter a number between 1 and 7 or 8 to exit."
                    );
                    continue;
                }
                else if (choice == 8)
                    break;

                if (choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid choice. Please choose a number between 1 and 7.");
                    continue;
                }

                if (
                    cSequence[sequenceIndex] == "Blue" && choice == 3
                    || cSequence[sequenceIndex] == "Red" && choice == 1
                    || cSequence[sequenceIndex] == "Green" && choice == 6
                    || cSequence[sequenceIndex] == "Yellow" && choice == 5
                    || cSequence[sequenceIndex] == "Magenta" && choice == 7
                    || cSequence[sequenceIndex] == "Cyan" && choice == 4
                    || cSequence[sequenceIndex] == "White" && choice == 2
                )
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
                    Console.WriteLine(
                        "Congratulations! You've successfully connected all the pipes."
                    );
                    WaterPurificaiton.isComplete = 1;
                    filtrationTest();
                    break;
                }
            }
        }
    }
}
