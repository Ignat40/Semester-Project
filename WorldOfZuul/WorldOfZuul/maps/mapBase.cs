using System;

namespace WorldOfZuul
{
    class BaseMap : IMap
    {
        public virtual void DisplayMap()
        {
            Console.WriteLine("                      ┌──────────────────┐");
            Thread.Sleep(100);
            Console.WriteLine("                      │                  │");
            Thread.Sleep(100);
            Console.WriteLine("┌────────────┐        │                  ├───────────┐");
            Thread.Sleep(100);
            Console.WriteLine("│            ├───────►│   Task 2.        │           │");
            Thread.Sleep(100);
            Console.WriteLine("│  Task 1.   │        |                  │           │");
            Thread.Sleep(100);
            Console.WriteLine("│            │        └──────────────────┘           │");
            Thread.Sleep(100);
            Console.WriteLine("└────────────┘                                       │");
            Thread.Sleep(100);
            Console.WriteLine("      ▲           ┌───────────────────┐        ┌─────▼─────┐");

            Console.WriteLine("      │           │                   │        │           │");
            Thread.Sleep(100);
            Console.WriteLine("                  │                   │        │ Task 3.   │");
            Thread.Sleep(100);
            Console.WriteLine("       ┌────────► │   Main Hall       │        └────┬──────┘");
            Thread.Sleep(100);
            Console.WriteLine("       │          │                   │             │");
            Thread.Sleep(100);
            Console.WriteLine(" ┌─────┴───────┐  │                   │             ▼");
            Thread.Sleep(100);
            Console.WriteLine(" │             │  └───────────────────┘    ┌─────────────┐");
            Thread.Sleep(100);
            Console.WriteLine(" │             │                           │             │");
            Thread.Sleep(100);
            Console.WriteLine(" │   Task 5.   │                           │             │");
            Thread.Sleep(100);
            Console.WriteLine(" │             │                           │   Task 4.   │");
            Thread.Sleep(100);
            Console.WriteLine(" │             │◄──────────────────────────┤             │");
            Thread.Sleep(100);
            Console.WriteLine(" └─────────────┘                           └─────────────");
            Thread.Sleep(100);
        }
    }

}