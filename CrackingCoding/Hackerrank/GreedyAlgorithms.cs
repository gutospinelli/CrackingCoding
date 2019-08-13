using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCoding
{
    public static class GreedyAlgorithms
    {
        #region Greedy Algotithms
        //Minimum Absolute Difference in an Array
        public static int minimumAbsoluteDifference(int[] arr) {
            int min = int.MaxValue;
            int i = 0;
            int j = 1;

            if(arr.Length < 2) return 0; //error, array must have at least 2 elements

            while (i < arr.Length - 1)
            {
                int diff = arr[i] - arr[j];
                if (Math.Abs(diff) < min)
                    min = Math.Abs(diff);
                j++;

                if(j == arr.Length)
                {
                    i++;
                    j = i + 1;
                }
            }

            return min;
        }

        public static int minimumAbsoluteDifferenceSort(int[] arr) {
            int n = arr.Length;

            Array.Sort(arr);

            int minAbsDiff = Math.Abs(arr[0] - arr[1]);

            for(int i = 1; i < n - 1; i++)
            {
                int tempDiff = Math.Abs(arr[i] - arr[i + 1]);
                if(tempDiff < minAbsDiff)
                    minAbsDiff = tempDiff;
            }
            return minAbsDiff;
        }
        #endregion


    }
}
