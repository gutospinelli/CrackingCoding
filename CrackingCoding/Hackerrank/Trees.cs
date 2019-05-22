using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCoding
{
    public static class Trees
    {
        #region Trees

        public class Node {
            public Node(int data)
            {
                this.data = data;
            }
    	    public int data;
    	    public Node left;
    	    public Node right;
            public int height;

        }

        public class NodeHuffman {
		    public  int frequency; // the frequency of this tree
    	    public  char data;
    	    public  NodeHuffman left, right;
        }
	    
        //Height of a Tree
	    public static int height(Node root) {
      	    int height = 0;

            //Defining our constraints
            if(root == null || root.data < 1 || root.data > 20)
            {
                return -1; //error
            }

            if(root.left == null)
            {
                //Only right
                height = heightHelper(root.right,height);

            } else if (root.right == null)
            {
                //only Left
                height = heightHelper(root.left, height);

            } else
            {
                //Both branches
                int leftH = heightHelper(root.left, height);
                int rightH = heightHelper(root.right, height);
                height =  Math.Max(leftH,rightH);
            }
            
            return height;
        }

        private static int heightHelper(Node node, int currentHeight)
        {
            if(node == null)
            {
                return currentHeight;
            }
            
            if(node.left == null && node.right == null)
            {
                return currentHeight + 1;
            }

            if(node.left == null && node.right != null)
            {
                return heightHelper(node.right, currentHeight + 1);
            }

            if(node.left != null && node.right == null)
            {
                return heightHelper(node.left, currentHeight + 1);
            }

            if(node.left != null && node.right != null)
            {
                int leftH = heightHelper(node.left, currentHeight + 1);
                int rightH = heightHelper(node.right, currentHeight + 1);
                return Math.Max(leftH,rightH);
            }

            return currentHeight + 1;


        }

        //Lowest Common Ancestor
        public static Node lca(Node root, int v1, int v2) {
            //Base
            if (root == null)
            {
                return null;
            }

            //if v1 or v2 is root data, lca is root (The tree will contain nodes with data equal to v1 and v2.)
            if(root.data == v1 || root.data == v2)
            {
                return root;
            }

            //If none of the above happened, lca is either on left or right branch
            Node leftLCA = lca(root.left,v1,v2);
            Node rightLCA = lca(root.right,v1,v2);

            //Now we have 3 cases:
            //if both not null, v1 and v2 are in different branches, so root is lca
            if(leftLCA != null && rightLCA != null)
            {
                return root;
            }
            //otherwise, lca is either in left or right not null branch
            if(leftLCA != null)
            {
                return leftLCA;
            } else
            {
                return rightLCA;
            }

        }

        //Trees: Is This a Binary Search Tree? (Hackerrank site is bugged with this problem. No hidden Main results in runtime Error)
        public static bool checkBST(Node root) {
            
            return checkBSTHelper(root,int.MinValue, int.MaxValue);

        }

        private static bool checkBSTHelper(Node n, int min, int max)
        {
            if(n == null)
            {
                return true;
            }
            if(min >= n.data || max <= n.data)
            {
                return false;
            }
            return checkBSTHelper(n.left,min,n.data) && checkBSTHelper(n.right,n.data,max);
        }



        //Tree: Huffman Decoding
        public static void decode(String s, NodeHuffman root) {
            StringBuilder decoded = new StringBuilder();

            NodeHuffman tmp = root;
            foreach (char c in s)
            {
                if(c == '1')
                {
                    tmp = tmp.right;
                } else
                {
                    tmp = tmp.left;
                }

                if(tmp.data != 'ϕ')
                {
                    decoded.Append(tmp.data);
                    tmp = root; //back to the start
                }
            }

            Console.WriteLine(decoded.ToString());
        }

        public static Node insert(Node root, int data) {
            if(root == null) {
                return new Node(data);
            } else {
                Node cur;
                if(data <= root.data) {
                    cur = insert(root.left, data);
                    root.left = cur;
                } else {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }
        #endregion
    }
}
