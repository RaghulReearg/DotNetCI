using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleConsoleWriteLine
{
    class Program
    {
        static public async Task Main(string[] args)
        {
            Console.WriteLine($"Start Time: {DateTime.Now:HH:mm:ss}");
            Console.WriteLine($" {DateTime.Now}");
            // await data;
            // await data2;
            Animal animal = new Dog("Buddy", "Golden Retriever");
            animal.MakeSound();
            // GuideDog guideDog = new GuideDog("John", "Buddy", "Golden Retriever");
            Shape shape = new Circle(5);
            shape.Area();
            shape.DisplayArea();

            IBank sbi = BankFactory.GetBank("SBI");
            sbi.ValidateCard();
            sbi.WithdrawMoney();
            Program program = new Program();
            Console.WriteLine($"Start Time: {DateTime.Now:HH:mm:ss}");
            Console.WriteLine($" {DateTime.Now}");
            var task1 = program.method1();

            var task2 = program.method2();
            var result1 = await task1;
            var result2 = await task2;
            Console.WriteLine($"Result from method1: {result1}");
            Console.WriteLine($"Result from method2: {result2}");
            Console.WriteLine($"End Time: {DateTime.Now:HH:mm:ss}");

        }

        // static public async Task Getvalye()
        // {
        //     Console.WriteLine("Getting value for 1...");
        //     await Task.Delay(2000); // Simulate an asynchronous operation
        //     Console.WriteLine("Value obtained for 1");
        // }
        // static public async Task Getvalye2()
        // {
        //     Console.WriteLine("Getting value for 2...");
        //     await Task.Delay(3000); // Simulate an asynchronous operation
        //     Console.WriteLine("Value obtained for 2");
        // }
        public async Task<string> method1()
        {
            await Task.Delay(2000); // Simulate a time-consuming operation
            return "Result from method1";
        }
        public async Task<string> method2()
        {
            await Task.Delay(3000); // Simulate a time-consuming operation
            return "Result from method2";
        }

    }
    public class BankFactory
    {
        public static IBank GetBank(string bankType)
        {
            IBank bank = null;
            if (bankType == "SBI")
            {
                bank = new SBI();
            }
            else if (bankType == "HDFC")
            {
                bank = new HDFC();
            }

            return bank;
        }
    }
    public abstract class IBank
    {
        public abstract void ValidateCard();
        public abstract void WithdrawMoney();
    }
    public class SBI : IBank
    {
        public override void ValidateCard()
        {
            Console.WriteLine("SBI card validated.");
        }
        public override void WithdrawMoney()
        {
            Console.WriteLine("Money withdrawn from SBI account.");
        }
    }
    public class HDFC : IBank
    {
        public override void ValidateCard()
        {
            Console.WriteLine("HDFC card validated.");
        }
        public override void WithdrawMoney()
        {
            Console.WriteLine("Money withdrawn from HDFC account.");
        }
    }

    class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double Area()
        {
            return Math.PI * radius * radius;
        }
        public void DisplayArea()
        {
            Console.WriteLine($"The area of the circle with radius {radius} is: {Area()}");
        }

    }
    abstract class Shape
    {
        public abstract double Area();
        public bool flag = true;
        public virtual void DisplayArea()
        {
            Console.WriteLine($"The area of the shape is: {Area()}");
        }
    }

    public class Animal
    {
        protected string animalName = "Dinosaur";
        public Animal(string name)
        {
            Console.WriteLine($"Animal created. {name}");
        }
        public string info { get { return "This is an animal."; } }
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound.");
        }
    }
    public class Dog : Animal
    {
        public Dog(string name, string breed) : base(name)
        {
            Console.WriteLine($"Main Animal. {animalName}");
            Console.WriteLine($"Dog created. {breed}");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks.");
            string s = base.info.ToString();
            Console.WriteLine(s);
        }
    }
    public class GuideDog : Dog
    {
        public string Owner;
        public GuideDog(string owner, string name, string breed) : base(name, breed)
        {
            Console.WriteLine($"Guide Dog created. {owner}");
        }
    }
}
