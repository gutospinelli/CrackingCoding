using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCoding
{
    public static class StacksAndQueues
    {
        #region Stacks and Queues 
        //Balanced Brackets
        public static string isBalanced(string s)
        {
            bool balanced = true;
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '[' || c == '{' || c == '(')
                {
                    stack.Push(c);
                } else
                {
                    char tmp;
                    try
                    {
                        tmp = stack.Pop();
                    }
                    catch (Exception)
                    {
                        balanced = false;
                        break;
                    }


                    if (
                        (c == ')' && tmp != '(') ||
                        (c == ']' && tmp != '[') ||
                        (c == '}' && tmp != '{') )
                    {
                        balanced = false;
                        break;
                    }
                }

            }

            if (stack.Count != 0)
            {
                balanced = false;
            }

            return balanced ? "YES" : "NO";
        }

        //Queues: A tale of Two Stacks
        //Solution: Class Data_Structures.QueueTwoStacks

        //Largest Rectangle
        public static long largestRectangle(int[] h) {
            long maxArea = long.MinValue;
            int minPos = 0; 
            int maxPos = h.Length - 1;
            


            for (int i = 0; i < h.Length - 1; i++)
            {
                long currValue = h[i];
                int left = i-1;
                int right = i+1;
                int multipliter = 1;

                while(left >= minPos)
                {
                    if(h[left] >= currValue) {
                        multipliter++;
                        left--;
                    } else
                    {
                        break;
                    }
                }

                while(right <= maxPos)
                {
                    if(h[right] >= currValue)
                    {
                        multipliter++;
                        right++;
                    } else
                    {
                        break;
                    }
                }

                long tmpAreaI = currValue * multipliter;
                if(tmpAreaI >= maxArea)
                {
                    maxArea = tmpAreaI;
                }              
                
            }

            return maxArea;


        }

        //Min Max Riddle

        public static long[] riddle(long[] arr)
        {
            //Size of the array
            int n = arr.Length;

            // Used to find previous and next smaller  
            Stack<int> s = new Stack<int>(); 
  
            // Arrays to store previous  
            // and next smaller  
            long[] left = new long[n + 1]; 
            long[] right = new long[n + 1]; 
  
            // Initialize elements of left[]  
            // and right[]  
            for (long i = 0; i < n; i++) 
            { 
                left[i] = -1; 
                right[i] = n; 
            } 
  
            // Fill elements of left[] using logic discussed on  
            // https://www.geeksforgeeks.org/next-greater-element/  
            for (int i = 0; i < n; i++) 
            { 
                while (s.Count > 0 &&  
                       arr[s.Peek()] >= arr[i]) 
                { 
                    s.Pop(); 
                } 
  
                if (s.Count > 0) 
                { 
                    left[i] = s.Peek(); 
                } 
  
                s.Push(i); 
            } 
  
            // Empty the stack as stack is going  
            // to be used for right[]  
            while (s.Count > 0) 
            { 
                s.Pop(); 
            } 
  
            // Fill elements of right[] using 
            // same logic  
            for (int i = n - 1 ; i >= 0 ; i--) 
            { 
                while (s.Count > 0 &&  
                       arr[s.Peek()] >= arr[i]) 
                { 
                    s.Pop(); 
                } 
  
                if (s.Count > 0) 
                { 
                    right[i] = s.Peek(); 
                } 
  
                s.Push(i); 
            } 
  
            // Create and initialize answer array  
            long[] ans = new long[n + 1]; 
            for (int i = 0; i <= n; i++) 
            { 
                ans[i] = 0; 
            } 
  
            // Fill answer array by comparing 
            // minimums of all lengths computed  
            // using left[] and right[]  
            for (int i = 0; i < n; i++) 
            { 
                // length of the interval  
                long len = right[i] - left[i] - 1; 
  
                // arr[i] is a possible answer for  
                // this length 'len' interval, check x 
                // if arr[i] is more than max for 'len'  
                ans[len] = Math.Max(ans[len], arr[i]); 
            } 
  
            // Some entries in ans[] may not be  
            // filled yet. Fill them by taking  
            // values from right side of ans[]  
            for (int i = n - 1; i >= 1; i--) 
            { 
                ans[i] = Math.Max(ans[i], ans[i + 1]); 
            }

            // Print the result
            long[] ret = new long[n]; 
            for (int i = 1; i <= n; i++)
            {
                //Console.Write(ans[i] + " ");
                ret[i-1] = ans[i];
            }
            return ret;
        } 

        public static long[] riddleNaive(long[] arr) {

            long[] ret = new long[arr.Length];
            int retIndex = 0;
		    // Consider all windows of different  
            // sizes starting from size 1 
            for (int k = 1; k <= arr.Length; k++) 
            { 
              
                // Initialize max of min for  
                // current window size k 
                long maxOfMin = long.MinValue; 
      
                // Traverse through all windows 
                // of current size k 
                for (int i = 0; i <= arr.Length - k; i++) 
                { 
                  
                    // Find minimum of current window 
                    long min = arr[i]; 
                    for (int j = 1; j < k; j++) 
                    { 
                        if (arr[i + j] < min) 
                            min = arr[i + j]; 
                    } 
      
                    // Update maxOfMin if required 
                    if (min > maxOfMin) 
                        maxOfMin = min; 
                } 
      
                // Print max of min for current window size 
                //Console.Write(maxOfMin + " "); 
                ret[retIndex] = maxOfMin;
                retIndex++;

            } 

            return ret;
	    }

        
        #endregion
    }
}
