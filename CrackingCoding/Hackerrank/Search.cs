using System;
using System.Collections.Generic;
using System.Text;
using static CrackingCoding.Trees;

namespace CrackingCoding
{
    public static class Search
    {
        #region Search
        //Hash Tables: Ice Cream Parlor
        public static void whatFlavors(int[] cost, int money) {
            //Build a dict to keep costs as keys and corresponding indexes as values
            Dictionary<int,int> dictCostsAndIndexes = new Dictionary<int, int>();

            int currentCost;

            //Iterate thru the costes
            for (int i = 0; i < cost.Length; i++)
            {
                currentCost = cost[i];

                //If there's a index, different from current index, corresponding to (money - current) cost...
                //... This indexCost+currentCost = money! We found our solution
                int index;
                if (dictCostsAndIndexes.TryGetValue(money - currentCost, out index) && index != i)
                {
                    //Ice cream id's start at index 1, that's why we print i+1 index+1

                    if(index < i) {
                        Console.WriteLine(string.Format("{0} {1}", (index + 1), (i + 1)));
                    } else
                    {
                        Console.WriteLine(string.Format("{0} {1}", (i + 1), (index + 1)));
                    }
                    return;
                }
                else
                {
                    //If there's not a index corresponding to (money - current) cost, we add the current cost and it's index to our dict
                    dictCostsAndIndexes[currentCost] = i;
                }
            }
        }

        static void whatFlavorsBruteForce(int[] cost, int money) {
            for (int i = 0; i < cost.Length; i++)
            {
                for (int j = i + 1; j < cost.Length; j++)
                {
                    if (cost[i] + cost[j] == money)
                    {
                        if(j < i) {
                            Console.WriteLine(string.Format("{0} {1}", (j + 1), (i + 1)));
                        } else
                        {
                            Console.WriteLine(string.Format("{0} {1}", (i + 1), (j + 1)));
                        }
                        return;
                    }
                }
            }
            return;
        }

        //Swap Nodes
        public static int[][] swapNodes(int[][] indexes, int[] queries) {
            int numOfNodes = indexes.Length;
            int numOfQueries = queries.Length;
            int[][] result = new int[numOfQueries][];
            
            //Root is always 1 and has 1 height
            Node root = new Node(1);
            root.height = 1;
            
            //Create a queue, starting as current root, to visit the tree            
            Node n = root;
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(n); //put node on queue

            int i = 0; // iterate thru all nodes;
            while (i < numOfNodes) {
                n = nodes.Dequeue(); //take the current node
                //input always has 2 values, left/right. -1 indicates null node
                int leftData = indexes[i][0]; 
                int rightData = indexes[i][1];
                
                //if left node not null, create node and assign as left children of current node
                if(leftData > 0)
                {
                    Node tmpL = new Node(leftData);
                    tmpL.height = n.height + 1;
                    n.left = tmpL;
                }

                //if right node not null, create node and assign as right children of current node
                if(rightData > 0)
                {
                    Node tmpR = new Node(rightData);
                    tmpR.height = n.height + 1;
                    n.right = tmpR;
                }

                //enqueue children to visit, if children exists
                if (n.left != null && n.left.data > 0) 
                    nodes.Enqueue(n.left);
                if (n.right != null && n.right.data > 0) 
                    nodes.Enqueue(n.right);

                i++;
            }


            //our tree is ready! Now we iterate thru queries and swap if level is multiple of k (level%k=0)
            for (int j = 0; j < numOfQueries; j++) {
                swapChildren(root, 1, queries[j]);
                List<int> res = new List<int>(); //stores each inOrderStransversal swap
                inOrderTransversalSwap(root, res); //visits all nodes from root
                result[j] = res.ToArray(); //1 result for each query
            }


            return result; //return n results, where n is numOfQueries
        }

        static void inOrderTransversalSwap(Node n, List<int> ret)
        {
            //inOrder = left->root->right
            if(n != null)
            {
                inOrderTransversalSwap(n.left, ret);
                visitSwap(n, ret);
                inOrderTransversalSwap(n.right, ret);
            }
        }

        static void visitSwap(Node n, List<int> ret)
        {
            if (n.data > 0) // 1<=n<=1024
            {
                ret.Add(n.data);
            }
            
        }

        static void swapChildren(Node n, int height, int k)
        {
            //if leaf, nothing to do
            if (n == null) {
                return ;
            }

            //Call swap on left node
            swapChildren(n.left, height + 1, k);
            
            //Call swap on right node
            swapChildren(n.right, height + 1, k);

            //If height is multiple of k, do a swap of nodes
            if (height >=k && height % k == 0 ) {
                Node tmp = n.left;
                n.left = n.right;
                n.right = tmp;
            }
        }


        #endregion
    }
}
