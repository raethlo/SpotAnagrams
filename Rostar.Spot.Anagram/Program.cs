﻿using System;
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

            string res = new string(str.Except(anag).ToArray());

            return string.IsNullOrEmpty(res);
        }

        public static List<string> ChooseAnagrams(this string str, List<string> words)
        {
            return words.Where(w => w.HasAnagram(str) == true).ToList();;
        }
    }


}