using System;
using System.Collections.Generic;
using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter word"); //eg: cbaabbb
            var kk = Console.ReadLine();
            Console.WriteLine(getPalindrome(kk));

        }

        class mod
        {
            public char first { get; set; }
            public int second { get; set; }
        }
        
        private static string getPalindrome(string str)
        {

            // Store counts of characters 
            List<mod> hmap = new List<mod>();
            for (int i = 0; i < str.Length; i++)
            {
                if (hmap.Any(d => d.first == str[i]))
                {
                    hmap.FirstOrDefault(d => d.first == str[i]).second++;
                }
                else
                    hmap.Add(new mod() { first = str[i], second = 1 });
            }

            /* find the number of odd elements. 
                Takes O(n) */
            int oddCount = 0;
            char oddChar = 'n';
            int second = 0;
            int second2 = 0;
            foreach (var x in hmap)
            {
                if (x.second % 2 != 0)
                {
                    oddCount++;
                    oddChar = x.first;
                    second++;
                }
                second2++;
            }

            /* odd_cnt = 1 only if the length of 
                str is odd */
            if (oddCount > 1 || oddCount == 1 && str.Length % 2 == 0)
            {
                return "NOT PALINDROME";
            }

            /* Generate first half of palindrome */
            string firstHalf = "";
            string secondHalf = "";

            int third = 0;
            foreach (var x in hmap)
            {
                third++;
                // Build a string of floor(count/2) occurrences of current character 
                string s = new string(x.first, x.second / 2);

                // Attach the built string to end of and begin of second half 
                firstHalf += s;
                secondHalf = s + secondHalf;
            }

            // Insert odd character if there is any 
            return (oddCount == 1) ? (firstHalf + oddChar + secondHalf) : (firstHalf + secondHalf);
        }

    }
