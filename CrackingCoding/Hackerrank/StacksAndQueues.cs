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
        
        #endregion
    }
}
