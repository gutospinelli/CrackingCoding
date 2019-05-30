using CrackingCoding.Data_Structures;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using static CrackingCoding.Hackerrank;
using System.Linq;

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


            //string[] array = new string[10];
            //array[0] = "+-++++++++";
            //array[1] = "+-++++++++";
            //array[2] = "+-------++";
            //array[3] = "+-++++++++";
            //array[4] = "+-++++++++";
            //array[5] = "+------+++";
            //array[6] = "+-+++-++++";
            //array[7] = "+++++-++++";
            //array[8] = "+++++-++++";
            //array[9] = "++++++++++";

            //string words = "AGRA;NORWAY;ENGLAND;GWALIOR";


            //Console.WriteLine(Recursion.crosswordPuzzle(array,words));


            //Input: 5, 2, 4, 1, 5
            //Answer: 1
            //EarliestEvent events = new EarliestEvent();
            //events.VisitEvent(5);
            //events.VisitEvent(2);
            //events.VisitEvent(4);
            //events.VisitEvent(1);
            //events.VisitEvent(5);
            //Console.WriteLine("Earliest Visitor: " + events.EarliestVisitor());


            //Cylinder c1 = new Cylinder(8);
            //Cylinder c2 = new Cylinder(7);
            //Cylinder c3 = new Cylinder(6);
            //Cylinder c4 = new Cylinder(5);
            //Cylinder c5 = new Cylinder(4);
            //Cylinder c6 = new Cylinder(3);

            //List<ICylinder> list = new List<ICylinder>();
            //list.Add(c1);
            //list.Add(c2);
            //list.Add(c3);
            //list.Add(c4);
            //list.Add(c5);
            //list.Add(c6);

            //var result = SplitInStacks(list,3);
            //Console.WriteLine("Shelves Balanced:");
            //printShelves(result);
            //Console.ReadLine();

            int[] arr = { 4,3,17,11,2,4,132,271,11,3,2,272,127,206,88,18,131,113,132,88,20,3,214,5,15,11,2,9,102,2,206,14,254,90,3,131,154,2,215,9,20,293,127,20,180,272,6,112,11,100,201,219,157,271,140,2,56,294,287,261,268,29,14,141,129,128,213,243,180,271,122,132,98,15,7,89,169,161,218,290,294,298,200,208,249,60,3,140,132,149 };
            Array.Sort(arr);

            HashSet<int> hashset = new HashSet<int>(arr);

            int[] b = arr.Distinct().ToArray();
            foreach (int i in b)
                Console.Write(i + ",");
            Console.ReadLine();
        }
    }




}
