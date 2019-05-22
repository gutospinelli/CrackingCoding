using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCoding
{
    public static class Arrays
    {
        #region Arrays
        //2D Array - DS
        public static int hourglassSum(int[][] arr) {
            int currentHourglass = 0;
            int maxHourglass = -9 * 7; //We start maximum as the minimum hourglass possible

            for (int i = 0; i < 4; i++) //To mount and hourglass we go just to the 4th pos of i
            {
                for (int j = 0; j < 4; j++) //The same above applies to j
                {
                    //Mount Hourglass
                    currentHourglass = 
                        arr[i][j]   + arr[i][j+1]   + arr[i][j+2] + 
                                      arr[i+1][j+1] +
                        arr[i+2][j] + arr[i+2][j+1] + arr[i+2][j+2];
                    //update max if current is bigger
                    if(currentHourglass > maxHourglass)
                    {
                        maxHourglass = currentHourglass;
                    }
                }
            }

            return maxHourglass;
        }

        // Left Rotation
        public static int[] rotLeft(int[] a, int d) {
            int[] rotatedArray = new int[a.Length]; //array that will receive rotated ints
            
            for (int i = 0; i < a.Length ; i++) { //foreach item in array, execute d left rotations and put in right position
                int currentItem = a[i];
                int position = 0;

                if (i - d >= 0) //if result position after rotation is >0 we know where to put it on array
                {
                    position = i - d;
                    
                } else //however, if the above result is negative, we should go |i-d| ==> d-i spaces back from last position (size)
                {
                    position = a.Length - (d - i);
                }

                rotatedArray[position] = currentItem;
            }

            return rotatedArray;
        }

        //New Year Chaos
        //Received timeout on hackerhank
        public static void minimumBribes(int[] q) {
        //idea: no person can be more than 2 pos in front of its value/sticker
        //if a person is more than 2 pos in front, stop and print "too chaotic"
        //if a person is in fronf of it's value/sticker count the # of bribes: 1 or 2
        //if a person is behind value pos, ignore. This person has been bribed

            int swaps = 0;
            bool chaotic = false;

            for (int i = 0; i < q.Length; i++)
            {
                //person value/sticker = q[i]
                //person position = i+1 (arrays have 0 index)
                if (i + 1 < q[i]) { //a bribe has occured!
                    if (q[i] - i + 1 > 2) //if more than 2 pos ahead... cheater!
                    {
                        chaotic = true;
                        break;
                    }
                    
                }
            }

            if (!chaotic)
            {
                //bublesort and count # of swaps
                int temp;
                for (int j = 0; j <= q.Length - 2; j++) {
                    for (int i = 0; i <= q.Length - 2; i++) {
                       if (q[i] > q[i + 1]) {
                          temp= q[i + 1];
                          q[i + 1] = q[i];
                          q[i] = temp;
                          swaps += 1;
                    
                       }
                    }
                }
            }
            

            if (chaotic)
            {
                Console.WriteLine("Too chaotic");
            } else
            {
                Console.WriteLine(swaps);
            }

        }
        public static void minimumBribes2(int[] q) {

            int bribes = 0 ; 

            //we compare always 3 values since no one can go more than 2 steps further/ahead
            int mid = int.MaxValue;
            int max =  int.MaxValue;
            int min =  int.MaxValue;

            for(int i=q.Length-1 ; i >= 0 ; i--){ //we start backwards
                if((q[i]-i) > 3 ) { //if ((value - (pos-1)) > 3) more than 2 positions ahead. Cheater!
                    Console.WriteLine("Too chaotic");
                    return;
                }
                else{
                    if(q[i] > max){ //if value > max, not possible!
                         Console.WriteLine("Too chaotic");
                         return;
                    }
                    else if(q[i] > mid){  //if value > mid, moved 2 pos
                        bribes=bribes+2;
                    }
                    else if(q[i] > min){
                        bribes=bribes+1; //if value > min, moved just 1 pos
                    }

                    if(q[i]<min){ //if value < min, update max, mid and min
                        max=mid;
                        mid=min;
                        min = q[i];
                    }
                    else if(q[i]<mid){ //if value < mid, update max and mid (we know it's > min, so it stays the min)
                        max=mid;
                        mid = q[i];
                    }
                    else if(q[i]<max){ //if value < max, update only max (we know it's > min and mid)
                        max = q[i];
                    }
                }
            }
            Console.WriteLine(bribes);
        }

        //Minimum Swaps 2
        public static int minimumSwaps(int[] arr) {       
            int n = arr.Length - 1;
            int minSwaps = 0;
            for (int i = 0; i < n; i++) {
                if (i < arr[i] - 1) {
                    swap(arr, i, Math.Min(n, arr[i] - 1));
                    minSwaps++;
                    i--;
                }
            }
            return minSwaps;
        }
        private static void swap(int[] array, int i, int j) {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        //Array Manipulation
        public static long arrayManipulation(int n, int[][] queries) {
        //idea: go adding values to the array and updating max if necessary. Return max
            long max = long.MinValue;
            int a, b;
            long k; 
            long[] arr = new long[n];

            for (int i = 0; i < queries.GetLength(0); i++)  //Dimension 0 contains number of lines
            {
                    //each queries[i] contains three integers, a, b, and k.
                    a = queries[i][0];
                    b = queries[i][1];
                    k = queries[i][2];

                    while (a<=b)
                    {
                        //we always update at index a-1 because this arrays are 1-indexed.
                        arr[a-1] = arr[a-1] + k;
                        if (arr[a-1] > max) //if a new max found
                        {
                            max = arr[a-1]; //update max
                        }
                        a++;
                    }
            }
            return max;
        }

        public static long arrayManipulationSlopeSolution(int n, int[][] queries) {
        //idea: instead of adding value to array, we control where it started do climb (a) and where it stopped (b+1). A.K.A Slope increase
            long max = 0;
            long tempMax = 0;
            int a, b;
            long k; 
            long[] arr = new long[n+1]; //to make 1-indexed array possible

            for (int i = 0; i < queries.GetLength(0); i++)  //Dimension 0 contains number of lines
            {
                    //each queries[i] contains a, b, and k.
                    a = queries[i][0];
                    b = queries[i][1];
                    k = queries[i][2];

                    arr[a] = arr[a] + k; //slope starts at A pos, so we ADD there
                    if (b+1 <= n) //if in next position after the slope stops B+1 we do not go out of bounds...
                    {
                        //we mark that the slope stopped by SUBTRACTING at b+1 
                        arr[b+1] = arr[b+1] - k; 
                    }
            }
            
            //To find the max value we just add the POSITIVE slopes that contributed to max
            for(int i=1; i<=n; i++)
            {
                tempMax += arr[i]; 
                if(tempMax > max) max = tempMax;
            }
            return max;
        }

        #endregion
    }
}
