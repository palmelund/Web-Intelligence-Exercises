using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NearDuplicate
{
    public class NearDuplicateDetector
    {
        private readonly int _singleLength;

        public NearDuplicateDetector(int sideLength = 4)
        {
            _singleLength = sideLength;
        }

        public float JaccardSimilarity(string a, string b)
        {
            return JaccardSimilarity(Shinglefy(a), Shinglefy(b));
        }

        public float JaccardSimilarity(List<string[]> shingleA, List<string[]> shingleB)
        {
            var overlapping = shingleA.Where(stringse => shingleB.Any(a => a.SequenceEqual(stringse))).ToList();

            float overlap = overlapping.Count;

            var union = shingleA.Count + shingleB.Count - overlap;
            
            return overlap / union;
        }

        public bool NearDuplicate(string a, string b)
        {

            var aShingles = Shinglefy(a);
            var bShingles = Shinglefy(b);
            


            return false;
        }
        
        private List<string[]> Shinglefy(string s)
        {
            var words = s.Replace(".", "").Replace(",","").Split(' ').ToList();
            
            var shingles = new List<string[]>();

            for (var i = 0; i < words.Count - _singleLength + 1; i++)
            {
                shingles.Add(words.GetRange(i, _singleLength).ToArray());
            }

            return shingles;
        }
    }
}