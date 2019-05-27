using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static CrackingCoding.Trees;

namespace CrackingCoding
{
    public class Hackerrank
    {
        //Each Solution now resides inside it's group Class on Hackerrank directory


        //CodingGame
        public interface ICylinder
        {
            //Guid Identifier { get; }
            double Size { get; }
        }

        public class Cylinder : ICylinder
        {
            public Cylinder(int size)
            {
                this.Size = size;
            }

            public double Size;

            double ICylinder.Size => this.Size;

        }

        public static IEnumerable<IEnumerable<ICylinder>> SplitInStacks(IEnumerable<ICylinder> cylinders, int nbShelves)
        {
            //order cylinders from biggest to smallest
            var cylBigToSmall = Enumerable.OrderByDescending(cylinders.ToList(), c => c.Size);

            //creates an array of cylinder stackers to return (size of array = number of shelves)
            List<ICylinder>[] shelves = new List<ICylinder>[nbShelves];

            //keep adding from bigest to smallest cylinder to shelves
            //If we reach last shelve, return to the first one until
            //we place all cylinders on shelves
            int i = 0;
            foreach (ICylinder cylinder in cylBigToSmall)
            {
                //If no shelves created, create shelve
                if(shelves[i] == null)
                {
                    shelves[i] = new List<ICylinder>();
                    shelves[i].Add(cylinder);
                } else //We already have nbShelves number of shelves created. Try to find the best one to put this new Cylinder
                {
                    int minIndex = 0;
                    double minValue = double.MaxValue;
                    
                    for (int j = 0; j<shelves.Length;j++)
                    {
                        double minSize = shelves[j].Sum(x => x.Size); //Find the shelve with minimum Sum to put cylinder
                        if (minSize < minValue)
                        {
                            minIndex = j;
                            minValue = minSize;
                        }
                    }
                    shelves[minIndex].Add(cylinder);
                }
                
                i++;
                if (i == nbShelves) //To not create more shelves than necessary
                {
                    i = 0;
                }
            }

            return shelves; //Shelves balanced!
        }

        public static void printShelves(IEnumerable<IEnumerable<ICylinder>> cylOnShelves)
        {
            foreach (var cylList in cylOnShelves)
            {
                foreach (var cyl in cylList)
                {
                    Console.Write(cyl.Size);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        
    }

    //ID of Earliest Visited Event
    public class EarliestEvent
    {
        //Input: 5, 2, 4, 1, 5
        //Answer: 1 (since 5 repeated itself on 2nd visit)
        Stack<int> earlyestVisitorStack = new Stack<int>();
        Dictionary<int,int> dictVisits = new Dictionary<int, int>();

        public void VisitEvent(int userId)
        {
            if(dictVisits.ContainsKey(userId))
            {
                var numVisitsBefore = dictVisits[userId];
                dictVisits[userId] = numVisitsBefore++;
                if(earlyestVisitorStack.Peek() == userId)
                {
                    //takes out of stack. It's not earliest anymore
                    earlyestVisitorStack.Pop();
                }
            } else
            {
                //1st time visit! Updates earliestVisitor
                dictVisits.Add(userId, 1);
                earlyestVisitorStack.Push(userId);
            }
        }

        //returns Earliest visitor that visited once the site
        public int EarliestVisitor()
        {
            //Empty stack, no earliestVisitors
            if(earlyestVisitorStack.Count == 0)
                return -1;

            return earlyestVisitorStack.Peek();
        }

        
    }
}
