using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rostar.Spot.Anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = "listen";
            string[] kand = { "enlists", "google", "inlets", "banana", "nestli" };

            foreach (var str in hello.ChooseAnagrams(kand.ToList()))
            {
                Console.WriteLine(str);
            }

            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// Extension method, that checks if a given string is an anagram of 
        /// "this" string
        /// </summary>
        /// <param name="str">current string</param>
        /// <param name="anag">anagram string</param>
        /// <returns></returns>
        public static bool HasAnagram(this string str,string anag)
        {
            if(str.Length != anag.Length)
                return false;

            //mnozinova operacia cez LINQ
            //ak spravim rozdiel mnozin a ostane mi "prazdna mnozina",
            //(string) boli to anagramy
            string res = new string(str.Except(anag).ToArray());

            return string.IsNullOrEmpty(res);
        }

        /// <summary>
        /// Extension method that chooses anagrams of a string from a given list of
        /// candidates
        /// </summary>
        /// <param name="str"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static List<string> ChooseAnagrams(this string str, List<string> words)
        {
            return words.Where(w => w.HasAnagram(str) == true).ToList();;
        }
    }


}
