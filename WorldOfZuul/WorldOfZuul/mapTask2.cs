using System;

namespace WorldOfZuul
{
    class MapTask2 : IMap
    {
        public virtual void DisplayMap()
        {
            Console.WriteLine("                      ┌──────────────────┐");
            Console.WriteLine("                      │                  │");
            Console.WriteLine("┌────────────┐        │                  ├───────────┐");
            Console.WriteLine("│            ├───────►│   You are here!  │           │");
            Console.WriteLine("│   Task 1.  │        |                  │           │");
            Console.WriteLine("│            │        └──────────────────┘           │");
            Console.WriteLine("└────────────┘                                       │");
            Console.WriteLine("      ▲           ┌───────────────────┐        ┌─────▼─────┐");
            Console.WriteLine("      │           │                   │        │           │");
            Console.WriteLine("                  │                   │        │ Task 3.   │");
            Console.WriteLine("       ┌────────► │     Main Hall     │        └────┬──────┘");
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