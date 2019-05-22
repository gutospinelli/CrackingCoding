using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCoding
{
    public static class DictsAndHashmaps
    {
        #region Dictionaries and Hashmaps

        //HashTables: Ransom Note
        public static void checkMagazine(string[] magazine, string[] note) {
            Dictionary<string, int> dMagazine = new Dictionary<string, int>();
            Dictionary<string, int> dNote = new Dictionary<string, int>();
            string canReplicate = "Yes";

            foreach (string s in magazine)
            {
                //we fill magazine dict with words and count number of times it appears
                if(dMagazine.ContainsKey(s))
                {
                    dMagazine[s] = dMagazine[s] + 1;
                } else
                {
                    dMagazine.Add(s, 1);
                }
                
            }

            foreach (string s in note)
            {
                //we do the same for note dict.
                if(dNote.ContainsKey(s))
                {
                    dNote[s] = dNote[s] + 1;
                } else
                {
                    dNote.Add(s, 1);
                }
            }

            //if the magazine doesn't have as many words as the note needs... no!
            if (dNote.Count > dMagazine.Count)
            {
                canReplicate = "No";
            }
            else
            {
                foreach (var key in dNote.Keys)
                {
                    if(dMagazine.ContainsKey(key))
                    {
                        //if dNote need more occurencies of a particular word than magazine has, no!
                        if (dNote[key] > dMagazine[key])
                        {
                            canReplicate = "No";
                            break;
                        }    

                    }
                    else
                    {
                        //if one of the words are not found, print no and stops
                        canReplicate = "No";
                        break;
                    }
                }
            }

            Console.WriteLine(canReplicate);

        }
        
        //Two Strings
        public static string twoStrings(string s1, string s2) {
            
            Dictionary<char,int> dict1 = new Dictionary<char, int>();
            Dictionary<char,int> dict2 = new Dictionary<char, int>();

            String containsSub = "NO";

            //THe problem points that a single char counts as a substring. So we can divide strings in dicts of chars and see of at least
            //one of them is present on the other one
            foreach (char c in s1.Trim())
            {
                if(!dict1.ContainsKey(c))
                {
                    dict1.Add(c,1);
                }
            }

            foreach (char c in s2.Trim())
            {
                if(!dict2.ContainsKey(c))
                {
                    dict2.Add(c,1);
                }
            }

            foreach (var key in dict2.Keys)
            {
                if (dict1.ContainsKey(key))
                {
                    containsSub = "YES";
                    break;
                }
            }

            return containsSub;

        }
        
        //Sherlock and Anagrams
        public static int sherlockAndAnagrams(string s) {
            int numberOfAnagrams = 0;
            string subStr;
                     
            Dictionary<string,int> dict = new Dictionary<string, int>();

            for(int i = 0; i < s.Length; i++)
            {
                for (int j = 1; j < s.Length - i + 1; j++)
                {
                    subStr = s.Substring(i,j);
                    char[] chars = subStr.ToCharArray();
                    Array.Sort(chars);
                    subStr = new string (chars);

                    if(dict.ContainsKey(subStr))
                    {
                        numberOfAnagrams = numberOfAnagrams + dict[subStr];
                        dict[subStr] = dict[subStr] + 1;
                    } else
                    {
                        dict.Add(subStr,1);
                    }
                }
            }

            return numberOfAnagrams;

        }

        //Count Triplets
        public static long countTriplets(List<long> arr, long r) {
            long xi; //expected i
            long xj; //Xpected j
            long xk; //Xpected k
            long count = 0;

            arr.Sort();

            for (int i = 0; i < arr.Count; i++)
            {
                xi = arr[i];
                xj = xi * r;
                xk = xj * r;

                for (int j = i+1; j < arr.Count; j++)
                {
                    //if we found the expected j, we try to get k
                    if(arr[j] == xj)
                    {
                        for (int k = j+1; k < arr.Count; k++)
                        {
                            if (arr[k] == xk) //we found xi, xj and xk. Gotcha! Count!
                            {
                                count++;
                            }
                        }
                    }
                }

            }

            return count;

        }

        public static long countTripletsOptimized(List<long> arr, long r) {
            long xi; //expected i
            long xj; //Xpected j
            long xk; //Xpected k
            long count = 0;

            Dictionary<long,long> dict = new Dictionary<long, long>();

            foreach (long l in arr)
            {
                if(dict.ContainsKey(l))
                {
                    dict[l] = dict[l] + 1; //Sum new occurency
                } else
                {
                    dict.Add(l,1); //add 1st occurency
                }
            }

            foreach (var key in dict.Keys)
            {
                xi = key;
                xj = xi * r;
                xk = xj * r;

                //if we find a progression triplet
                if (dict.ContainsKey(xj) && dict.ContainsKey(xk)) 
                {
                    //we count and multiply recurrent occurencies
                    count = count + (dict[xi] * dict[xj] * dict[xk]); 
                }
            }           

            return count;

        }

        public static long countTripletsOptimized2(List<long> arr, long r)         {
            Dictionary<long,long> xj = new Dictionary<long, long>(); //Xpected js
            Dictionary<long,long> xk = new Dictionary<long, long>(); //Xpected ks
            long count = 0;
            //1st triplet indice "i"
            foreach (long key in arr)
            {
                //3rd triplet indice "k"
                if (xk.ContainsKey(key))
                    count += xk[key];
                if (xj.ContainsKey(key))
                    if (xk.ContainsKey(key*r))
                        xk[key*r] += xj[key];
                    else
                        xk[key*r] = xj[key];
                //2nd triplet indice "j" 
                if (xj.ContainsKey(key*r))
                    xj[key*r]++;
                else
                    xj[key*r] = 1;
            }
            return count; 

        }
        
        //Frequency Queries
        public static List<int> freqQuery(List<List<int>> queries) {
            List<int> ret = new List<int>();

            //dict to keep numbers and frequencies
            Dictionary<int,int> dict = new Dictionary<int, int>();

            foreach (List<int> l in queries)
            {
                switch (l[0])
                {   case 1: //Add new or 1
                        if(dict.ContainsKey(l[1]))
                        {
                            dict[l[1]] = dict[l[1]] + 1;
                        } else
                        {
                            dict.Add(l[1], 1); //1st occurence
                        }
                        break;
                    case 2: //Remove 1
                        if(dict.ContainsKey(l[1]))
                        {
                            if(dict[l[1]] > 0)
                            {
                                dict[l[1]] = dict[l[1]] - 1;
                            }
                        }
                        break;
                    case 3: //Check and print
                        if(dict.ContainsValue(l[1]))
                        {
                            ret.Add(1);
                        } else
                        {
                            ret.Add(0);
                        }
                        break;
                    default:
                        break;
                }
            }
            return ret;
        }

        public static List<int> freqQueryIf(List<List<int>> queries) {
            List<int> ret = new List<int>();

            //dict to keep numbers and frequencies
            Dictionary<int,int> dict = new Dictionary<int, int>();

            foreach (List<int> l in queries)
            {
                if(l[0] == 3) //Check and print
                {
                    ret.Add(dict.ContainsValue(l[1])?1:0);
                } 
                else if(l[0] == 2) //Remove 1 if necessary
                {
                    if(dict.ContainsKey(l[1]) && dict[l[1]] > 0)
                            dict[l[1]]--;
                } 
                else
                {
                    if(dict.ContainsKey(l[1]))
                        dict[l[1]]++; //Add++
                    else
                        dict.Add(l[1], 1); //1st occurence
                }
            }
            return ret;
        }

        public static List<int> freqQuery2Dicts(List<List<int>> queries) {
            var returnList = new List<int>();
            var dictionaryFrequency = new Dictionary<int, int>();
            var dictionaryOccurencies = new Dictionary<int, int>();
            bool found;

            foreach (var q in queries)
            {
                found = dictionaryFrequency.TryGetValue(q[1], out int value);

                switch (q[0])
                {
                    case 1:
                        if (found)
                        {
                            dictionaryFrequency[q[1]]++;

                            dictionaryOccurencies[value]--;

                            if (dictionaryOccurencies.ContainsKey(value + 1))
                                dictionaryOccurencies[value + 1]++;
                            else
                                dictionaryOccurencies.Add(value + 1, 1);
                        }
                        else
                        {
                            dictionaryFrequency.Add(q[1], 1);

                            if (dictionaryOccurencies.ContainsKey(1))
                                dictionaryOccurencies[1]++;
                            else
                                dictionaryOccurencies.Add(1, 1);
                        }
                        break;
                    case 2:
                        if (found)
                        {
                            if (value > 0)
                            {
                                dictionaryFrequency[q[1]]--;

                                dictionaryOccurencies[value]--;

                                if (dictionaryOccurencies.ContainsKey(value - 1))
                                    dictionaryOccurencies[value - 1]++;
                                else
                                    dictionaryOccurencies.Add(value - 1, 1);
                            }
                            else
                            {
                                dictionaryFrequency.Remove(q[1]);
                                dictionaryOccurencies[value]--;
                            }
                        }
                        break;
                    case 3:
                        if (dictionaryOccurencies.ContainsKey(q[1]))
                            returnList.Add(1);
                        else
                            returnList.Add(0);
                        break;
                }

                if (found && dictionaryOccurencies[value] == 0)
                    dictionaryOccurencies.Remove(value);
            }

            return returnList;
        }

        #endregion
    }
}
