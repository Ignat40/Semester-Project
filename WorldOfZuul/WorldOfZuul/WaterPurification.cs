namespace WorldOfZuul
{
    class WaterPurificaiton
    {
        public bool talkedToPlumber = false;
        public static ConsoleColor[] pipeColor = { ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Magenta };
        public static void DisplayPipe(string[] pipe)
        {
            Console.WriteLine("---------------");
            for (int i = 0; i < pipe.Length; i++)
            {
                if(pipe[i] == "Connected")
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

        public void BasementTask(WaterPurificaiton waterPurificaiton)
        {
            bool plumb = true;
            while (plumb)
            {

                Console.WriteLine("1.Talk\n2.Challenge\n3.Exit");
                string? basementChoice = Console.ReadLine().ToLower();
                if (basementChoice == "talk")
                {
                    Console.WriteLine("BLA BLA BLA BLA");
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
            

            string[] pipe ={"Disconnected","Disconnected","Disconnected","Disconnected","Disconnected","Disconnected","Disconnected"};
            string[] cSequence = { "Blue", "Red", "Green", "Yellow","Magenta","Cyan","White"};
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
                    else if(choice == 8)
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
                        break;
                    }
                }
        }
 

    }
}