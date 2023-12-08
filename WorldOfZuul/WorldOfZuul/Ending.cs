namespace WorldOfZuul
{
    class GameEnd
    {

        AsciiArt asciiArt = new();
        MapCompleted mapCompleted = new();

        public void GameEnding()
        {
            mapCompleted.DisplayMap();
            AnimateEnding($"\nMayor: Congratulations our dear hero! You have "
                        + "solved all of the problems our city had to face! You've learned "
                        +"so much about the importance of the SDGs and how to follow them daily! "
                        +"You were the one thing our city needed! Our true hero! And now"
                        +" I would like to give you a special present for the bravary,"
                        +"if you would come to the caste with me! (go/stay)", 5000);
            
            string? choice = Console.ReadLine();
            if(choice != null && choice == "go")
            {
                asciiArt.Castle();
                Console.WriteLine($"\nWe have a special protrain in the wall of heroes here in the main room!");
                asciiArt.Drawing();
                Console.WriteLine($"\nAnd now as the sun is setting over the sea horizon I would like to say goodbye hero!\n");
                SendOff();
            }
            else
            {
                AnimateEnding($"\nI understand how exhausted you must be! Regardless..."
                            + $"Take my sincere gratitude! Be well dear hero!", 5000);
            }
        }

        public static void AnimateEnding(string inputText, int duration)
        {
            int frames = duration/ 50;
            int startIndex = 0;

            for(int i = 0; i < frames; i++)
            {
                Console.Clear();
                Console.WriteLine(inputText.Substring(startIndex, Math.Min(i * inputText.Length / frames, inputText.Length)));
                Thread.Sleep(50);
            }

            Console.Clear();
            Console.WriteLine(inputText);
        }   

        public static void SendOff()
        {
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
            Console.ResetColor();
            Thread.Sleep(100);
             Console.WriteLine("Brought you by:");
            Console.WriteLine();
            Console.WriteLine("     •Vedat Esendag");
            Thread.Sleep(100);
            Console.WriteLine("     •Altan Esmer");
            Thread.Sleep(100);
            Console.WriteLine("     •Frederik Handberg");
            Thread.Sleep(100);
            Console.WriteLine("     •Ignat Bozhinov");
            Thread.Sleep(100);
            Console.WriteLine("     •Leonardo Gianola");
            Thread.Sleep(100); ;
        }
    }
}