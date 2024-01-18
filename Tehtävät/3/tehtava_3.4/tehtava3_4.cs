using System;

namespace Tehtava
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[]{1,3,5,7,9,11};
            int[] array2 = new int[]{2,6,8,10,12};

            // yhdistää arrayt ja järjestää
            int[] array3 = array1.Concat(array2).ToArray();
            Array.Sort(array3);

            Console.WriteLine("Lista yhdistettynä ja järjestettynä:");

            foreach (int i in array3)
            {
                Console.Write($"{i} ");
            }
        }
    }
}