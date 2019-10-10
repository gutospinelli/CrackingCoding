using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCoding
{
    public static class StringManipulation
    {
        #region String Manipulation (4/5)
        //Making Anagrams
        public static int makeAnagram(string a, string b)
        {
            Dictionary<char, int> dictSmaller = new Dictionary<char, int>();

            string smaller, bigger;
            int numEqualChars = 0;


            if (a.Length <= b.Length)
            {
                smaller = a;
                bigger = b;
            }
            else
            {
                smaller = b;
                bigger = a;
            }

            foreach (char c in smaller)
            {
                if (dictSmaller.ContainsKey(c))
                {
                    dictSmaller[c]++;
                }
                else
                {
                    dictSmaller[c] = 1;
                }
            }
            foreach (char c in bigger)
            {
                if (dictSmaller.ContainsKey(c) && dictSmaller[c] >= 1)
                {
                    numEqualChars = numEqualChars + 2;
                    dictSmaller[c]--;
                }
            }

            return a.Length + b.Length - numEqualChars;

        }

        // AlternatingCharacters
        public static int alternatingCharacters(string s)
        {
            int deletionNumber = 0;
            char actualChar = 'A'; 
            char firstChar;
            bool first = false;

            foreach (char c in s)
            {
                //base case
                if(!first) {
                    firstChar = c;
                    first =  true;
                    actualChar = c;
                } else
                {
                    if (c == actualChar)
                    {
                        deletionNumber++;
                    } else
                    {
                        actualChar = c;
                    }
                }
            }
            return deletionNumber;
        }

        //Sherlock and the Valid String
        public static string isValid(string s) {
            Dictionary<char,int> dict = new Dictionary<char, int>();
            
            //We know from corolary that s is not empty string 1<= s <= 10^5
            int maxValue = 1;
            bool isSherlockValid = true;
            int countMax = 0;
            int countCurr = 0;

            //Fill a dict with number of char occurrences
            foreach (char c in s)
            {
                if(dict.ContainsKey(c))
                {
                    //increase the count for that char
                    dict[c]++;

                    if(dict[c] > maxValue)
                    {
                        maxValue = dict[c];
                    } 
                } else
                {
                    //insert first occurrency of char
                    dict[c] = 1;
                }
            }


            int j = dict.Values.Select(i => i).Distinct().Count();
         
            
            foreach (int v in dict.Values)
            {
                if (maxValue - v > 1)
                {
                    if (j>2) {
                        isSherlockValid = false;           
                        break;
                    }

                    if(j == 2)
                    {
                        List<int> lista = dict.Values.Select(i => i).Distinct().ToList();
                        int freqL0 = dict.Values.Where(f => f == lista[0]).Count();
                        int freqL1 = dict.Values.Where(f => f == lista[1]).Count();

                        if(
                            ((freqL0 > 1) && (freqL1 > 1)) ||
                            ((freqL0 == 1) && (lista[0]-1 != lista[1]) && (lista[0]-1 != 0)) ||
                            ((freqL1 == 1) && (lista[1]-1 != lista[0]) && (lista[1]-1 != 0))
                          )
                        {
                            isSherlockValid = false;
                        }
                    }
                }

                //v could be only maxValue or maxValue - 1              
                if (v == maxValue)
                {
                    countMax++;
                }

                if (v == maxValue - 1)
                {
                    countCurr++;

                }

                if (countCurr > 1 && countMax > 1)
                {
                    isSherlockValid = false;
                    break;
                }

            }
            return isSherlockValid ? "YES" : "NO";
        }

        //Special Palindrome Again
        public static long substrCount(int n, string s) {
            long count = 0;
            for (int i = 0; i < s.Length; i++) {
                int innerCounter = 1;

                int counterDown = 0;
                int counterUp = 1;
                while (i - innerCounter >= 0 && i + innerCounter < s.Length
                        && s[i - innerCounter] == s[i - 1] && s[i + innerCounter] == s[i - 1]) {
                    count++;
                    innerCounter++;
                }

                while (i - counterDown >= 0 && i + counterUp < s.Length && s[i - counterDown] == s[i]
                        && s[i + counterUp] == s[i]) {
                    count++;
                    counterDown++;
                    counterUp++;
                }
            }

            return count + s.Length;
        }

        // Common Child 
        public static int commonChild(string s1, string s2) {
            
            //HARRY 
            //SALLY
                       
            //Matrix Start
            //   HARRY
            //  000000
            //S 0
            //A 0
            //L 0
            //L 0
            //Y 0

            //Matrix End
            //i   012345
            //j    HARRY(s1)
            //0   000000
            //1 S 000000
            //2 A 001111
            //3 L 001111
            //4 L 001111
            //5 Y 001112
            //s2

            int[,] matrix = new int[s1.Length + 1, s2.Length + 1];
            
            // Location in s2 (Left)
            for (int i = 0; i <= s2.Length; i++)
            {
                // Location in s1 (Top)
                for (int j = 0; j <= s1.Length; j++)
                {
                    if (i == 0 || j == 0)
                        matrix[i, j] = 0;
                    else if (s1[j - 1] == s2[i - 1])
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    else
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                }
            }

            return matrix[s1.Length, s2.Length];
        }

        // Game of Thrones - I
        public static string gameOfThrones(string s) {
            int oddCount = 0;

            //Fill a dict with number of char occurrences
            Dictionary<char,int> dict = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if(dict.ContainsKey(c))
                {
                    //increase the count for that char
                    dict[c]++;
                } else
                {
                    //insert first occurrency of char
                    dict[c] = 1;
                }
            }
            //Search count for each char to see if we can form palindromes. To form a palimdrom we must have 0 or 1 odd at max
            foreach (int i in dict.Values)
            {
                if(i%2 != 0)
                    oddCount++;
            }


            return oddCount > 1 ? "NO" : "YES";
        }



        #endregion
    }
}
