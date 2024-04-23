using System;
using System.Collections.Generic;

// CREATE INTERNAL CLASS FOR ANIMAL
internal class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void Eat()
    {
        Console.WriteLine(Name + " is eating...");
    }

    public virtual void Sleep()
    {
        Console.WriteLine(Name + " is sleeping...");
    }
}



// INCLUDE THE BEHAVIOUR OF THE ANIMAL
interface IFeedable
{
    void Feed();
}

interface IMovable
{
    void Move();
}




//DEFINE SPECEFIC ANIMAL CLASSES AND IMPLIMENT INTERFACES
class Lion : Animal, IFeedable, IMovable
{
    public Lion()
    {
        Name = "Lion";
    }

    public override void Eat()
    {
        Console.WriteLine(Name + " is eating meat.");
    }

    public override void Sleep()
    {
        Console.WriteLine(Name + " is sleeping in the shade.");
    }

    public void Feed()
    {
        Console.WriteLine("Feeding the " + Name + "...");
    }

    public void Move()
    {
        Console.WriteLine(Name + " is prowling around.");
    }
}


//DEFINE SPECEFIC ANIMAL CLASSES AND IMPLIMENT INTERFACES
class Dog : Animal, IFeedable, IMovable
{
    public Dog()
    {
        Name = "Dog";
    }

    public override void Eat()
    {
        Console.WriteLine(Name + " is eating meat.");
    }

    public override void Sleep()
    {
        Console.WriteLine(Name + " is sleeping in the shade.");
    }

    public void Feed()
    {
        Console.WriteLine("Feeding the " + Name + "...");
    }

    public void Move()
    {
        Console.WriteLine(Name + " is prowling around.");
    }
}

//DEFINE SPECEFIC ANIMAL CLASSES AND IMPLIMENT INTERFACES
class Wolf : Animal, IFeedable, IMovable
{
    public Wolf()
    {
        Name = "Wolf";
    }

    public override void Eat()
    {
        Console.WriteLine(Name + " is eating meat.");
    }

    public override void Sleep()
    {
        Console.WriteLine(Name + " is sleeping in the shade.");
    }

    public void Feed()
    {
        Console.WriteLine("Feeding the " + Name + "...");
    }

    public void Move()
    {
        Console.WriteLine(Name + " is prowling around.");
    }
}


//DEFINE SPECEFIC ANIMAL CLASSES AND IMPLIMENT INTERFACES
class Parrot : Animal, IFeedable, IMovable
{
    public Parrot()
    {
        Name = "Parrot";
    }

    public override void Eat()
    {
        Console.WriteLine(Name + " is eating seeds.");
    }

    public override void Sleep()
    {
        Console.WriteLine(Name + " is sleeping on a perch.");
    }

    public void Feed()
    {
        Console.WriteLine("Feeding the " + Name + "...");
    }

    public void Move()
    {
        Console.WriteLine(Name + " is flying from branch to branch.");
    }
}

class Turtle : Animal, IFeedable, IMovable
{
    public Turtle()
    {
        Name = "Turtle";
    }

    public override void Eat()
    {
        Console.WriteLine(Name + " is eating lettuce.");
    }

    public override void Sleep()
    {
        Console.WriteLine(Name + " is sleeping underwater.");
    }

    public void Feed()
    {
        Console.WriteLine("Feeding the " + Name + "...");
    }

    public void Move()
    {
        Console.WriteLine(Name + " is slowly moving along.");
    }
}

// MAIN CLASS PROGRAME
class Program
{
    static void Main()
    {
        //ASK ADMIN NAME
        Console.WriteLine("Enter your name: ");
        string adminName = Console.ReadLine();
        Console.WriteLine($"Hello, {adminName}! Welcome to the Virtual Zoo Management System.");

        List<Animal> animals = new List<Animal>();
        string input = "";

        while (true)
        {
            Console.WriteLine("Enter 'add' to add an animal, 'check' to check an animal, 'remove' to remove an animal, or 'exit' to exit:");
            input = Console.ReadLine().ToLower();

            if (input == "add")
            {
                Console.WriteLine("Which animal would you like to add? (lion/parrot/turtle)");
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "lion":
                        animals.Add(new Lion());
                        Console.WriteLine("Lion added.");
                        break;
                    case "parrot":
                        animals.Add(new Parrot());
                        Console.WriteLine("Parrot added.");
                        break;
                    case "turtle":
                        animals.Add(new Turtle());
                        Console.WriteLine("Turtle added.");
                        break;
                    default:
                        Console.WriteLine("Unknown animal.");
                        break;
                }
            }
            else if (input == "check")
            {
                Console.WriteLine("Which animal would you like to check?");
                input = Console.ReadLine().ToLower();

                foreach (var animal in animals)
                {
                    if (animal.Name.ToLower() == input)
                    {
                        animal.Eat();
                        animal.Sleep();

                        if (animal is IFeedable feedable)
                        {
                            feedable.Feed();
                        }
                        if (animal is IMovable movable)
                        {
                            movable.Move();
                        }
                        break;
                    }
                }
            }
            else if (input == "remove")
            {
                Console.WriteLine("Which animal would you like to remove?");
                input = Console.ReadLine().ToLower();

                var animalToRemove = animals.Find(a => a.Name.ToLower() == input);
                if (animalToRemove != null)
                {
                    animals.Remove(animalToRemove);
                    Console.WriteLine($"{input} removed.");
                }
                else
                {
                    Console.WriteLine("Animal not found.");
                }
            }
            else if (input == "exit")
            {
                break;
            }
        }

        // PRINT OUT THE RESULTS
        Console.WriteLine("Your current animals in the zoo:");
        foreach (var animal in animals)
        {
            Console.WriteLine($"Name: {animal.Name}, Age: {animal.Age}");
        }
    }
}
