using System;
using System.Collections.Generic;
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
        
        #endregion
    }
}
