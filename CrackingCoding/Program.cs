using CrackingCoding.Data_Structures;
using System;
using System.Diagnostics;

namespace CrackingCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            //Questions q = new Questions();
            //Console.WriteLine("Type your testString");
            //String testString = Console.ReadLine();
            //Console.WriteLine("Q1 - determine if a string has all unique characters");
            //Console.WriteLine(q.HasUniqueChars(testString));
            //Console.WriteLine("Q2 - reverse string");
            //Console.WriteLine(q.Reverse(testString));
            //Console.WriteLine("Q3 - remove duplicate chars");
            //Console.WriteLine(q.RemoveDuplicateChars(testString));
            //Console.ReadLine();
            //int[] expenditure = {2, 3, 4, 2, 3, 6, 8, 4, 5};
            //string s1 = "HARRY";
            //string s2 = "SALLY";
            //Console.WriteLine(Hackerrank.commonChild(s1,s2));

            //int[] array = { 4, 2, 3, 1, 7, 6};
            //Node root = Node.treeFromArray(array);
            //root.printTree(root,TreeOrder.postOrder);
            //string test = "([[)";
            //Console.WriteLine(StacksAndQueues.isBalanced(test));

            //Console.WriteLine(Recursion.stepPerms(5));

            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //long i = Recursion.Fibonacci](20); // 20 invocations
            //long j = Recursion.FibMemoized(30); // 10 invocations
            //long k = Recursion.FibMemoized(40); // 10 invocations
            //stopWatch.Stop();

            //Console.WriteLine(i);
            //Console.WriteLine(j);
            //Console.WriteLine(k);

            //// Get the elapsed time as a TimeSpan value.
            //TimeSpan ts = stopWatch.Elapsed;

            //// Format and display the TimeSpan value.
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime);


            //stopWatch = new Stopwatch();
            //stopWatch.Start();
            //i = Recursion.FibonacciRecursion(20); // 20 invocations
            //j = Recursion.FibonacciRecursion(30); // 30 invocations
            //k = Recursion.FibonacciRecursion(40); // 40 invocations
            //stopWatch.Stop();

            //Console.WriteLine(i);
            //Console.WriteLine(j);
            //Console.WriteLine(k);


            //// Get the elapsed time as a TimeSpan value.
            //ts = stopWatch.Elapsed;

            //// Format and display the TimeSpan value.
            //elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime);




            string[] array = new string[10];
            array[0] = "+-++++++++";
            array[1] = "+-++++++++";
            array[2] = "+-------++";
            array[3] = "+-++++++++";
            array[4] = "+-++++++++";
            array[5] = "+------+++";
            array[6] = "+-+++-++++";
            array[7] = "+++++-++++";
            array[8] = "+++++-++++";
            array[9] = "++++++++++";

            string words = "AGRA;NORWAY;ENGLAND;GWALIOR";


            Console.WriteLine(Recursion.crosswordPuzzle(array,words));
            Console.ReadLine();

        }
    }




}
