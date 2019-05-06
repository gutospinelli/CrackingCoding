using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace CrackingCoding
{
    class Questions
    {
        //q1 - Considering UPPER AND LOWER case chars as equals
        //Space complexity - O(n)
        //Time complexity - O(n^2) - two chained fors
        public bool HasUniqueChars(string str)
        {
            var strArray = str.ToLower().ToCharArray();
            for (int i = 0; i<str.Length-1 ; i++) {
                for (int j = i+1; j<str.Length; j++) {
                    if (strArray[i] == strArray[j]) return false;
                }
            }
            return true;
        }

        //q2 - Reverse a string
        //Space complexity O(n) -> 2n (original and reversed arrays)
        //Time complexity O(n) -> just one iteraction
        public string Reverse(string original) {
            var ret = new char[original.Length];
            var originalArray = original.ToCharArray();
            int j = 0;
            for (int i = original.Length -1 ; i>=0; i--) {
                ret[j] = originalArray[i];
                j++;
            }
            return new string(ret);
        }

        public string RemoveDuplicateChars(string str)
        {
            if (str.Length < 2) return str;
            var strArray = str.ToLower().ToCharArray();
            String retorno = String.Empty;
            
            for (int i = 0; i< str.Length - 1; i++)
            {
                bool append = true;
                for (int j = i+1; j < str.Length; j++)
                {
                    if (strArray[i] == strArray[j])
                    {
                        append = false;
                        break;
                    }
                    
                }

                if (append)
                {
                    retorno += strArray[i];
                }
            }

            retorno += strArray[str.Length - 1];
            return retorno;
        }

        

    }
}
