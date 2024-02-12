using System;
using System.Collections.Generic;
namespace Lab_1_KPZ_Maksym_Shyriaiev
{ 
// Базовий клас для всіх тварин
class Animal
{
    public string Species { get; set; }
    public string Name { get; set; }

    public Animal(string species, string name)
    {
        Species = species;
        Name = name;
    }
}

// Підкласи для різних видів тварин
class Mammal : Animal
{
    public string FurColor { get; set; }

    public Mammal(string species, string name, string furColor) : base(species, name)
    {
        FurColor = furColor;
    }
}

class Reptile : Animal
{
    public string ScaleType { get; set; }

    public Reptile(string species, string name, string scaleType) : base(species, name)
    {
        ScaleType = scaleType;
    }
}

// Клас для вольєру
class Enclosure
{
    public string Name { get; set; }
    public string Size { get; set; }
}

// Клас для корму для тварин
class Food
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; set; }
}

    // Класи працівників
    class ZooKeeper
    {
        public string Name { get; set; }
        public string Position { get; set; }

        // Конструктор з двома параметрами
        public ZooKeeper(string name, string position)
        {
            Name = name;
            Position = position;
        }
        public ZooKeeper()
        {
            // Порожній конструктор
        }
    }

    class Veterinarian : ZooKeeper
{
    public string Specialization { get; set; }

    public Veterinarian(string name, string position, string specialization) : base(name, position)
    {
        Specialization = specialization;
    }
}

// Клас для інвентаризації
class Inventory
{
    public List<Animal> Animals { get; set; }
    public List<Enclosure> Enclosures { get; set; }
    public List<Food> Foods { get; set; }
    public List<ZooKeeper> ZooKeepers { get; set; }

    public Inventory(List<Animal> animals, List<Enclosure> enclosures, List<Food> foods, List<ZooKeeper> zookeepers)
    {
        Animals = animals;
        Enclosures = enclosures;
        Foods = foods;
        ZooKeepers = zookeepers;
    }

    // Методи виведення інформації
    public void DisplayAnimals()
    {
        foreach (var animal in Animals)
        {
            Console.WriteLine($"{animal.Name} - {animal.Species}");
        }
    }

    public void DisplayEnclosures()
    {
        foreach (var enclosure in Enclosures)
        {
            Console.WriteLine($"{enclosure.Name} - {enclosure.Size}");
        }
    }

    public void DisplayFoods()
    {
        foreach (var food in Foods)
        {
            Console.WriteLine($"{food.Name} - {food.Quantity} - {food.ExpiryDate}");
        }
    }

    public void DisplayZooKeepers()
    {
        foreach (var zooKeeper in ZooKeepers)
        {
            Console.WriteLine($"{zooKeeper.Name} - {zooKeeper.Position}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад створення об'єктів та використання інвентаризації
        var lion = new Mammal("Lion", "Leo", "Golden");
        var crocodile = new Reptile("Crocodile", "Snappy", "Hard");
        var zooAnimals = new List<Animal> { lion, crocodile };

        var bigEnclosure = new Enclosure { Name = "Big Enclosure", Size = "Large" };
        var smallEnclosure = new Enclosure { Name = "Small Enclosure", Size = "Small" };
        var zooEnclosures = new List<Enclosure> { bigEnclosure, smallEnclosure };

        var meat = new Food { Name = "Meat", Quantity = 100, ExpiryDate = DateTime.Now.AddDays(7) };
        var vegetables = new Food { Name = "Vegetables", Quantity = 50, ExpiryDate = DateTime.Now.AddDays(5) };
        var zooFoods = new List<Food> { meat, vegetables };

        var zooKeeper = new ZooKeeper { Name = "John", Position = "Zoo Keeper" };
        var vet = new Veterinarian("Dr. Smith", "Veterinarian", "Wildlife");

        var zooKeepers = new List<ZooKeeper> { zooKeeper, vet };

        var zooInventory = new Inventory(zooAnimals, zooEnclosures, zooFoods, zooKeepers);

        // Виведення інформації про зоопарк
        Console.WriteLine("Animals:");
        zooInventory.DisplayAnimals();

        Console.WriteLine("\nEnclosures:");
        zooInventory.DisplayEnclosures();

        Console.WriteLine("\nFoods:");
        zooInventory.DisplayFoods();

        Console.WriteLine("\nZoo Keepers:");
        zooInventory.DisplayZooKeepers();
    }
}
}
