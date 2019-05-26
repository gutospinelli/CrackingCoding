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


        //UbiSoft
        public interface ICylinder
        {
            //Guid Identifier { get; }
            double Size { get; }
        }

        public class Cylinder : ICylinder
        {
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
                if(shelves[i] == null)
                {
                    shelves[i] = new List<ICylinder>();
                }
                shelves[i].Add(cylinder);
                i++;
                if (i == nbShelves)
                {
                    i = 0;
                }
            }

            return shelves;
        }
    }
}
