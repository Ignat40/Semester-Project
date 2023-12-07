public class Minigame
{
    public static void ExecuteMinigame()
    {
        Console.WriteLine ("The password has the form xxx/xxx/xx/x-LAB and");
        Console.WriteLine ("is on the first page of one of these books.");
        Console.WriteLine ("");
        Console.WriteLine ("");
        Console.WriteLine (@"
                                 _________________________________________________________
                                ||-------------------------------------------------------||
                                ||.--.    .-._                        .----.             ||
                                |||==|____| |H|___            .---.___|''''|_____.--.___ ||
                                |||  |====| | |xxx|_          |+++|=-=|_  _|-=+=-|==|---|||
                                |||==|    | | |   | \         |   |   |_\/_|Black|  | ^ |||
                                |||  |  0 | | | 1 |\ \   .--. | 2 |=-=|_/\_|-=+=-|  | 3 |||
                                |||  |    | | |   |_\ \_( oo )|   |   |    |Magus|  | ^ |||
                                |||==|====| |H|xxx|  \ \ |''| |+++|=-=|''''|-=+=-|==|---|||
                                ||`--^----'-^-^---'   `-' ''  '---^---^----^-----^--^---^||
                                ||-------------------------------------------------------||
                                ||-------------------------------------------------------||
                                ||               ___                   .-.__.-----. .---.||
                                ||              |===| .---.   __   .---| |XX|<(*)>|_|^^^|||
                                ||         ,  /(|   |_|III|__|''|__|:x:|=|  |     |=| Q |||
                                ||      _a'{ / (|=4=|+|   |++|  |==|   | |  |Illum| | R |||
                                ||      '/\\/ _(|=4=|-| 5 |  |''|  |:6:|=|  |inati|7| Y |||
                                ||_____  -\{___(|   |-|   |  |  |  |   | |  |     | | Z |||
                                ||       _(____)|===|+|[I]|DK|''|==|:x:|=|XX|<(*)>|=|^^^|||
                                ||              `---^-^---^--^--'--^---^-^--^-----^-^---^||
                                ||-------------------------------------------------------||
                                ||_______________________________________________________||
                            
                            ");
        Console.WriteLine ("You now have to search each of the books");
        Console.WriteLine ("for a password that matches the");
        Console.WriteLine ("password form: xxx/xxx/xx/x-LAB.");
        Console.WriteLine (" ");
        Console.WriteLine ("If it does not strictly comply with this form: xxx/xxx/xx/x-LAB,");
        Console.WriteLine ("it is not the password and you will have to continue searching");
        Console.WriteLine ("in other books for the password with the correct form. ");
        Console.WriteLine (" ");

            bool keepBookLoop = true;

            while (keepBookLoop)
            {
                Console.WriteLine ("Select a book (0-7)");

                int numberBook;

                if (int.TryParse(Console.ReadLine(), out numberBook))
                {
                
                
                    switch (numberBook)
                    {
                        case 0:
                            Console.WriteLine ($"You have selected: 0");
                            Console.WriteLine ("Password: 930/201/33/11-LAB");
                            break;
                        
                        case 1:
                            Console.WriteLine ($"You have selected: 1");
                            Console.WriteLine ("Password: 503/050/69/1-CLASS");
                            break;
                        
                        case 2:
                            Console.WriteLine ($"You have selected: 2");
                            Console.WriteLine ("Password: 0999/643/20/9-LAB");
                            break;
                    
                        case 3:
                            Console.WriteLine ($"You have selected: 3");
                            Console.WriteLine ("Password: 777/2325/77/1-LAB");
                            break;
                        
                        case 4:
                            Console.WriteLine ($"You have selected: 4");
                            Console.WriteLine ("Password: 220/200/33/91-LAB");
                            break;
                        
                        case 5:
                            Console.WriteLine ($"You have selected: 5");
                            Console.WriteLine ("Password: 304/291/73/0-GYM");
                            break;
                        
                        case 6:
                            Console.WriteLine ($"You have selected: 6");
                            Console.WriteLine ("Password: 911/000/23/1-LAB");
                            break;
                        
                        case 7:
                            Console.WriteLine ($"You have selected: 7");
                            Console.WriteLine ("Password: 444/888/41/1-LIB");
                            break;
                        
                        default:
                            Console.WriteLine("Error invalid entry, (0-7)");
                            continue;
                            
                    }
                }
                else
                {
                    Console.WriteLine("Error invalid entry, (0-7)");
                }
                Console.WriteLine (" ");
                Console.WriteLine ("If you think you have found the correct password with exactly the form xxx/xxx/xx/x-LAB,");
                Console.WriteLine ("press 'Y' and those in the loop otherwise press 'N'.");
                string? knowBookPass = Console.ReadLine();
                if (knowBookPass != null)
                {
                    if(knowBookPass.ToUpper() == "Y")
                    {
                            Console.WriteLine ("Okay, well tell me which book was the password in?");
                            string? passBook = Console.ReadLine();
                            if (knowBookPass != null)
                            {
                                if (passBook == "6")
                                {
                                    Console.WriteLine ("Well this is the book well done.");
                                    keepBookLoop = false;
                                }
                                else 
                                {
                                    Console.WriteLine("No, that's not the book");
                                }
                            }
                            else
                            {
                                Console.WriteLine ("Invalid entry, the input has to between (0-7), not a null value.");
                            }
                    }    
                    else if (knowBookPass.ToUpper() == "N")
                    {
                        Console.WriteLine("Okay, nothing happens, keep looking in the other books.");     
                    }
                    else
                    {
                    Console.WriteLine ("Invalid entry, (Y/N)"); 
                
                    }    
                }
                else
                {
                    Console.WriteLine ("Invalid entry, the input has to be (Y/N), not a null value.");
                }
            }
        Console.WriteLine (" ");
        Console.WriteLine ("Good! Now you have the password, perfect, now you");
        Console.WriteLine ("just have to go to the lab.");
        Console.WriteLine ("Press en 'C' to continue or 'X' to exit.");
        string? continueToMain = Console.ReadLine();
        
        if(continueToMain != null)
        {
            if (continueToMain.ToUpper() == "C")
            {
                Console.Clear();
            }
            else if (continueToMain.ToUpper() == "X")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine ("Invalid entry, press en 'C' to continue or 'X' to exit.");
            }
        } 
        else
        {
            Console.WriteLine ("Invalid entry, the input has to be 'C' or 'X', not a null value.");
        }
    }
}
