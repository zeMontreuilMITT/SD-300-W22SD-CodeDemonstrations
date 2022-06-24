ISaysHello Entity;
bool IsPerson = true;

if (IsPerson)
{
    Entity = new Person();
} else
{
    Entity = new Alien();
}

Entity.SayHello();




interface ISaysHello
{
    string SayHello();
}

interface IMakeSandwiches
{
    string MakeSandwiches(string mainIngredient);
}

interface IDoRocketScience
{
    int RocketNumbers();
}

class Person: ISaysHello, IMakeSandwiches
{
    public string Name { get; set; }
    public string SayHello()
    {
        return $"Hello, my name is {Name}, the Person";
    }

    public string MakeSandwiches(string mainIngredient)
    {
        return $"Because I implement IMakeSandwiches, I can make sandwiches with {mainIngredient}";
    }
}

class Alien: ISaysHello, IDoRocketScience
{
    public string AlienTitle { get; set; }
    public int ValueOfPi { get; set; }
    public string DoSomeAlienStuff()
    {
        return "The alien does stuff.";
    }
    public string SayHello()
    {
        return $"Greetings, my name is {AlienTitle} and I am in fact an alien";
    }

    public int RocketNumbers()
    {
        return Math.Max(1, 2);
    }
}