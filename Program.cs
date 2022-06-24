
// create a new enum representing some kind of trait that all your animals will have but with different values that you restrict
// provide a property to the parent Animal class
// inherit Animal in your subclasses and give it a value in the constructor

ICrawl firstAnimal;
ICrawl secondAnimal;

firstAnimal = new Cat();
secondAnimal = new Amoeba();

Console.WriteLine(firstAnimal.Crawl());
Console.WriteLine(secondAnimal.Crawl());

interface IJump
{
    string Jump();
}

interface ICrawl
{
    string Crawl();
}

interface IDivide
{

}

class Animal
{
    public TypeOfSkin Skin { get; set; }
}

class Cat: Animal, IJump, ICrawl
{
    public Cat()
    {
        Skin = TypeOfSkin.Scales;
    }
    public string Jump()
    {
        return $"The cat jumps and lands on all fours, or possibly its forehead :( ";
    }

    public string Crawl()
    {
        return $"The cat crawls on the ground on the ends of its paws";
    }
}

class Amoeba: Animal, IDivide, ICrawl
{
    public string Crawl()
    {
        return "The amoeba crawls around in the petri dish using its pseudopods";
    }

    public Amoeba()
    {
        Skin = TypeOfSkin.Protoplasm;
    }
}

enum TypeOfSkin
{
    Epithelial = 100,
    Scales = 1,
    Fur,
    Feathers,
    Protoplasm,
    Lipids
}

enum BloodType
{
    APositive,
    ANegative,
}