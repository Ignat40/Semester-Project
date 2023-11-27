using System;

namespace WorldOfZuul
{
    class MapInHall : IMap
    {
        public virtual void DisplayMap()
        {
            Console.WriteLine("                      ┌──────────────────┐");
            Console.WriteLine("                      │                  │");
            Console.WriteLine("┌────────────┐        │                  ├───────────┐");
            Console.WriteLine("│            ├───────►│   Task 2.        │           │");
            Console.WriteLine("│  Task 1.   │        |                  │           │");
            Console.WriteLine("│            │        └──────────────────┘           │");
            Console.WriteLine("└────────────┘                                       │");
            Console.WriteLine("      ▲           ┌───────────────────┐        ┌─────▼─────┐");
            Console.WriteLine("      │           │                   │        │           │");
            Console.WriteLine("                  │                   │        │ Task 3.   │");
            Console.WriteLine("       ┌────────► │   You are here!   │        └────┬──────┘");
            Console.WriteLine("       │          │                   │             │");
            Console.WriteLine(" ┌─────┴───────┐  │                   │             ▼");
            Console.WriteLine(" │             │  └───────────────────┘    ┌─────────────┐");
            Console.WriteLine(" │             │                           │             │");
            Console.WriteLine(" │   Task 5.   │                           │             │");
            Console.WriteLine(" │             │                           │   Task 4.   │");
            Console.WriteLine(" │             │◄──────────────────────────┤             │");
            Console.WriteLine(" └─────────────┘                           └─────────────");
        }
    }

}