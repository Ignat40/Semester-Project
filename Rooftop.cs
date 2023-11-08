using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldOfZuul
{
    public class RooftopMission
    {
        private bool isCompleted = false;

        public bool IsCompleted => isCompleted;

        public void StartMission(Player player)
        {
            Console.WriteLine("Mission Brief: Operation Solar Maximation");
            Console.WriteLine("Your objective: You are on the university rooftop, Daniel needs you to adjust the solar panel angle using the control panel until we reach maximum efficiency on the solar panel. We need you to calibrate the solar panel by adjusting the angle until it points directly at the sun.");

            TalkToDanielGarcia(player);
        }

        private void TalkToDanielGarcia(Player player)
        {
            Console.WriteLine("Dani: Hi " + player);
            Console.WriteLine(">        : Today you will help the university by adjusting the solar panels.");
            Console.WriteLine(">        : Would you like to learn about solar energy efficiency? (yes/no)");

            string response = Console.ReadLine().ToLower();
            if (response == "yes")
            {
                Console.WriteLine("Engineer: *Provides information about solar energy efficiency*");
            }
            else
            {
                Console.WriteLine("Engineer: Alright, let's get started with the adjustments!");
            }

            Console.WriteLine("Technician: Please ensure the panels are clean and angled at precisely 40 degrees for optimal efficiency.");
            PerformAdjustmentTask(player);
        }

        private void PerformAdjustmentTask(Player player)
        {
            Parser parser = new();

            Console.WriteLine("Objective: Adjust the solar panels to the correct angle. Check the panel's status.");
            Console.WriteLine();
            Console.WriteLine($"{player}: I need to find the control panel to adjust the angles...");
            Console.WriteLine("+----------------------------------+");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|       ☀️           ☀️           |");
            Console.WriteLine("|     🌞   Adjust   🌞             |");
            Console.WriteLine("|       ☀️           ☀️           |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("+----------------------------------+");

            Console.WriteLine("Engineer: Would you like to move to the control panel (m) or abort mission (a)? (m/a)");
            string? userchoice = Console.ReadLine().ToLower();
            if (userchoice == "m") //adjust the control panel to move solar panels
            {
                Console.WriteLine($"{player}: Here is the control panel. Let's make the adjustments.");
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine("|       Control Panel              |");
                Console.WriteLine("|    [Angle Adjustment]            |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|    [Diagnostic Tools]            |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine();
                Console.WriteLine("Use 'adjust' to change the angle or 'diagnose' to check the panel status.");

                int panelsToAdjust = 10;

                while (panelsToAdjust > 0)
                {
                    Console.Write("> ");
                    string? cmd = Console.ReadLine();

                    if (cmd != null)
                    {
                        if (cmd == "adjust")
                        {
                            Console.WriteLine("Panel angle adjusted.");
                            panelsToAdjust--;
                        }
                        else if (cmd == "diagnose")
                        {
                            Console.WriteLine("Panel status: OK.");
                        }
                        else
                        {
                            Console.WriteLine("Wrong command. Write 'adjust' or 'diagnose'.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a command.");
                        continue;
                    }

                    Console.WriteLine($"Panels left to adjust: {panelsToAdjust}");
                }
            }
            else
            {
                System.Environment.Exit(0);
            }

            Console.WriteLine("Engineer: Fantastic work! The solar panels are now realigned perfectly!");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|     🌞   Efficiency   🌞       |");
            Console.WriteLine("|         Maximized!              |");
            Console.WriteLine("+--------------------------------+");


            //Add the solar panel angle loop



            // Assume the adjustment task is completed successfully
            isCompleted = true;
        }

    }
}
