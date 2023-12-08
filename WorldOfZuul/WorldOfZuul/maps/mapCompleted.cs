using System;

namespace WorldOfZuul
{
    class MapCompleted : IMap
    {
        public virtual void DisplayMap()
        {
            Console.WriteLine("                      ┌──────────────────┐");
            Console.WriteLine("                      │                  │");
            Console.WriteLine("┌────────────┐        │                  ├───────────┐");
            Console.WriteLine("│            ├───────►│   Completed!     │           │");
            Console.WriteLine("│ Completed! │        |                  │           │");
            Console.WriteLine("│            │        └──────────────────┘           │");
            Console.WriteLine("└────────────┘                                       │");
            Console.WriteLine("      ▲           ┌───────────────────┐        ┌─────▼─────┐");
            Console.WriteLine("      │           │                   │        │           │");
            Console.WriteLine("                  │                   │        │ Completed!│");
            Console.WriteLine("       ┌────────► │     Main Hall     │        └────┬──────┘");
            Console.WriteLine("       │          │                   │             │");
            Console.WriteLine(" ┌─────┴───────┐  │                   │             ▼");
            Console.WriteLine(" │             │  └───────────────────┘    ┌─────────────┐");
            Console.WriteLine(" │             │                           │             │");
            Console.WriteLine(" │ Completed!  │                           │             │");
            Console.WriteLine(" │             │                           │ Completed!  │");
            Console.WriteLine(" │             │◄──────────────────────────┤             │");
            Console.WriteLine(" └─────────────┘                           └─────────────");
        }
    }

}