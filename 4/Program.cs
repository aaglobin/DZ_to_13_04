using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLibrary;
using System.Runtime.Serialization.Formatters.Binary;

namespace _4
{
    class Program
    {
        public static int ReadInt(string mass, int max_vallue)
        {
            int a;
            Console.WriteLine(mass);
            while (!int.TryParse(Console.ReadLine(), out a) || a < 1 || a > max_vallue)
            {
                Console.WriteLine("попробуйте снова");
            }
            return a;
        }

        static void Main(string[] args)
        {
            int[] mas = new int[ReadInt("введите размер массива \"генеральной совокупности\" не больше 1000.", 1000)];
            Random ran = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = ran.Next(0, 100);
            }
            int divisor = ReadInt("Введите делитель", 9);
            Multiple multiple = new Multiple(divisor, mas);
            multiple.Name = "генеральной совокупности";

            BinaryFormatter binformatter = new BinaryFormatter();
            FileStream fs = new FileStream("Text.txt",FileMode.Create);
            binformatter.Serialize(fs, multiple);
            fs.Close();

            fs = new FileStream("Text.txt", FileMode.Open);
            try
            {
                multiple = (Multiple)binformatter.Deserialize(fs);
                Console.WriteLine("____________________________");
                Console.WriteLine(multiple.Name);
                Console.WriteLine(multiple.Divisor);
                Console.WriteLine(multiple.Set.ToString());
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
