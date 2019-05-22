using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCoding
{
    public static class Sorting
    {
        #region Sorting
        //Sorting: Bubble Sort
        public static void countSwaps(int[] a) {
            int numSwaps = 0;
            bool isSorted = false;
            bool foundLastElement = false;
            int lastElement = a[a.Length-1];
            int lastUnsortedPosition = a.Length-1;

            while(!isSorted) {
                //We assume the array is sorted
                isSorted = true;
                for(int i = 0; i < lastUnsortedPosition; i++)
                {
                    //If element at pos i is bigger than i+1, we need to swap, so we say not sorted yet
                    if(a[i] > a[i+1])
                    {
                        swap(a,i,i+1);
                        numSwaps++;
                        isSorted = false;
                    }
                }
                
                //On the 1st pass of bubbleSort, we keep our last element
                if(!foundLastElement)
                {
                    lastElement = a[lastUnsortedPosition];
                    foundLastElement = true;
                }
                
                //We improve a litte bubbleSort efficience by shrinking the next pass on the array
                //since we know the last element is already the biggest one, we do not need to pass thru it again
                lastUnsortedPosition--;
            }

            int firstElement = a[0]; 

            Console.WriteLine("Array is sorted in {0} swaps.",numSwaps) ;
            Console.WriteLine("First Element: {0}", firstElement);
            Console.WriteLine("Last Element: {0}",lastElement);
        }

        //Mark & Toys
        public static int maximumToys(int[] prices, int k) {
            int bought = 0;
            int spent = 0;
            var toyPrices = prices;
            Array.Sort(toyPrices);

            foreach (var toyprice in toyPrices)   
            {
                //try to buy a toy
                spent += toyprice;
                //if he has the bucks to boy
                if(spent < k) {
                    bought++;
                } else
                {
                    //he has no more money, so we don't need to iterate anymore
                    break;
                }
                    
            }

            return bought;
        }

        private static void swap(int[] array, int i, int j) {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        //Sorting Comparator - Java 8
        /*
        class Checker implements Comparator<Player> {
  	        // complete this method
	        public int compare(Player a, Player b) {
                if (a.score == b.score) {
                    return a.name.compareTo(b.name);
                } else {
                    return b.score - a.score;
                }
            }
        }
        */

        //Fraudulent Activity Notifications
        public static int activityNotificationsBruteForce(int[] expenditure, int d) {
            int numberOfNotifications = 0;
            int[] trailingArray = new int[d];

            for (int i = d; i < expenditure.Length; i++)
            {
                //get trailing array of size d
                Array.Copy(expenditure,i-d,trailingArray,0,d);
                Array.Sort(trailingArray);
                
                //if day's expendure greater or equal 2 times median, we send a notice
                if (expenditure[i] >= 2 * getMedian(trailingArray,d))
                {
                    numberOfNotifications++;
                }
            }
            return numberOfNotifications;
        }

        public static int activityNotifications(int[] expenditure, int d) {
            int numberOfNotifications = 0;
            int max = expenditure.Max();
            int[] expenditureCount = new int[max+1];

            //Fill number of times each expendure appears
            for (int i = 0; i < d; i++)
            {
                expenditureCount[expenditure[i]] = expenditureCount[expenditure[i]] + 1;
            }

            for (int i = d; i < expenditure.Length; i++)
            {               
                //if day's expendure greater or equal 2 times median, we send a notice
                if (expenditure[i] >= 2 * getMedianFromCount(expenditureCount,d))
                {
                    numberOfNotifications++;
                }

                //Move window
                expenditureCount[expenditure[i]] = expenditureCount[expenditure[i]] + 1;
                expenditureCount[expenditure[i-d]] = expenditureCount[expenditure[i-d]] - 1;
            }
            return numberOfNotifications;
        }

        static decimal getMedian(int[] arr, int d)
        {            
            //is Even
            if(d%2 == 0)
                return Decimal.Divide((arr[d/2] + arr[d/2 - 1]),2);
            else //Odd
                return arr[d/2];
        }

        static decimal getMedianFromCount(int[] arr, int d)
        {
            int medianCount = 0; //how much to count to find the median element
            int currentCount = 0;
            int medianToReturn = 0; //the number at the median position

            if(d % 2 == 0)
                medianCount = d/2;
            else
                medianCount = d/2 + 1;

            for (int i = 0; i < arr.Length; i++)
            {
                currentCount += arr[i];

                if (currentCount >= medianCount)
                {
                    if (medianToReturn > 0)
                    {
                        return (medianToReturn + i) / 2m;
                    }

                    medianToReturn = i;

                    if (d % 2 != 0 || currentCount > medianCount)
                    { 
                        return medianToReturn;
                    }
                }
            }

            return medianToReturn;
        }

        //Counting Inversions
        private static long countInversions(int[] arr) {
            return mergeSort(arr, 0, arr.Length - 1);
        }

        public static long mergeSort(int[] a, int start, int end) {
            if (start == end)
                return 0;

            int mid = (start + end) / 2;
            long inversions = mergeSort(a, start, mid) +
                              mergeSort(a, mid + 1, end) +
                              merge(a, start, end);
            return inversions;
        }

        public static long merge(int[] a, int start, int end) {
            int[] tmp = new int[end - start + 1];
            long inversions = 0;

            int mid = (start + end) / 2;

            int i = start;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= end) {
                if (a[i] > a[j]) {
                    tmp[k++] = a[j++];
                    inversions += mid - i + 1;
                } else {
                    tmp[k++] = a[i++];
                }
            }

            while (i <= mid) {
                tmp[k++] = a[i++];
            }

            while (j <= end) {
                tmp[k++] = a[j++];
            }

            Array.Copy(tmp, 0, a, start, end - start + 1);
            return inversions;
        }

        #endregion
    }
}
