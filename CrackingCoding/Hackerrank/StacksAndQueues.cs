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

        public static long[] riddle(long[] arr) {

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
