using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCoding
{
    public static class Recursion
    {
        #region Recursion and Backtracking

        //Fibonacci
        public static int Fibonacci(int n) {
            int NumMinusTwo;
            int NumMinusOne = 0;
            int Num = 1;

            for (int i = 1; i < n ; i++) {

                NumMinusTwo = NumMinusOne;

                NumMinusOne = Num;

                Num = NumMinusTwo + NumMinusOne;

            }
            return Num;
        }

        public static int FibonacciRecursion(int n) {
            //Error Cases
            if (n < 0)
                return -1; //Error!
            //base cases
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            return (FibonacciRecursion(n-1) + FibonacciRecursion(n-2));

        }

        [Memoized]
        public static long FibMemoized(long n)
        {
            if (n == 0L)
                return 0L;
            if (n == 1L)
                return 1L;
            return FibMemoized(n - 1) + FibMemoized(n - 2);
        }

        //Recursion: Davis' Staircase
        static int[] cache = new int[36]; //Problem constraint
        public static int stepPermsCacheArray(int n) {
            if(n < 1)
                return -1; //Error case

            //Base cases
            if(n == 1)
                return 1;

            if(n == 2)
                return 2;

            if(n == 3)
                return 4;

            cache[0] = 1;
            cache[1] = 2;
            cache[2] = 4;

            //Recursion cases
            for(int i = 3; i < n; i++)
            {
                cache[i] = cache[i-1] + cache[i-2] + cache[i-3];
            }
                        
            return cache[n-1]; //i.e: array[35] will contain value for n = 36, since arrays are 0 indexed    
        }

        public static int stepPerms(int n) {
            if(n < 1)
                return -1; //Error case

            Dictionary<int,int> cache = new Dictionary<int, int>();
            cache[1] = 1;
            cache[2] = 2;
            cache[3] = 4;

            //Recursion cases
            if(!cache.ContainsKey(n))
            {
                int tmp = GetCache(n-1) + GetCache(n-2) + GetCache(n-3);
                cache.Add(n,tmp);
            }


            int ret = cache[n];
            //We will not overflow int since stepPerms 36 (max constraint) = 2082876103 and int goes til (2,147,483,648 = 2^31)
            //int retInt = (int) (ret % 10000000007); //modulo to not overflow int
                        
            return ret;
        }

        public static int GetCache(int n)
        {
            if(n < 1)
                return -1; //Error case

            //Base cases
            if(n == 1)
                return 1;

            if(n == 2)
                return 2;

            if(n == 3)
                return 4;

            return GetCache(n-1) + GetCache(n-2) + GetCache(n-3);

        }

        public static int getPermsBasic(int n)
        {
            if(n < 1)
                return -1; //Error case

            //Base cases
            if(n == 1)
                return 1;

            if(n == 2)
                return 2;

            if(n == 3)
                return 4;

            //Recursion cases
            long ret = stepPerms(n-1) + stepPerms(n-2) + stepPerms(n-3);
            int retInt = (int) (ret % 10000000007); //modulo to not overflow int
                        
            return retInt;
        }


        #endregion
    }
}
