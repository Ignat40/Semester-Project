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
        public bool isCompletedHiveQuiz = false;
        public bool isCompletedCommunicationWithBees = false;
        public static bool isCompletedTicTacToeGame = false;
        public static bool isAllMissionsCompleted = false;
        public string Name {get; set;}
        public int Level {get; set;}
        public int Honey {get; set;}
        static List<HoneyHive> honeyHives = new List<HoneyHive>();
        static int Resources = 500;
        static int Score = 0;
        static char[,] board = {
        {'1', '2', '3'},
        {'4', '5', '6'},
        {'7', '8', '9'}
    };

        static char currentPlayer = 'X';

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
                Console.WriteLine("2. Start Communication with Bees");
                Console.WriteLine("3. TicTacToe game");
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
                        if (isCompletedHiveQuiz && !isCompletedCommunicationWithBees)
                        {
                            CommunicationWithBees();
                        }
                        else if (!isCompletedHiveQuiz)
                        {
                            Console.WriteLine("You must complete the Hive Quiz before starting Communication with Bees.");
                        }
                        else
                        {
                            Console.WriteLine("You have already completed Communication with Bees.");
                        }
                        break;

                    case 3:
                        //TicTacToe();
                        //break;
                        if (isCompletedHiveQuiz && isCompletedCommunicationWithBees && !isCompletedTicTacToeGame)
                        {
                            TicTacToe();
                        }
                        else if (!isCompletedHiveQuiz)
                        {
                            Console.WriteLine("You must complete the Hive Quiz before starting Communication with Bees.");
                        }
                        else if (!isCompletedCommunicationWithBees)
                        {
                            Console.WriteLine("You must complete Communication with Bees before building hives.");
                        }
                        else
                        {
                            System.Console.WriteLine("You already won the tic-tac-toe game.");
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
                        Console.WriteLine("Exiting the world of missions.");
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
            System.Console.WriteLine("\nWelcome to last mission.\n");
            System.Console.WriteLine($"Hi {player.PlayerName}");
            System.Console.WriteLine("Finally, when you complete this mission, you will have your goals.\n");
            System.Console.WriteLine("You need to build new hives to create advanced infrastructure of honey production for bees.\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("   _   _");
            System.Console.WriteLine("  ( | / )"); 
            System.Console.WriteLine("\\\\ ||/,'");
            System.Console.WriteLine("('')(_)()))=");
            System.Console.WriteLine("    <\\\\\n");
            Console.ResetColor();
            System.Console.WriteLine("For this, you will need materials. You need to gain beekeeper trust to obtain materails and build hives.");
            System.Console.WriteLine();
            System.Console.WriteLine("GOOD LUCK!!!\n");

            communicate.NpcName = "Beekeeper Wazolski";
            communicate.Sentence = "Welcome to my farm. My name is Wazolski. To obtain my tools and materials for hives, you need to pass my quiz. You know..... trust issues.";
            System.Console.WriteLine($"Hey this is {communicate.NpcName}, standing next to the truck.");

            MultipleChoiceQuestion("How many SDGs are existing?", new Dictionary<string, string> { { "a", "14" }, { "b", "17" }, { "c", "20" } }, "b");
            TrueFalseQuestion("Only female bees can sting. (True/False)", "true");
            OpenEndedQuestion("What is the name of this city", "sonderborg");
            MultipleChoiceQuestion("Which programming language is this game written in?", new Dictionary<string, string> { { "a", "Java" }, { "b", "Python" }, { "c", "C#" } }, "c");
            TrueFalseQuestion("SDG 5 is supported in this mission.(True/False)", "false");
            OpenEndedQuestion("Final, a riddle time. I'm tall when I'm young, and I'm short when I'm old. What am I?", "candle");
            
            if (Score == 6)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("\nYou passed my quiz by answering all questions correct.");
                Console.ResetColor();
                isCompletedHiveQuiz = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("\nYou failed.");
                Console.ResetColor();
            }
        }

        public void CommunicationWithBees()
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
                Console.ForegroundColor = ConsoleColor.Magenta;
                System.Console.WriteLine("1-\t[Wzzzzzzzzzwz] = Hi, You need to say hello or hi to queen bee.");
                System.Console.WriteLine("2-\t[WzWzWzWz] = What is your purpose of visiting my kingdom, You need to tell her about SDG and honey - both of them");
                System.Console.WriteLine("3-\t[Wzzzzzzzzzzzzzzzz] = I understand, You can either say nice, okay or good.");
                System.Console.WriteLine("-\t[WzzzzzzWzz] = I accept your offer, I hope she is going to say this sentence to you. You must say [For bees] to caress her soul.");
                Console.ResetColor();
                System.Console.WriteLine();
                System.Console.WriteLine("Be careful while talking with queen!\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("   __         .' '.");
                System.Console.WriteLine(" _/__)        .   .       .");
                System.Console.WriteLine("(8|)_}}- .      .        .");
                System.Console.WriteLine(" `\\__)    '. . ' ' .  . '\n");
                Console.ResetColor();
                communicate.NpcName2 = "Queen";
                System.Console.WriteLine();
                System.Console.WriteLine("Introduce yourself by telling your name first.\n");
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
                            System.Console.WriteLine("\nWzzwwwwz - [Nice to meet you]");
                            count++;
                        }
                        else
                        {
                            System.Console.WriteLine("\nWZZZZZZZZZZZZZZZZZZZZ!!! - [Anger]");
                            return;
                        }
                        Console.WriteLine();
                        System.Console.WriteLine(communicate.NpcName2);
                        System.Console.WriteLine();
                        System.Console.WriteLine("WzWzWzWz\n");
                        System.Console.WriteLine(name);
                        Console.WriteLine();
                        string? ans2 = Console.ReadLine();
                        ans2.ToLower();
                        if (ans2.Contains("sdg") && ans2.Contains("honey"))
                        {
                            System.Console.WriteLine("\nWzzHoneyWzz - [Honey is improtant for us].\n");
                            count++;
                        }
                        else
                        {
                            System.Console.WriteLine("\nWZZZZZZZZZZZZZZZZZZZZ!!! - [Anger]\n");
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
                            isCompletedCommunicationWithBees = true;
                            System.Console.WriteLine("You have finished second mission successfully. Well done!\n");
                            cont = false;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            System.Console.WriteLine("         .' '.              __");
                            System.Console.WriteLine(".        .   .             (__\\");
                            System.Console.WriteLine("  .         .         . -{{_(|8)");
                            System.Console.WriteLine("     ' .  . ' ' .  . '     (__/\n");
                            Console.ResetColor();
                        }
                        else
                        {
                            System.Console.WriteLine("Communication with bees mission isn't completed. Try again later.");
                            return;
                        }
                    }
                }
            isCompletedCommunicationWithBees = true;
        }

            static void TicTacToe()
            {
                System.Console.WriteLine("Welcome to third mission of the task5");
                System.Console.WriteLine("You must beat my friend Bob for the guidline of communication with bees.\n");
                bool cont = false;
                do
                {
                    DrawBoard();

                    if (currentPlayer == 'X')
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
                            Console.WriteLine($"Player {currentPlayer} wins!");
                            isCompletedTicTacToeGame = true;
                        }
                        else
                        {
                            Console.WriteLine("It's a tie!");
                            isCompletedTicTacToeGame = false;
                        }
                        //need small fix
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
                Console.Write("Do you want to play again? (y/n): ");
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
                board = new char[,]
                {
                    { '1', '2', '3' },
                    { '4', '5', '6' },
                    { '7', '8', '9' }
                };
                
                currentPlayer = 'X';
            }



            static void DrawBoard()
            {
                Console.Clear();
                Console.WriteLine("Tic Tac Toe\n");
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        Console.Write($" {board[row, col]} ");
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
                    Console.Write($"Player {currentPlayer}, enter your move (1-9): ");
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

                board[row, col] = currentPlayer;
            }

            static void SwitchPlayer()
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }

            static bool IsSpaceFree(int move)
            {
                int row = (move - 1) / 3;
                int col = (move - 1) % 3;

                return board[row, col] == 'X' || board[row, col] == 'O' ? false : true;
            }

            static bool CheckForWin()
            {
                return CheckRow() || CheckColumn() || CheckDiagonal();
            }

            static bool CheckRow()
            {
                for (int row = 0; row < 3; row++)
                {
                    if (board[row, 0] == currentPlayer && board[row, 1] == currentPlayer && board[row, 2] == currentPlayer)
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
                    if (board[0, col] == currentPlayer && board[1, col] == currentPlayer && board[2, col] == currentPlayer)
                    {
                        return true;
                    }
                }
                return false;
            }

            static bool CheckDiagonal()
            {
                if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                    (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
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
                        if (board[row, col] != 'X' && board[row, col] != 'O')
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
            System.Console.WriteLine("Wazolski\n");
            System.Console.WriteLine("You had accepted for the construction of honey hives. Let's begin!");
            System.Console.WriteLine("You must collect 1000 resources to finish the task.");
            Console.WriteLine("\nOptions:");
            Thread.Sleep(1000);
            Console.WriteLine("1. Build a honey hive");
            Thread.Sleep(1000);
            Console.WriteLine("2. Upgrade a honey hive");
            Thread.Sleep(1000);
            Console.WriteLine("3. View honey hives");
            Thread.Sleep(1000);
            Console.WriteLine("4. Collect honey");
            Thread.Sleep(1000);
            Console.WriteLine("5. Exit");
            Thread.Sleep(1000);
            Console.ResetColor();
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
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        static void BuildHoneyHive()
        {
            if (Resources >= 50)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter a name for your honey hive: ");
                string hiveName = Console.ReadLine();
                honeyHives.Add(new HoneyHive(hiveName, 1));
                Resources -= 50;
                Console.WriteLine($"{hiveName} honey hive built successfully!");
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
            foreach (HoneyHive hive in honeyHives)
            {
                Console.WriteLine($"{hive.Name} (Level {hive.Level}) - Honey: {hive.Honey}");
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

            if (Resources >= 1000)  //Win condition 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations! You've reached the honey production goal. You won!");
                Console.ResetColor();
                isAllMissionsCompleted = true;
            }
        }
    }
}