namespace WorldOfZuul
{ 
  public class Task1
  {
    public int Count = 0;
      public void Sandwich()
      {
        Console.WriteLine ("Hello player, the first task that you will have to complete in this beautiful game will");
        Console.WriteLine ("be to find the physics professor in the university, who is a big fan of the SDGs.");
        Console.WriteLine ("");
        Console.WriteLine ("SO GO AHEAD!!!!");
        Console.WriteLine ("");
        Console.WriteLine ("");
        Console.WriteLine ("You enter the university and ask a boy where the professor can be");

        Console.WriteLine(@"  
        (You)       ________________________
          ↓       / Hello, do you know where \                    ^\|/_
        (_oo  <==(   the physics teacher      )                   oo_)
        |        \_______can be?____________/                      |
        /|\                                                        /|\
        |                                                          |
        LL                                                        JJ
              
          ");   

        Console.WriteLine (@"
        (Boy)
          ↓         _________________________________________________
        _\|/^      / Yes, he could be in the laboratory or teaching, \ 
        (_oo  <==|     I don't know exactly which one right now,     |                   
          |       |     but the laboratory is right next door,        |                   
        /|\       \_____________you could go see.___________________/                                               
          |                                                          
          LL                                                        


          ");

        Console.WriteLine ("You approach the laboratory but you need a password to enter,"); 
        Console.WriteLine ("this password is in the library.");       
        Console.WriteLine ("So you go to the library and the librarian tells you that ");           
        Console.WriteLine ("the password is in a book that is on the shelf but you");
        Console.WriteLine ("don't remember which one, so you will have to search.");
        Console.WriteLine ("");
        
        bool continueLoop_1 = true;
        
        while (continueLoop_1)
        {
          Console.WriteLine ("Press en 'C' to continue or 'X' to exit.");
          string? continueToLibrary = Console.ReadLine()?.ToUpper() ?? "";

          if (continueToLibrary == "C")
          {
            continueLoop_1 = false;
            Console.Clear();
            Minigame.ExecuteMinigame();
          }
          else if (continueToLibrary == "X")
          {
            continueLoop_1 = false;
            return;
          }
          else
          {
            Console.WriteLine ("Invalid entry, press en 'C' to continue or 'X' to exit.");
          }
        }
        
        Console.WriteLine ("Good! Now you have the password, perfect,");
        Console.WriteLine ("now you just have to go to the lab.");
        Console.WriteLine (" ");
        Console.WriteLine (" ");
        
        bool loopPassDoor = true;

        while (loopPassDoor)
        {
        
          Console.WriteLine ("Now, you enter the password at the lab door.                                      Note: the password is: 911/000/23/1-LAB");
          Console.WriteLine 
          (@"
          ,-----------------------------------------------------------,
          |Intruce password:                                          |
          |                                                           |
          |                                                           |
          |---,---,---,---,---,---,---,---,---,---,---,---,---,-------|
          |1/2| 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 0 | + | ' | <-    |
          |---'-,-'-,-'-,-'-,-'-,-'-,-'-,-'-,-'-,-'-,-'-,-'-,-'-,-----|
          | ->| | Q | W | E | R | T | Y | U | I | O | P | ] | ^ |     |
          |-----',--',--',--',--',--',--',--',--',--',--',--',--'|    |
          | Caps | A | S | D | F | G | H | J | K | L | \ | [ | * |    |
          |----,-'-,-'-,-'-,-'-,-'-,-'-,-'-,-'-,-'-,-'-,-'-,-'---'----|
          |    | < | Z | X | C | V | B | N | M | , | . | - |          |
          |----'-,-',--'--,'---'---'---'---'---'---'-,-'---',--,------|
          | ctrl |  | alt |                          |altgr |  | ctrl |
          '------'  '-----'--------------------------'------'  '------'
          
          ");
          string? labPassword = Console.ReadLine();
          if (labPassword != null)
          {
              if(labPassword =="911/000/23/1-LAB")
              {
                loopPassDoor = false;
                Console.WriteLine ("Now you are inside the lab and unfortunately, the teacher");
                Console.WriteLine ("is not there, so you have to go quickly to his class,");
                Console.WriteLine ("which is the only place he can be.");
                
                bool continueQuiz = true;

                while (continueQuiz)
                {
                
                  Console.WriteLine ("Press en 'C' to continue or 'X' to exit.");
                  string? continueToClass = Console.ReadLine();
                  
                  if(continueToClass != null)
                  {
                      if (continueToClass.ToUpper() == "C")
                      {
                        continueQuiz = false;
                        Console.Clear();
                      }
                      else if (continueToClass.ToUpper() == "X")
                      {
                        continueQuiz = false;
                        return;
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
              else
              {
                Console.WriteLine($"You know the password but you have typed it wrong.");
              }
          }
          else
          {
            Console.WriteLine ("Invalid entry, the input has to be the password, not a null value.");
          }
        }

        Console.WriteLine (" ");
        Console.WriteLine (" ");
        Console.WriteLine ("We venture through the university again and you have to go");
        Console.WriteLine ("through the dining room to get to class, to review");
        Console.WriteLine ("the Sustainable Development Goals, you are going");
        Console.WriteLine ("to do a quick and small quiz.");
        Console.WriteLine (" ");
        
        bool quizFood = true;
        while (quizFood)
        {
          Console.WriteLine ("Which of these five SDGs has to do with food?");
          Console.WriteLine (" ");
          Console.WriteLine (@"
          A- SDG number: 2
          
          B- SDG number: 4
          
          C- SDG number: 7
          
          D- SDG number: 8
          
          E- SDG number: 16
          
          If you don't know the SDGs by heart, you can go to the SDGs website and search for it.
          ");
          Console.WriteLine ("Answer (form: C): ");
          string? answerQuiz = Console.ReadLine();
          if (answerQuiz != null)
          { 
            if (answerQuiz.ToUpper() == "A")
            {
              Console.WriteLine ("Well, you know the SDGs well, now we can continue.");
              quizFood = false;
            }
            else
            {
              Console.WriteLine ("That's not the correct answer.");
            }
          }
          else
          {
            Console.WriteLine ("Invalid entry, the input has to be a letter, not a null value.");
          }
        }
        Console.WriteLine("Okay, now that you've completed the quiz we can move on.");
        
        bool continueQuizLoop = true;

        while(continueQuizLoop)
        {
          Console.WriteLine ("Press en 'C' to continue or 'X' to exit.");
          string? continueAfterQuiz = Console.ReadLine();
                
          if(continueAfterQuiz != null)
          {
            if (continueAfterQuiz.ToUpper() == "C")
            {
              continueQuizLoop = false;
              Console.Clear();
            }
            else if (continueAfterQuiz.ToUpper() == "X")
            {
              continueQuizLoop = false;
              return;
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

        Console.WriteLine ("You arrive at the class and there you finally find the Professor,");
        Console.WriteLine ("who has just finished teaching, you greet him and ask him for");
        Console.WriteLine ("help to understand the importance of the SDGs."); 
        Console.WriteLine (" ");
        Console.WriteLine ("He accepts but the only thing he asks is that you bring him a ");
        Console.WriteLine ("sandwich, because he is dying of hunger.");
        Console.WriteLine ("Okay, while you go get the sandwich I'm going to tell you");
        Console.WriteLine ("about the second SDG that deals with hunger too.");
        Console.WriteLine (" ");
        
        bool finalLoop = true;

        while (finalLoop)
        {
          Console.WriteLine ("Press en 'C' to continue or 'X' to exit.");
          string? continueSandwich = Console.ReadLine();

          if(continueSandwich != null)
          {
            if (continueSandwich.ToUpper() == "C")
            {
              finalLoop = false;
              Console.Clear();
            }
            else if (continueSandwich.ToUpper() == "X")
            {
              finalLoop = false;
              return;
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

        Console.WriteLine ("The second SDG is called Zero Hunger.");
        Console.WriteLine (" ");
        Console.WriteLine ("Its goal is to end hunger, achieve food security and improved");
        Console.WriteLine ("nutrition, and promote sustainable agriculture.");
        Console.WriteLine ("More than 600 million people worlwide are projected to face");
        Console.WriteLine ("hunger in 2030.");
        Console.WriteLine (" ");
        Console.WriteLine ("1 in 3 people worldwide struggle with moderate to severe");
        Console.WriteLine ("food insecurity.");
        Console.WriteLine (" ");
        Console.WriteLine ("Despite dropping in 2021, high food prices continue to");
        Console.WriteLine ("plague many nations, in 2021 the percentage of ");
        Console.WriteLine ("countris with abnormaly high food prices was 21.5%.");
        Console.WriteLine (" ");
        Console.WriteLine ("This is a summary of the information in the second");
        Console.WriteLine ("SDG and why it is so important to comply.");
        Console.WriteLine (" ");
        Console.WriteLine ("After this presentation, from the second SDG you already"); 
        Console.WriteLine ("have the sandwich and you hand it to the Professor.");
        Console.WriteLine (" ");
        
        bool finalLoop_2 = true;

        while (finalLoop_2)
        {
          Console.WriteLine ("Press en 'C' to continue or 'X' to exit.");
          string? finalPart = Console.ReadLine();

          if(finalPart != null)
          {
            if (finalPart.ToUpper() == "C")
            {
              finalLoop_2 = false;
              Console.Clear();
            }
            else if (finalPart.ToUpper() == "X")
            {
              finalLoop_2 = false;
              return;
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
        Console.WriteLine ("The professor now well fed, see your interest in sustainability, explained to you the importance");
        Console.WriteLine ("of the Sustainability Development Goals.");
        Console.WriteLine (" ");
        Console.WriteLine ("These are part of the 2030 Agenda, which outlines a collective vision for global");
        Console.WriteLine ("peace and prosperity. At the heart of this agenda are the 17 Sustainable Development");
        Console.WriteLine (" ");
        Console.WriteLine ("At the heart of this agenda are the 17 Sustainable Development Goals (SDGs), a");
        Console.WriteLine ("compelling call to action for all nations, regardless of their level of");
        Console.WriteLine ("development.");
        Console.WriteLine (" ");
        Console.WriteLine ("The SDGs highlight the interconnection between eradicating poverty and addressing");
        Console.WriteLine ("issues such as health, education, inequality and economic growth."); 
        Console.WriteLine (" ");
        Console.WriteLine ("At the same time, they urge efforts to combat climate change and protect our oceans");
        Console.WriteLine ("and forests, underscoring the importance of united global collaboration.");
        Console.WriteLine (" ");
        
        bool finalLoop_3 = true;

        while (finalLoop_3)
        {
          Console.WriteLine ("Press en 'C' to continue or 'X' to exit.");
          string? final = Console.ReadLine();

          if(final != null)
          {
            if (final.ToUpper() == "C")
            {
              finalLoop_3 = false;
              Console.Clear();
            }
            else if (final.ToUpper() == "X")
            {
              finalLoop_3 = false;
              return;
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
        Console.WriteLine ("This is the end of the first part of the game, thanks for playing.");
        Count++;
      }

      public bool IsCompletedTask()
      {
          if (Count > 0)
          {
              return true;
          }
          else
          {
              return false;
          }
      }

  }
}
