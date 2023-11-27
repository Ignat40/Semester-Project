namespace WorldOfZuul
{
    public class Room
    {
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set;}
        public Dictionary<string, Room> Exits { get; private set; } = new();

        public Room(string shortDesc, string longDesc)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
        }

        public void SetExits(Room? mainHall, Room? farm, Room? kitchen, Room? beach, Room? basement, Room? roof)
        {
            SetExit("mainHall", mainHall);
            
            SetExit("farm", farm);
            SetExit("kitchen", kitchen);
            SetExit("beach", beach);
            SetExit("basement", basement);
            SetExit("rooftop", roof);
        }

        public void SetExit(string direction, Room? neighbor)
        {
            if (neighbor != null)
                Exits[direction] = neighbor;
        }
    }
}
