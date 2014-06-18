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
        public static bool HasAnagram(this string str,string anag)
        {
            if(str.Length != anag.Length)
                return false;
            
            //vyskyty pismen v slovach
            Dictionary<char, int> occur1 = new Dictionary<char, int>();
            Dictionary<char, int> occur2 = new Dictionary<char, int>();

            //mozeme ist do str.Len lebo oba stringy su rovnakej dlzky
            for (int i = 0; i < str.Length; i++)
            {
                ++occur1[str[i]];
                ++occur2[anag[i]];
            }

            foreach (var key in occur1.Keys)
                if (occur1[key] != occur2[key])     //ak sa niektore vyskyty nezhoduju, nie su to anagramy
                    return false;
            //ak sa vsetko zhodovalo, tak to anagramy su
            return true;
        }

        public static List<string> ChooseAnagrams(this string str, List<string> words)
        {
            return words.Where(w => w.HasAnagram(str) == true).ToList();;
        }
    }


}
