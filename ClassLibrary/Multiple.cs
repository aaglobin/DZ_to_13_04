using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    public class Multiple
    {
        string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        int divisor;

        public int Divisor
        {
            get
            {
                return divisor;
            }
            set
            {
                if (value > 9 || value < 1) throw new ArgumentException("Некорректное значение переменной divisor");
            }
        }

        int[] set;

        public int[] Set
        {
            get
            {
                return set;
            }
        }

        public Multiple()
        {
            name = "";
            divisor = 0;
            set = new int[0];
        }

        public Multiple(int a, int[] Mas)
        {
            if (a < 1 || a > 9) throw new ArgumentException("Некорректное значение переменной divisor");
            divisor = a;
            int count = 0;
            for (int i = 0; i < Mas.Length; i++)
            {
                if (Mas[i] % divisor == 0)
                {
                    ++count;
                }
            }
            set = new int[count];
            count = 0;
            for (int i = 0; i < Mas.Length; i++)
            {
                if (Mas[i] % divisor == 0)
                {
                    set[count] = Mas[i];
                    ++count;
                }
            }
        }
    }
}
