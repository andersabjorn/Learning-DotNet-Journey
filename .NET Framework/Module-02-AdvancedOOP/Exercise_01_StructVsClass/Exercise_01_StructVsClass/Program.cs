using System;
using System.Threading.Channels;

namespace ADOPM2_01_01
{
    class Program
    {
        public struct valueTypePoint
        {
            public int X, Y;
        }

        public class referenceTypePoint
        {
            public int X, Y;
        }

        static void Main(string[] args)
        {
            valueTypePoint vp1 = new valueTypePoint();
            vp1.X = 7;

            valueTypePoint vp2 = vp1;
            valueTypePoint vp3 = vp1;

            vp1.X = 9;
            Console.WriteLine( vp1.X );
            Console.WriteLine( vp2.X );
            
            Console.WriteLine( vp1.Equals(vp2) );
            Console.WriteLine( vp3.Equals(vp2) );

            referenceTypePoint rp1 = new referenceTypePoint();
            rp1.X = 7;

            referenceTypePoint rp2 = rp1;
            rp2.X = 9;
            
            referenceTypePoint rp4 = new referenceTypePoint();
            rp4.X = rp1.X;
            rp4.Y = rp1.Y;
            
            
            Console.WriteLine(rp1.X);
            Console.WriteLine(rp2.X);
            Console.WriteLine(rp4.X);
            Console.WriteLine(rp1.Equals(rp2));
            Console.WriteLine(rp1.Equals(rp4));
        }
    }
}

// --------------------------------------------------------------------------------------
// Exercise: Deep Copy vs Shallow Copy with Reference Types
// 
// Goal: To demonstrate the difference between copying references and copying actual data.
//
// Summary of what we did:
// 1. Shallow Copy (rp2 = rp1): 
//    We saw that assigning one class variable to another only copies the reference (address).
//    Both 'rp1' and 'rp2' point to the exact same object on the Heap. Changing one affects the other.
//
// 2. Deep Copy (rp4): 
//    To create a truly independent copy, we instantiated a new object using 'new'.
//    Then, we manually copied the values (X and Y) from the original object.
//    Result: 'rp4' lives at a different memory address and is completely unaffected by changes to 'rp1'.
// --------------------------------------------------------------------------------------