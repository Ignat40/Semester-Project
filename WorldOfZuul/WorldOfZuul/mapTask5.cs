using System;

namespace WorldOfZuul
{
    class MapTask5 : IMap
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
            Console.WriteLine("       ┌────────► │   Main Hall       │        └────┬──────┘");
            Console.WriteLine("       │          │                   │             │");
            Console.WriteLine(" ┌─────┴───────┐  │                   │             ▼");
            Console.WriteLine(" │             │  └───────────────────┘    ┌─────────────┐");
            Console.WriteLine(" │    You      │                           │             │");
            Console.WriteLine(" │  are here   │                           │             │");
            Console.WriteLine(" │             │                           │   Task 4.   │");
            Console.WriteLine(" │             │◄──────────────────────────┤             │");
            Console.WriteLine(" └─────────────┘                           └─────────────");
        }
    }

}