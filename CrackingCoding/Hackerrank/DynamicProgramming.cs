using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCoding
{
    public static class DynamicProgramming
    {
        #region Dynamic Programming
        // maxSubsetSum 
        public static int maxSubsetSum(int[] arr)
        {
            int a=arr[0];
            int b=0;

            for(int i=1;i<arr.Length;i++) {
                int tmp = b;
                b = Math.Max(b, a);
                a = arr[i]+tmp;
            }
            return Math.Max(b, a);

        }

        private static int MaxOfThree(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b,c));
        }
        #endregion
    }
}
