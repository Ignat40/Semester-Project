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

        public void SetExits(Room? mainHall, Room? theatre, Room? farm, Room? kitchen, Room? beach, Room? basement, Room? roof)
        {
            SetExit("mainHall", mainHall);
            SetExit("theatre", theatre);
            SetExit("farm", farm);
            SetExit("kitchen", kitchen);
            SetExit("beach", beach);
            SetExit("basement", basement);
            SetExit("roof", neighbor: roof);
        }

        public void SetExit(string direction, Room? neighbor)
        {
            if (neighbor != null)
                Exits[direction] = neighbor;
        }
    }
}
