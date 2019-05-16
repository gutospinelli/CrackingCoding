using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace CrackingCoding.Data_Structures
{
    public enum TreeOrder
    {
        inOrder = 1,
        preOrder = 2,
        postOrder = 3
    }

    public class Tree
    {
        //public Tree(Node root)
        //{
        //    this.root = root;
        //}
        //public Node root;
    }

    public class Node
    {
        public Node(int data)
        {
            this.data = data;
        }
    	public int data;
    	public Node left;
    	public Node right;
        public bool visited;

        public void inOrderTransversal(Node n)
        {
            //inOrder = left->root->right
            if(n != null)
            {
                inOrderTransversal(n.left);
                visit(n);
                inOrderTransversal(n.right);
            }
        }

        public void preOrderTransversal(Node n)
        {
            //pre order = root->left->right
            if(n != null)
            {
                visit(n);
                inOrderTransversal(n.left);
                inOrderTransversal(n.right);
            }
        }

        public void postOrderTransversal(Node n)
        {
            //post-order => left->right->root
            inOrderTransversal(n.left);
            inOrderTransversal(n.right);
            visit(n);
        }

        public void printTree(Node root, TreeOrder order)
        {
            switch (order)
            {
                case TreeOrder.inOrder:
                    inOrderTransversal(root);
                    break;
                case TreeOrder.preOrder:
                    preOrderTransversal(root);
                    break;
                case TreeOrder.postOrder:
                    postOrderTransversal(root);
                    break;
                default:
                    break;
            }
        }

        public void visit(Node n)
        {
            if (!n.visited)
            {
                n.visited = true;
                Console.Write(n.data + " ");
            }
        }

        public static Node insert(Node root, int data)
        {
            if(root == null)
            {
                return new Node(data);
            } else
            {
                Node nodeToInsert;
                if(data <= root.data) //Equal data nodes inserted to the left
                {
                    nodeToInsert = insert(root.left, data);
                    root.left = nodeToInsert;
                } else
                {
                    nodeToInsert = insert(root.right,data);
                    root.right = nodeToInsert;
                }
                return root;
            }
        }

        public static Node treeFromArray(int[] array)
        {
            Node root = null;
            foreach(int i in array)
            {
                root = insert(root,i);
            }
            return root;
        }

    }

    public class Pilha {
        public Stack stack = new Stack();
        
        public void Testes()
        {
            
        }


    }
}
