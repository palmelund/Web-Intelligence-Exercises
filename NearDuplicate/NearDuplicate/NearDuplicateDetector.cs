using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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

        public float JaccardSimilarity(List<int> hashsetA, List<int> hashsetB)
        {
            var overlapping = hashsetA.Where(h => hashsetB.Any(g => h == g)).ToList();
            float overlap = overlapping.Count;

            var union = hashsetA.Count + hashsetB.Count - overlap;

            return overlap / union;
        }

        public float NearDuplicate(string a, string b)
        {

            var aShingles = Shinglefy(a);
            var bShingles = Shinglefy(b);

            var hashesA = aShingles.Select(stringse => stringse.GetHashCode()).ToList();
            var hashesB = bShingles.Select(stringse => stringse.GetHashCode()).ToList();
            
            var rand = new Random();

            var minA = new List<int>();
            var minB = new List<int>();

            var alg = HashAlgorithm.Create("System.Security.Cryptography.SHA512");
            


            for (int i = 0; i < 5; i++)
            {
                var h = rand.Next();

                hashesA = hashesA.Select(s => int.Parse(Permute(s.ToString(), 0, h))).ToList();
                hashesB = hashesB.Select(s => int.Parse(Permute(s.ToString(), 0, h))).ToList();
                
                minA.Add(hashesA.Min());
                minB.Add(hashesB.Min());
            }

            Console.WriteLine("MinA");

            foreach (var m in minA)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("MinB");

            foreach (var m in minB)
            {
                Console.WriteLine(m);
            }


            return JaccardSimilarity(minA, minB);
        }

        private string Permute(string s, int l, int r)
        {
            r %= s.Length;

            if (l == r)
            {
                // Console.WriteLine(s);
            }
            else
            {
                for (var i = l; i <= r; i++)
                {
                    s = Swap(s, l, i);
                    s = Permute(s, l+1, r);
                    s = Swap(s, l, i);
                }
            }

            return s;
        }

        private string Swap(string s, int i, int j)
        {
            var charArray = s.ToCharArray();
            var temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            return string.Concat(charArray);
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