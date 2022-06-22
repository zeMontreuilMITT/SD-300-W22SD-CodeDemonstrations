Hotel.RegisterGuest("Garfield");
Guest DoubleGarfield = Hotel.RegisterGuest("Garfield");

Guest Heathcliffe = new Guest("Heathcliffe");
Guest Odie = new Guest("Odie");

Room room101 = new Room(101);
Room room102 = new Room(102);
Room room103 = new Room(103);


static class Hotel
{
    public static HashSet<Guest> Guests { get; set; } = new HashSet<Guest>();
    public static Guest RegisterGuest(string name)
    {
        Guest newGuest = new Guest(name);
        Guests.Add(newGuest);
        return newGuest;
    }

    // add a method for removing all of the guests stored in the Hotel
    public static void RemoveAllGuests()
    {
        foreach(Guest guest in Guests)
        {
            Guests.Remove(guest);
        }
    }

    public static int GetNumberOfGuests()
    {
        return Guests.Count;
    }
}

class Booking
{
    public bool IsCurrent { get; set; } = true;
    public Guest Guest { get; set; }
    public Room Room { get; set; }
    public Booking(Guest guest, Room room)
    {
        Guest = guest;
        Room = room;
    }
}

class Guest
{
    public string Name { get; set; }
    public ICollection<Booking> Bookings { get; set; }
    public Guest(string name)
    {
        Name = name;
        Bookings = new HashSet<Booking>();
    }
}

class Room
{
    public int Number { get; set; }
    public ICollection<Booking> Bookings { get; set; }

    public void CleanRoom()
    {
        Console.WriteLine($"Cleaning Room {Number}");
    }

    public Room(int number)
    {
        Number = number;
        Bookings = new HashSet<Booking>();
    }
}