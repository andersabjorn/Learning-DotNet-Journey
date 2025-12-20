using System;
// --------------------------------------------------------------------------------------
// Exercise: Static vs Instance Members
// 
// Summary:
// 1. Instance Members (Name, Weight): 
//    Belong to the specific object (the individual house). 
//    Changing 'a1.Name' does NOT change 'a2.Name'.
//
// 2. Static Members (NrInstances, Heaviest, Lightest): 
//    Belong to the CLASS itself (the blueprint/shared whiteboard). 
//    Shared by ALL objects. 
//    When 'a4' was created, it could update the 'Heaviest' record that 'a3' had set previously.
//    Perfect for global counters, settings, or tracking records across all instances.
// --------------------------------------------------------------------------------------
namespace Exercise_02_StaticVsInstance
{
    class Program
    {
        public class Apple
        {
            // Instance fields (Varje äpple har sin egen vikt och namn)
            public string Name;
            public decimal Weight = 0;

            // Static field (Alla äpplen delar på denna enda räknare)
            public static int NrInstances;

            public static decimal Heaviest = 0;

            public static decimal Lightest = 1000;
            

            // Konstruktor 1: Tar bara namn
            public Apple(string n)
            {
                Name = n;
                NrInstances = NrInstances + 1; // Ökar den gemensamma räknaren
            }

            // Konstruktor 2: Tar namn OCH vikt
            // ": this(n)" betyder att den först anropar den andra konstruktorn ovan (för att sätta namn och öka räknaren)
            public Apple(string n, decimal weight) : this(n)
            {
                Weight = weight;

                if (Weight > Heaviest)
                {
                    Heaviest = Weight;
                }

                if (Weight < Lightest)
                {
                    Lightest = Weight;
                }
            }
        }

        static void Main(string[] args)
        {
            Apple a1 = new Apple("Pink Lady");
            Apple a2 = new Apple("Discovery");
            Apple a3 = new Apple("Granny Smith", 100.3M);
            Apple a4 = new Apple("Royal Gala", 250.5M);

            Console.WriteLine($"Apple 1: {a1.Name}");
            Console.WriteLine($"Apple 2: {a2.Name}");
            Console.WriteLine($"Tyngsta: {Apple.Heaviest} g");
            Console.WriteLine($"Lättaste: {Apple.Lightest} g");
            
            // Eftersom NrInstances är static, når vi den via Klassnamnet (Apple), inte via variabeln (a1)
            Console.WriteLine($"Antal skapade äpplen: {Apple.NrInstances}");
        }
    }
}