using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCoding
{
    public class GeeksForGeeks
    {
        public int[] nextGreaterElement(int[] array)
        {
            //The Next greater Element for an element x is the first greater element on the right side of x in array.
            //Elements for which no greater element exist, consider next greater element as -1.
            int[] ret = new int[array.Length];

            //initialize default value as -1
            for (int index = 0; index < ret.Length; index++)
            {
                ret[index] = -1;
            }

            for(int i = 0; i<array.Length; i++)
            {
                for(int j = i+1; j<array.Length;j++)
                {
                    if(array[j] > array[i])
                    {
                        ret[i] = j;
                        break;
                    }
                }
            }


            return ret;
        }
    }
}
