using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f = new Fraction(2, 1);
            Fraction f2 = new Fraction(1, 6);
            Fraction f3 = new Fraction(2, 7);
            Fraction f4 = new Fraction(25, -5);
            f.Sum(f2);
            Console.WriteLine("Multiply:");
            f.Multiply(f3);
            f.Division(f2);
            Console.WriteLine(f.Equals(f2));
            Console.WriteLine(f.IsRight());
            Console.WriteLine(f2.Decimal());
            f._Short();
            f.Show();
            f2.Show();
            Console.WriteLine("  JSON: ");
            Console.WriteLine();
            f2.CreateFile("FirstFraction.json");
            Fraction.OpenFile("FirstFraction.json");
        }
    }
}
