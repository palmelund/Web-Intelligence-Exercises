using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstString = "do not worry about your difficulties in mathematics.";
            var secondString = "i would not worry about your difficulties, you can easily learn what is needed.";

            var start = DateTime.Now;

            var res = new NearDuplicateDetector(3).JaccardSimilarity(firstString, secondString);

            var end = DateTime.Now;

            Console.WriteLine($"Near Duplicate: {res:F}, {end - start}");
            Console.ReadKey();
        }
    }
}
