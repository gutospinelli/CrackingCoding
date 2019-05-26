using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CrackingCoding
{
    public static class Recursion
    {
        #region Recursion and Backtracking

        //Fibonacci
        public static int Fibonacci(int n) {
            int NumMinusTwo;
            int NumMinusOne = 0;
            int Num = 1;

            for (int i = 1; i < n ; i++) {

                NumMinusTwo = NumMinusOne;

                NumMinusOne = Num;

                Num = NumMinusTwo + NumMinusOne;

            }
            return Num;
        }

        public static int FibonacciRecursion(int n) {
            //Error Cases
            if (n < 0)
                return -1; //Error!
            //base cases
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            return (FibonacciRecursion(n-1) + FibonacciRecursion(n-2));

        }

        [Memoized]
        public static long FibMemoized(long n)
        {
            if (n == 0L)
                return 0L;
            if (n == 1L)
                return 1L;
            return FibMemoized(n - 1) + FibMemoized(n - 2);
        }

        //Recursion: Davis' Staircase
        static int[] cache = new int[36]; //Problem constraint
        public static int stepPermsCacheArray(int n) {
            if(n < 1)
                return -1; //Error case

            //Base cases
            if(n == 1)
                return 1;

            if(n == 2)
                return 2;

            if(n == 3)
                return 4;

            cache[0] = 1;
            cache[1] = 2;
            cache[2] = 4;

            //Recursion cases
            for(int i = 3; i < n; i++)
            {
                cache[i] = cache[i-1] + cache[i-2] + cache[i-3];
            }
                        
            return cache[n-1]; //i.e: array[35] will contain value for n = 36, since arrays are 0 indexed    
        }

        public static int stepPerms(int n) {
            if(n < 1)
                return -1; //Error case

            Dictionary<int,int> cache = new Dictionary<int, int>();
            cache[1] = 1;
            cache[2] = 2;
            cache[3] = 4;

            //Recursion cases
            if(!cache.ContainsKey(n))
            {
                int tmp = GetCache(n-1) + GetCache(n-2) + GetCache(n-3);
                cache.Add(n,tmp);
            }


            int ret = cache[n];
            //We will not overflow int since stepPerms 36 (max constraint) = 2082876103 and int goes til (2,147,483,648 = 2^31)
            //int retInt = (int) (ret % 10000000007); //modulo to not overflow int
                        
            return ret;
        }

        public static int GetCache(int n)
        {
            if(n < 1)
                return -1; //Error case

            //Base cases
            if(n == 1)
                return 1;

            if(n == 2)
                return 2;

            if(n == 3)
                return 4;

            return GetCache(n-1) + GetCache(n-2) + GetCache(n-3);

        }

        public static int getPermsBasic(int n)
        {
            if(n < 1)
                return -1; //Error case

            //Base cases
            if(n == 1)
                return 1;

            if(n == 2)
                return 2;

            if(n == 3)
                return 4;

            //Recursion cases
            long ret = stepPerms(n-1) + stepPerms(n-2) + stepPerms(n-3);
            int retInt = (int) (ret % 10000000007); //modulo to not overflow int
                        
            return retInt;
        }

        //Crossword Puzzle
        public static string[] crosswordPuzzle(string[] crossword, string words) {
            //idea: recursively checks if we can put the word on horizontal or vertical
            string[] wordArray = words.Split(';');
            int matrixSize = 10;
            char[][] crossWordMatrix = new char[matrixSize][];

            for (int i = 0; i < matrixSize; i++)
            {
                char[] tmp = crossword[i].ToCharArray();
                crossWordMatrix[i] = tmp;
            }

            var solution = solveCrosswordPuzzle(crossWordMatrix, wordArray, 0, matrixSize);

            string[] ret = new string[matrixSize];

            StringBuilder sb2 = new StringBuilder();

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    sb2.Append(solution[row][col]);
                }
                ret[row] = sb2.ToString();
                sb2.Clear();
            }
            printCrossWord(ret, 10);

            return ret;

        }

        static char[][] solveCrosswordPuzzle(char[][] crossword, string[] words, int index, int matrixSize)
        {
            if(index < words.Length)
            {
                string currentWord = words[index]; 
                int max = matrixSize - currentWord.Length;

                //check if we can put word vertically
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j <= max; j++)
                    {
                        char[][] tmp = checkVertical(j, i, crossword, currentWord);

                        if (tmp[0][0] != '$')
                        {
                            solveCrosswordPuzzle(tmp, words, index + 1, matrixSize);
                        }
                        else
                        {
                            tmp[0][0] = '+';
                        }
                    }
                }

                //check if we can put word horizontally
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j <= max; j++)
                    {
                        var tmp = checkHorizontal(i, j, crossword, currentWord);

                        if (tmp[0][0] != '$')
                        {
                            solveCrosswordPuzzle(tmp, words, index + 1, matrixSize);
                        }
                        else
                        {
                            tmp[0][0] = '+';
                        }
                    }
                }

            } else
            {
                //solved!
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        Console.Write(crossword[i][j]);
                    }
                    Console.WriteLine();
                }
                return crossword;

            }

            return crossword;

        }

        //prints the crossword on console
        public static void printCrossWord(string[] crossword, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(crossword[i][j]);
                }
                Console.WriteLine();
            }
        }
        //check if it`s possible to put one word in a horizontal position
        static char[][] checkHorizontal(int rowPos, int colPos, char[][] crossword, string word) {
            int size = word.Length;

            for (int i = 0; i < size; i++)
            {
                //put on horizontal => fixed row and variable col
                if( crossword[rowPos][colPos + i] == '-' ||
                    crossword[rowPos][colPos + i] == word[i] )
                {
                    crossword[rowPos][colPos + i] = word[i];
                } else {
                    //Marker to show we can't place this word horizontally
                    crossword[0][0] = '$';
                    return crossword;
                }
            }

            return crossword;
        }
        //check if it`s possible to put one word in a vertical position
        static char[][] checkVertical(int rowPos, int colPos, char[][] crossword, string word)
        {
            int size = word.Length;

            for (int i = 0; i < size; i++)
            {
                if (crossword[rowPos + i][colPos] == '-' ||
                    crossword[rowPos + i][colPos] == word[i])
                {
                    crossword[rowPos + i][colPos] = word[i];
                }
                else
                {
                    //Marker to show we can't place this word horizontally
                    crossword[0][0] = '$';
                    return crossword;
                }
            }

            return crossword;
        }




        #endregion
    }
}
