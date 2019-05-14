using CrackingCoding.Data_Structures;
using System;

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

            int[] array = { 4, 2, 3, 1, 7, 6};
            Node root = Node.treeFromArray(array);
            root.printTree(root,TreeOrder.postOrder);
            Console.ReadLine();

        }
    }




}
