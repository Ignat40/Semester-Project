using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Versioning;
using System.Threading;
using static WorldOfZuul.Program;
namespace WorldOfZuul
{
    public class HoneyHive
    {
        static int HiveCreated = 0;
        public int Count = 0;
        public bool isCompletedHiveQuiz = false;
        public bool isCompletedCommunicationWithBees = false;
        public static bool isCompletedTicTacToeGame = false;
        public static bool isAllMissionsCompleted = false;
        public string Name {get; set;}
        public int Level {get; set;}
        public int Honey {get; set;}
        static List<HoneyHive> honeyHives = new List<HoneyHive>();
        static int Resources = 200;
        static int Score = 0;
        static char[,] Board = {
        {'1', '2', '3'},
        {'4', '5', '6'},
        {'7', '8', '9'}
    };

        static char CurrentPlayer = 'X';

        public HoneyHive(string name, int level)
        {
            Name = name;
            Level = level;
            Honey = 0;
        }
        
        public void StartMissionsTask5(Player player)
        {
            Console.WriteLine("Welcome to the world of missions!");

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Start Hive Quiz");
                Console.WriteLine("2. TicTacToe game");
                Console.WriteLine("3. Start Communication with Bees");
                Console.WriteLine("4. Build Hives");
                Console.WriteLine("5. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        if (!isCompletedHiveQuiz)
                        {
                            HiveQuiz(player);
                        }
                        else
                        {
                            Console.WriteLine("You have already completed the Hive Quiz.");
                        }
                        break;

                    case 2:
                        if (isCompletedHiveQuiz && !isCompletedTicTacToeGame)
                        {
                            TicTacToe();
                        }
                        else if (!isCompletedHiveQuiz)
                        {
                            Console.WriteLine("You must complete the Hive Quiz before starting TicTacToe game.");
                        }
                        else
                        {
                            System.Console.WriteLine("You already compelted TicTacToe Game");
                        }
                        break;

                    case 3:
                        if (isCompletedHiveQuiz && isCompletedTicTacToeGame && !isCompletedCommunicationWithBees)
                        {
                            CommunicationWithBees();
                        }
                        else if (!isCompletedHiveQuiz)
                        {
                            Console.WriteLine("You must complete the Hive Quiz before starting Communication with Bees.");
                        }
                        else if (!isCompletedTicTacToeGame)
                        {
                            Console.WriteLine("You must complete TicTacToe game before starting Communication wiyh bees mission.");
                        }
                        else
                        {
                            Console.WriteLine("You already talked with queen bee.");
                        }
                        break;
                    
                    case 4:
                        if (isCompletedHiveQuiz && isCompletedCommunicationWithBees && isCompletedTicTacToeGame)
                        {
                            BuildHives();
                            isAllMissionsCompleted = true;
                        }
                        else if (!isCompletedHiveQuiz)
                        {
                            Console.WriteLine("You must complete the Hive Quiz before building hives.");
                        }
                        else if (!isCompletedCommunicationWithBees)
                        {
                            Console.WriteLine("You must complete Communication with Bees before building hives.");
                        }
                        else if (!isCompletedTicTacToeGame)
                        {
                            Console.WriteLine("You must complete Tic-Tac-Toe game.");
                        }
                        else
                        {
                            Console.WriteLine("You have already built the hives.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Exiting the task 5.");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        break;
                }
            }
        }

        static void MultipleChoiceQuestion(string question, Dictionary<string, string> options, string correctAnswer)
        {
            Console.WriteLine($"\n{question}");
            DisplayOptions(options);

            string userAnswer = GetUserAnswer(options.Keys.ToList());
            CheckAnswer(userAnswer, correctAnswer);
        }

        static void TrueFalseQuestion(string question, string correctAnswer)
        {
            Console.WriteLine($"\n{question}");

            string userAnswer = GetUserAnswer(new List<string> { "true", "false" });
            CheckAnswer(userAnswer, correctAnswer);
        }

        static void OpenEndedQuestion(string question, string correctAnswer)
        {
            Console.WriteLine($"\n{question}");

            string userAnswer = GetUserAnswer(null);
            CheckAnswer(userAnswer.ToLower(), correctAnswer);
        }

        static void DisplayOptions(Dictionary<string, string> options)
        {
            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key}) {option.Value}");
            }
        }

        static string GetUserAnswer(List<string> allowedOptions)
        {
            Console.Write("Your answer: ");
            string userAnswer = Console.ReadLine().ToLower();

            if (allowedOptions != null && !allowedOptions.Contains(userAnswer))
            {
                Console.WriteLine("Invalid option. Try again.");
                return GetUserAnswer(allowedOptions);
            }

            return userAnswer;
        }

        static void CheckAnswer(string userAnswer, string correctAnswer)
        {
            if (userAnswer == correctAnswer)
            {
                Console.WriteLine("Correct!");
                Score++;
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {correctAnswer.ToUpper()}.");
            }

            Thread.Sleep(1000);
        }
        
        public void HiveQuiz(Player player)
        {
            NPCs communicate = new();
            Console.WriteLine("\nWelcome to last mission.\n");
            Console.WriteLine($"Hi {player.PlayerName}");
            Console.WriteLine("Finally, when you complete this mission, you will have your goals.\n");
            Console.WriteLine("You need to build new hives to create advanced infrastructure of honey production for bees.\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   _   _");
            Thread.Sleep(100);
            Console.WriteLine("  ( | / )"); 
            Thread.Sleep(100);
            Console.WriteLine("\\\\ ||/,'");
            Thread.Sleep(100);
            Console.WriteLine("('')(_)()))=");
            Thread.Sleep(100);
            Console.WriteLine("    <\\\\\n");
            Thread.Sleep(100);
            Console.ResetColor();
            Console.WriteLine("For this, you will need resources. You need to gain beekeeper trust to obtain resources which are used to build hives.");
            Console.WriteLine();
            Console.WriteLine("GOOD LUCK!!!\n");

            communicate.NpcName = "Beekeeper Wazolski";
            communicate.Sentence = "Welcome to my farm. My name is Wazolski. To obtain my tools and materials for hives, you need to pass my quiz. You know..... trust issues.";
            System.Console.WriteLine($"Hey this is {communicate.NpcName}, standing next to the truck.");

            int maxAttempts = 2;
            int attempt = 0;

            do
            {
                if (attempt > 0)
                {
                    Console.WriteLine("\nYou can try again!");
                }

                Score = 0;

                MultipleChoiceQuestion("How many SDGs are existing?", new Dictionary<string, string> { { "a", "14" }, { "b", "17" }, { "c", "20" } }, "b");
                TrueFalseQuestion("Only female bees can sting. (True/False)", "true");
                OpenEndedQuestion("What is the name of this city", "sonderborg");
                MultipleChoiceQuestion("Which programming language is this game written in?", new Dictionary<string, string> { { "a", "Java" }, { "b", "Python" }, { "c", "C#" } }, "c");
                TrueFalseQuestion("There is a queen and king exist in every hive. (True/False)", "false");
                OpenEndedQuestion("Finally, a riddle time. I'm tall when I'm young, and I'm short when I'm old. What am I?", "candle");

                if (Score >= 5)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nYou passed the quiz!");
                    Console.ResetColor();
                    isCompletedHiveQuiz = true;
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou failed this attempt.");
                    Console.ResetColor();
                }

                attempt++;
            } while (attempt < maxAttempts);

                Console.WriteLine("You used your all attempts.");
        }

        public void CommunicationWithBees()
        {
            Console.WriteLine("\nWazolski\n");
            Console.WriteLine("As we promised, here is the guidline book.");
            Console.WriteLine("      __...--~~~~~-._   _.-~~~~~--...__");
            Thread.Sleep(100);
            Console.WriteLine("    //               `V'               \\\\ ");
            Thread.Sleep(100);
            Console.WriteLine("   //                 |                 \\\\ ");
            Thread.Sleep(100);
            Console.WriteLine("  //__...--~~~~~~-._  |  _.-~~~~~~--...__\\\\ ");
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" //__.....----~~~~._\\ | /_.~~~~----.....__\\\\");
            Thread.Sleep(100);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("====================\\\\|//====================");
            Console.WriteLine("                    `---`");
            Console.ResetColor();
            Console.WriteLine("You need to use this book to talk with Queen bee.\n");
            GuidLine(); 
            Dialogues();

        }

        public void GuidLine()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1-\t[Wzzzzzzzzzwz] = Hi, You need to say only hello or hi to queen bee.");
            Console.WriteLine("2-\t[WzWzWzWz] = What is your purpose of visiting my kingdom, You need to tell her about honey.");
            Console.WriteLine("3-\t[Wzzzzzzzzzzzzzzzz] = I understand, You can either say nice, okay or good.");
            Console.WriteLine("4-\t[WzzzzzzWzz] = I accept your offer, I hope she is going to say this sentence to you. You must say [Thank you or thanks] to caress her soul.\n");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Be careful while talking with queen!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   __         .' '.");
            Thread.Sleep(100);
            Console.WriteLine(" _/__)        .   .       .");
            Thread.Sleep(100);
            Console.WriteLine("(8|)_}}- .      .        .");
            Thread.Sleep(100);
            Console.WriteLine(" `\\__)    '. . ' ' .  . '\n");
            Thread.Sleep(100);
            Console.ResetColor();
            Console.WriteLine("Good luck!");
               
        }

        public void Dialogues()
        {
            Console.WriteLine("She is here.\n");
            Console.WriteLine("You can only do one mistake while talking therefore be careful.\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Queen - Wzzzzzzzzzwz\n");
            Thread.Sleep(1000);
            Console.ResetColor();
            string? response1 = Console.ReadLine().ToLower();
            if (response1 == "hello" || response1 == "hi")
            {
                Count++;
                Console.WriteLine("\nWazolski: Nice start!\n");
            }
            else
            {
                Count--;
            }
            Console.WriteLine("Queen - WzWzWzWz\n");
            Thread.Sleep(1000);
            string? response2 = Console.ReadLine().ToLower();
            if (response2.Contains("honey"))
            {
                Count++;
            }
            else
            {
                Count--;
            }
            Console.WriteLine("\nQueen - Wzzzzzzzzzzzzzzzz\n");
            Thread.Sleep(1000);
            string? response3 = Console.ReadLine().ToLower();
            if (response3 == "good" || response3 == "okay" || response3 == "nice")
            {
                Count++;
                Console.WriteLine("\nYou are doing this job!!\n");
            }
            else
            {
                Count--;
            }
            Console.WriteLine("\nQueen - WzzzzzzWzz\n");
            Thread.Sleep(1000);
            string? response4 = Console.ReadLine().ToLower();
            if (response4 == "thank you" || response4 == "thanks")
            {
                Count++;
            }
            else
            {
                Count--;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n'End of the talking'\n");
            Thread.Sleep(1000);
            Console.ResetColor();
            if (Count >= 3)
            {
                isCompletedCommunicationWithBees = true;
                Console.WriteLine("\nWonderful talking, well done!\n");
                Thread.Sleep(1000);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nMission failed.\n");
                Thread.Sleep(1000);
                Console.ResetColor();
            }
            
        }

            static void TicTacToe()
            {
                Console.WriteLine("Welcome to second mission of the task5");
                Console.WriteLine("You must beat my friend Bob for the guideline of communication with bees.\n");
                bool cont = false;
                do
                {
                    DrawBoard();

                    if (CurrentPlayer == 'X')
                    {
                        int move = GetPlayerMove();
                        MakeMove(move);
                    }
                    else
                    {
                        Console.WriteLine("Computer's turn:");
                        int move = GetComputerMove();
                        MakeMove(move);
                    }

                    if (CheckForWin() || CheckForTie())
                    {
                        DrawBoard();
                        Console.WriteLine("Game Over!");
                        if (CheckForWin())
                        {
                            Console.WriteLine($"Player {CurrentPlayer} wins!");
                            isCompletedTicTacToeGame = true;
                        }
                        else
                        {
                            Console.WriteLine("It's a tie!");
                            isCompletedTicTacToeGame = false;
                        }
                        cont = PlayAgain();
                        if (cont)
                        {
                            InitializeGame();
                        }
                        else
                        {
                            InitializeGame();
                            Console.WriteLine("Closing the program(game)");
                            break;
                        }
                    }

                    SwitchPlayer();

                } while (!cont);
            }

            static bool PlayAgain()
            {
                Console.Write("Press any key to jump into menu for next mission.");
                string? selection = Console.ReadLine().Trim().ToLower();
                if (selection == "y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            static void InitializeGame()
            {
                Board = new char[,]
                {
                    { '1', '2', '3' },
                    { '4', '5', '6' },
                    { '7', '8', '9' }
                };
                
                CurrentPlayer = 'X';
            }



            static void DrawBoard()
            {
                Console.Clear();
                Console.WriteLine("Tic Tac Toe\n");
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        Console.Write($" {Board[row, col]} ");
                        if (col < 2) Console.Write("|");
                    }
                    Console.WriteLine();
                    if (row < 2) Console.WriteLine("-----------");
                }

                Console.WriteLine();
            }

            static int GetPlayerMove()
            {
                int move;
                bool isValidMove;

                do
                {
                    Console.Write($"Player {CurrentPlayer}, enter your move (1-9): ");
                    isValidMove = int.TryParse(Console.ReadLine(), out move) && move >= 1 && move <= 9 && IsSpaceFree(move);

                    if (!isValidMove)
                    {
                        Console.WriteLine("Invalid move. Try again.");
                    }

                } while (!isValidMove);

                return move;
            }

            static int GetComputerMove()
            {
                Random random = new Random();
                int move;

                do
                {
                    move = random.Next(1, 10);

                } while (!IsSpaceFree(move));

                Console.WriteLine($"Computer chose {move}");
                return move;
            }

            static void MakeMove(int move)
            {
                int row = (move - 1) / 3;
                int col = (move - 1) % 3;

                Board[row, col] = CurrentPlayer;
            }

            static void SwitchPlayer()
            {
                CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
            }

            static bool IsSpaceFree(int move)
            {
                int row = (move - 1) / 3;
                int col = (move - 1) % 3;

                return Board[row, col] == 'X' || Board[row, col] == 'O' ? false : true;
            }

            static bool CheckForWin()
            {
                return CheckRow() || CheckColumn() || CheckDiagonal();
            }

            static bool CheckRow()
            {
                for (int row = 0; row < 3; row++)
                {
                    if (Board[row, 0] == CurrentPlayer && Board[row, 1] == CurrentPlayer && Board[row, 2] == CurrentPlayer)
                    {
                        return true;
                    }
                }
                return false;
            }

            static bool CheckColumn()
            {
                for (int col = 0; col < 3; col++)
                {
                    if (Board[0, col] == CurrentPlayer && Board[1, col] == CurrentPlayer && Board[2, col] == CurrentPlayer)
                    {
                        return true;
                    }
                }
                return false;
            }

            static bool CheckDiagonal()
            {
                if ((Board[0, 0] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 2] == CurrentPlayer) ||
                    (Board[0, 2] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 0] == CurrentPlayer))
                {
                    return true;
                }
                return false;
            }

            static bool CheckForTie()
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (Board[row, col] != 'X' && Board[row, col] != 'O')
                        {
                            return false;
                        }
                    }
                }
                Console.WriteLine("It's a tie!");
                return true;
            }

        public void Upgrade()
        {
            Level++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} honey hive upgraded to level {Level}!");
            Console.ResetColor();
        }

        public void ProduceHoney()
        {
            Honey += Level * 10;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} honey hive produced {Level * 10} honey!");
            Console.ResetColor();
        }

        public void BuildHives()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Wazolski\n");
            Console.WriteLine("You had accepted for the construction of honey hives. Let's begin!");
            Console.WriteLine("You must collect 200 resources to finish the task.");
            Console.WriteLine("\nOptions:");
            Thread.Sleep(1000);
            Console.WriteLine("1. Build a honey hive");
            Console.WriteLine("2. Upgrade a honey hive");
            Console.WriteLine("3. View honey hives");
            Console.WriteLine("4. Collect honey");
            Console.WriteLine("5. Exit");
            Console.ResetColor();
            bool eray = true;
            while (eray)
            {
                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        BuildHoneyHive();
                        break;
                    case "2":
                        UpgradeHoneyHive();
                        break;
                    case "3":
                        ViewHoneyHives();
                        break;
                    case "4":
                        CollectHoney();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the game. Thanks for playing!");
                        eray = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            
        }

        static void BuildHoneyHive()
        {
            if (Resources >= 50)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter a name for your honey hive: ");
                string? hiveName = Console.ReadLine();
                honeyHives.Add(new HoneyHive(hiveName, 1));
                Resources -= 50;
                Console.WriteLine($"{hiveName} honey hive built successfully!");
                HiveCreated++;
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not enough resources to build a honey hive. Collect more resources.");
                Console.ResetColor();
            }
        }

        static void UpgradeHoneyHive()
        {
            if (honeyHives.Count > 0)
            {
                Console.WriteLine("Select a hive to upgrade:");
                for (int i = 0; i < honeyHives.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {honeyHives[i].Name} (Level {honeyHives[i].Level})");
                }

                Console.Write("Enter the number of the hive to upgrade: ");
                if (int.TryParse(Console.ReadLine(), out int hiveIndex) && hiveIndex >= 1 && hiveIndex <= honeyHives.Count)
                {
                    HoneyHive selectedHive = honeyHives[hiveIndex - 1];
                    if (Resources >= 30 * selectedHive.Level)
                    {
                        selectedHive.Upgrade();
                        Resources -= 30 * selectedHive.Level;
                    }
                    else
                    {
                        Console.WriteLine("Not enough resources to upgrade the hive. Collect more resources.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid hive number. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("No honey hives to upgrade. Build a hive first.");
            }
        }

        static void ViewHoneyHives()
        {
            Console.WriteLine("\nYour Honey Hives:");
            if (HiveCreated == 0)
            {
                Console.WriteLine("First you need to create a hive.");
            }
            else
            {
                foreach (HoneyHive hive in honeyHives)
                {
                    Console.WriteLine($"{hive.Name} (Level {hive.Level}) - Honey: {hive.Honey}");
                }
            }
            Console.WriteLine($"Resources: {Resources}");
        }

        static void CollectHoney()
        {
            foreach (HoneyHive hive in honeyHives)
            {
                hive.ProduceHoney();
                Resources += hive.Honey;
                hive.Honey = 0;
            }
            Console.WriteLine("Honey collected from all hives!");

            if (Resources >= 400)  //Win condition
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations! You've reached the honey production goal. You won!");
                Console.ResetColor();
                isAllMissionsCompleted = true;
            }
        }
    }
}