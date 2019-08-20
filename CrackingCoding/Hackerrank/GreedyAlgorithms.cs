using System;
using System.Collections.Generic;
using System.Linq;
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

        //Luck balance
        public static int luckBalance(int k, int[][] contests) {
            int maxLuckBalance = 0;
            int importantContests = 0;
            List<int> lista = new List<int>();
            
            //1st step: find THE MAX "maxLuck possible" and create a list with only important contests
            for (int i = 0; i < contests.GetLength(0); i++)
            {
                if(contests[i][1] == 0)
                {
                    maxLuckBalance = maxLuckBalance + contests[i][0]; //no important contests always sum
                } else
                {
                    importantContests++; //we increase the number of important contests to know how many there are
                    lista.Add(contests[i][0]); //we add the luck of the important contests to the list
                    maxLuckBalance = maxLuckBalance + contests[i][0]; //we sum the luck, to know the max luck we can reach if we could lose all contests
                }
            }

            //2nd step: sort the list and win only the (importantContests - k) lowest value important contest 
            if(k >= importantContests)
            {
                //she can lose all the important contests, so she do it to maximize luck
            } else
            {
                //she choses to win only the least impactant/important contexts in order to maximize luck
                lista.Sort();
                for (int i = 0; i < importantContests-k ; i++)
                {
                    maxLuckBalance = maxLuckBalance - (2*lista[i]); //we need to decrease 2 times the correspondent value because we aready counted it in setp 1 (to find THE MAX maxluck when she can lose all contests)
                }
            }

            return maxLuckBalance;

        }

        public static int luckBalanceLinq(int k, int[][] contests) {
            var minLosses = contests
                .Where(x => x[1] == 1)
                .OrderByDescending(x => x[0])
                .Skip(k)
                .Sum(x => x[0]);

            var totalVal = contests.Sum(x => x[0]);

            return totalVal - (minLosses * 2);
        }

        //Greedy Florist
        public static int getMinimumCost(int k, int[] c) {
            int minCost = int.MaxValue;
            int numFlowers = c.Length;
            int numFriends = k;


            //if we have more (or equal) friends than flowers, we just buy them at original prices
            if(numFriends >= numFlowers)
            {
                minCost = c.Sum();
            } else
            {              
                //Sort array descending
                c = c.OrderByDescending(e => e).ToArray();

                int purchaseLevel = 0;
                minCost = 0;
                int friendCount = 0;

                //greedy algorithm: keep buying the most expensive ones in minimum purchase level until no more flowers to buy
                for (int i = 0; i < numFlowers; i++)
                {
                    minCost = minCost + (c[i] * (purchaseLevel + 1));
                    friendCount ++;

                    if(friendCount == numFriends)
                    {
                        friendCount = 0;
                        purchaseLevel++;
                    }
                }

            }

            return minCost;
        }


        #endregion


    }
}
