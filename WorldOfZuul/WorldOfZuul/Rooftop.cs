using System;

namespace WorldOfZuul
{
    public class RooftopMission
    {
        private bool isCompleted = false;
        private const int OptimalAngle = 40;
        private const int MaxAngle = 90;

        public bool IsCompleted => isCompleted;

        public void StartMission(Player player)
        {
            TalkToDanielGarcia(player);
        }

        private void TalkToDanielGarcia(Player player)
        {
            PerformAdjustmentTask(player);
        }
        private void ThankDani()
        {
            Console.WriteLine($"Dani: Thank you! The university will now produce energy 25% more efficiently than before.");
            Console.WriteLine("Dani: This will have drastic changes to our local carbon footprint.");

            //Finish of level (add finisher)
        }

        private void PerformAdjustmentTask(Player player)
        {
            Console.WriteLine("Objective: Adjust the solar panels to the correct angle. Check the panel's status.");
            
            // Code to move to the control panel or abort mission

            int currentAngle = 0;
            bool isOptimal = false;

            while (!isOptimal)
            {
                Console.WriteLine("Current Angle: " + currentAngle + " degrees.");
                DisplaySolarPanel(currentAngle);
                Console.WriteLine("Enter angle adjustment (positive or negative value) or type 'check' to check efficiency:");

                string input = Console.ReadLine();
                if (input == "check")
                {
                    double efficiency = CalculateEfficiency(currentAngle);
                    Console.WriteLine($"Efficiency: {efficiency * 100}%");

                    if (currentAngle == OptimalAngle)
                    {
                        Console.WriteLine("Optimal efficiency achieved!");
                        DisplayMaximizedEfficiency();
                        isOptimal = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Efficiency is not optimal. Adjust the angle further.");
                    }
                }
                else
                {
                    if (int.TryParse(input, out int adjustment))
                    {
                        currentAngle = Math.Clamp(currentAngle + adjustment, 0, MaxAngle);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number or 'check'.");
                    }
                }
            }

            isCompleted = true;
        }

        private double CalculateEfficiency(int angle)
        {
            int angleDiff = Math.Abs(OptimalAngle - angle);
            return 1 - (angleDiff / (double)MaxAngle);
        }

private void DisplaySolarPanel(int angle)
{
    string panelAt0 = @"
      __________________________
     |                          |
     |                          |
     |__________________________|";

    string panelAt20 = @"
      ____________
     |            \
     |             \
     |______________\";

    string panelAt40 = @"  // Optimal Angle //
      ______
     |      \
     |       \
     |________\";

    string panelAt60 = @"
      ___
     |   \
     |    \
     |_____\";

    string panelAt80 = @"
      _
     | \
     |  \
     |___\";

    // Choose the ASCII art based on the angle range
    if (angle < 20)
    {
        Console.WriteLine(panelAt0);
    }
    else if (angle < 40)
    {
        Console.WriteLine(panelAt20);
    }
    else if (angle < 60)
    {
        Console.WriteLine(panelAt40);
    }
    else if (angle < 80)
    {
        Console.WriteLine(panelAt60);
    }
    else
    {
        Console.WriteLine(panelAt80);
    }
}


        private string RotateASCIIArt(string art, int angle)
        {

            return art;
        }

        private void DisplayMaximizedEfficiency()
        {
            string maximizedArt = @"
      +---------------------------+
      |   🌞 EFFICIENCY MAXIMIZED 🌞   |
      +---------------------------+
            /""---...___
           /           \
    ______/             \_________
   |                              |
   |______________________________|";

            Console.WriteLine(maximizedArt);
            ThankDani();
        }


    }
}
