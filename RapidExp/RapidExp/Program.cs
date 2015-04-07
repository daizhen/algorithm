using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidExp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Mod(1, 2, 31, 3));
            Console.WriteLine(Mod(1, 2, 31, 5));
            Console.WriteLine(Mod(1, 2, 31, 7));
            Console.WriteLine(Mod(1, 2, 31, 11));
        }

       /// <summary>
        /// Caculate prefix * factor^n % b
       /// </summary>
       /// <param name="prefix"></param>
       /// <param name="factor"></param>
       /// <param name="n"></param>
       /// <param name="b"></param>
       /// <returns></returns>
        private static int Mod(int prefix, int factor, int n, int b)
        {
            if (n == 0)
            {
                return prefix % b;
            }

            if (factor < b)
            {
                int newFactor = factor;
                int count;
                int newPrefix = prefix;

                for (count = 1; count < n; count++)
                {
                    newFactor = newFactor * factor;

                    if (newFactor >= b)
                    {
                        break;
                    }
                }
                count++;

                for (int i = 0; i < n % count; i++)
                {
                    newPrefix = newPrefix * factor;
                }
                newPrefix = newPrefix % b;

                return Mod(newPrefix, newFactor % b, n / count, b);
            }
            else
            {
                return Mod(prefix, factor % b, n, b);
            }
        }
    }
}
