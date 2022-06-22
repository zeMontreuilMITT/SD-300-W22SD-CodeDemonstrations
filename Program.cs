Hotel.RegisterGuest("Garfield");
LoyaltyProgramGuest DoubleGarfield = Hotel.RegisterGuest("Garfield", 200);

Guest Heathcliffe = new LoyaltyProgramGuest(200, "Heathcliffe");
Guest Odie = new Guest("Odie");

Console.WriteLine(Odie.SayHello());
Console.WriteLine(Heathcliffe.SayHello());

Room room101 = new Room(101);
Room room102 = new Room(102);
Room room103 = new Room(103);
Room suite105 = new Suite(105, 3);


// create a subclass of Guest, called LoyaltyMember
// each time a Guest books a room, they gain "Points" which are stored on the LoyaltyMember object


Hotel.Rooms.Add(suite105);

Hotel.ShowSuites();
static class Hotel
{
    public static HashSet<Guest> Guests { get; set; }  = new HashSet<Guest>();
    public static HashSet<Room> Rooms { get; set; } = new HashSet<Room>();
    public static HashSet<Booking> Bookings { get; set; } = new HashSet<Booking>();
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

    public static LoyaltyProgramGuest RegisterGuest(string name, int points)
    {
        return new LoyaltyProgramGuest(points, name);
    }

    public static void ShowSuites()
    {
        foreach(Room r in Rooms)
        {
            if(r.GetType().FullName == "Suite")
            {
                Console.WriteLine($"{ r.Number} is a suite");
            }
        }
    }

    public static Booking BookRoom(Guest guest, Room room) 
    {
        Booking newBooking = new Booking(guest, room);
        Hotel.Bookings.Add(newBooking);
        return newBooking;
    }
    public static Booking BookRoom(Guest guest, int minimumSize)
    {

        foreach(Room room in Rooms)
        {
            if (room.GetType().FullName == "Suite")
            {
                Suite s;
                s = (Suite)room;
                if(s.Size > minimumSize)
                {
                    Booking newBooking = new Booking(guest, s);
                    Bookings.Add(newBooking);
                    return newBooking;
                }
            }
        }

        throw new Exception("No suites found of the specified size");
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
    public HashSet<Booking> Bookings { get; set; }

    public virtual string SayHello()
    {
        return $"Hello, my name is {Name}";
    }
    public Guest(string name)
    {
        Name = name;
        Bookings = new HashSet<Booking>();
    }
}

class LoyaltyProgramGuest: Guest
{
    public override string SayHello()
    {
        string message = base.SayHello();
        message += ($". I have {Points} points");
        return message;
    }
    public int Points { get; set; }
    public LoyaltyProgramGuest(int initialPoints, string name): base(name)
    {
        Points = initialPoints;
    }
}

// create subclass InternationalGuest
// InternationalGuest has a PointOfOrigin property and a "DeclareOrigin" method that prints that origin ("Hello, my name is Bob and I'm from Yugoslavia")


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

class Suite: Room
{
    public int Size { get; set; }
    public Suite(int number, int size): base(number)
    {
        Size = size;
    }
}