﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCoding
{
    public static class WarmUp
    {
        #region Warm-up Challenges

        //Sock Merchant
        static int sockMerchant(int n, int[] ar) {
            HashSet<int> cores = new HashSet<int>();
            int pares = 0;

            for (int i = 0; i < n; i++) {
                if (!cores.Add(ar[i])) {
                    pares++;
                    cores.Remove(ar[i]);
                }
            }
            return pares;
        }

        static int sockMerchant2(int n, int[] ar) {
            bool[] cores = new bool[100];
            int pares = 0;

            for (int i = 0; i < n; i++) {
                if (cores[ar[i]]) {
                    pares++;
                    cores[ar[i]] = false;
                } else {
                    cores[ar[i]] = true;
                }
            }
            return pares;
        }

        //Counting Valleys
        static int countingValleys(int n, string s) {
            int level = 0;
            int valleyCount = 0;
            foreach (char c in s) {
                if (c.Equals('U')) {
                    level = level + 1; //if an UP resulted in level 0, Gary just finished a valley
                    if (level == 0) {
                        valleyCount = valleyCount + 1;
                    } 
                } else {
                    level = level - 1;
            } 
        }


        return valleyCount;

    }
        
        //Jumping on the Clouds
        static int jumpingOnClouds(int[] c) {
            int numJumps = 0;
            int i = 0; //she starts at index 0, always a safe spot
            while (i<c.Length)
            {
                if(i+2 < c.Length && c[i+2] == 0) //try to jump 2 spaces, otherwhise, jumps 1
                {
                    i = i + 2;
                } else
                {
                    i = i + 1;
                }
                numJumps = numJumps + 1;
            }
            return numJumps; //because we always count one more jump at while exit
        }

        //Repeated String
        static long repeatedString(string s, long n) {
            long count = 0;

            if (n >= s.Length) //there's repetition 
            {
                //calculate repetitions in base string
                foreach (char c in s)
                {
                    if (c.Equals('a'))
                    {
                        count++;
                    }
                }

                //multiply occurencies by factor
                long multiplyfactor = n / s.Length;
                count =  count * multiplyfactor;

                //deal with remaining substring, if it exists
                long remainder = n % s.Length;
                foreach (char c in s.Substring(0,(int)remainder))
                {
                    if (c.Equals('a'))
                    {
                        count++;
                    }
                }
            } else //we just count on the substring
            {
                foreach (char c in s.Substring(0,(int)n))
                {
                    if (c.Equals('a'))
                    {
                        count++;
                    }
                }
            } 
            return count;
        }
        #endregion
    }
}