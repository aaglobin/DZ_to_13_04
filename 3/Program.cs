using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace _3
{
    [Serializable]
    public class Quadratic_Equation
    {
        private double a, b, c;

        public double A
        {
            get
            {
                return a;
            }
            set
            {
                if (value == 0) throw new ArgumentException("Некорректное значение коэффициента A");
                a = value;
            }
        }

        public double B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
            }
        }

        public double C
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
            }
        }

        public Quadratic_Equation()
        {
            a = 1;
            b = 0;
            c = 0;
        }

        public Quadratic_Equation(double a, double b, double c)
        {
            if (a == 0) throw new ArgumentException("Некорректное значение коэффициента A");
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double Discriminant()
        {
            return b * b - 4 * a * c;
        }

        public static KeyValuePair<double, double> Roots(Quadratic_Equation quadratic_Equation)
        {
            if (quadratic_Equation.Discriminant() < 0) throw new ArgumentException("уравнение не имеет корней");
            double x1 = (-quadratic_Equation.B + Math.Pow(quadratic_Equation.Discriminant(), 0.5)) / (2 * quadratic_Equation.a);
            double x2 = (-quadratic_Equation.B - Math.Pow(quadratic_Equation.Discriminant(), 0.5)) / (2 * quadratic_Equation.a);
            return new KeyValuePair<double, double>(x1, x2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            try
            {
                Quadratic_Equation quadratic_Equation = new Quadratic_Equation(ran.NextDouble() + ran.Next(), ran.NextDouble() + ran.Next(), ran.NextDouble() + ran.Next());
                XmlSerializer ser = new XmlSerializer(typeof(Quadratic_Equation));
                FileStream fs = new FileStream("equation.ser", FileMode.Create);
                ser.Serialize(fs, quadratic_Equation);
                fs.Close();
                fs = File.OpenRead("equation.ser");
                Quadratic_Equation quadratic = (Quadratic_Equation)ser.Deserialize(fs);
                Console.WriteLine("{0} * x * x + {1} * x + {2} = 0", quadratic.A, quadratic.B, quadratic.C);
                KeyValuePair<double, double> pair = Quadratic_Equation.Roots(quadratic);
                Console.WriteLine("x1 = {0} \nx2 = {1}", pair.Key, pair.Value);
                Console.ReadKey();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            
        }
    }
}
