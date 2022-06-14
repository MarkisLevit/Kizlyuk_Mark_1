using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    class Fraction
    {
        public int num { get; set; }
        public int den { get; set; }
        public Fraction(int num, int den)
        {
            this.num = num;
            this.den = den;
        }
        public void _Short()
        {
            int nsd = a(num, den);
            num /= nsd;
            den /= nsd;
        }
        public void Sum(Fraction f)
        {
            int Sumden = a(den, f.den);
            if (den != Sumden && f.den != Sumden)
            {
                num *= Sumden;
                f.num *= Sumden;
            }
            Console.WriteLine("Sum:");
            Show(new Fraction(num + f.num, Sumden));
        }
        public void Difference(Fraction f)
        {
            int Sumden = a(den, f.den);
            if (den != Sumden && f.den != Sumden)
            {
                num *= Sumden;
                f.num *= Sumden;
            }
            Console.WriteLine("Difference:");
            Show(new Fraction(num - f.num, Sumden));
        }
        public void Multiply(Fraction f)
        {
            Show(new Fraction(num * f.num, den * f.den));
        }
        public void Division(Fraction f)
        {
            Console.WriteLine("Division:");
            Multiply(new Fraction(f.den, f.num));
        }
        public bool Equals(Fraction f)
        {
            f._Short();
            _Short();
            Console.WriteLine("Equal:");
            return (num == f.num && den == f.den);
        }
        public bool IsRight()
        {
            Console.WriteLine("Correctness:");
            return num < den;
        }
        public double Decimal()
        {
            double result = (double)num / (double)den;
            return result;
        }
        static private int a(int c, int b)
        {
            return (c == 0) ? b : a(b % c, c);
        }
        public void Show()
        {
            Show(this);
        }
        static private void Show(Fraction f)
        {
            f._Short();
            if (f.num < 0 && f.den < 0)
            {
                Console.WriteLine(Math.Abs(f.num));
                Console.WriteLine(new string('-', Math.Abs(f.num).ToString().Length));
                Console.WriteLine(Math.Abs(f.den));
            }
            else if (f.num < 0 || f.den < 0)
            {
                Console.WriteLine("  " + Math.Abs(f.num));
                Console.WriteLine("-" + " " + new string('-', Math.Abs(f.num).ToString().Length));
                Console.WriteLine("  " + Math.Abs(f.den));
            }
            else
            {
                Console.WriteLine(f.num);
                Console.WriteLine(new string('-', f.num.ToString().Length));
                Console.WriteLine(f.den);
            }
            Console.WriteLine();
        }
        public void CreateFile(string fileName)
        {
            string jsonString = System.Text.Json.JsonSerializer.Serialize(this);
            File.WriteAllText(fileName, jsonString);
        }
        static public void OpenFile(string fileName)
        {
            try
            {
                var path = Path.Combine(Environment.CurrentDirectory, fileName);
                var json = File.ReadAllText(path);
                Fraction JSONfraction = JsonConvert.DeserializeObject<Fraction>(json);
                Show(JSONfraction);
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

        }
    }
}
