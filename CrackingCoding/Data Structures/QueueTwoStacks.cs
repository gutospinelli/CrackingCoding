using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCoding.Data_Structures
{
    public class QueueTwoStacks
    {
        //A basic queue has the following operations:
        //Enqueue: add a new element to the end of the queue.
        //Dequeue: remove the element from the front of the queue and return it.

        //Idea: one stack to perform pushes other for popes. 
        //We always add to stackIn and always pop/peek from stackOut. If stackOUT is empty, we pop everyitem on stackIn to stackOut
        public Stack<int> stackIN = new Stack<int>();
        public Stack<int> stackOUT = new Stack<int>();

        public void enqueue(int item)
        {
            stackIN.Push(item); //We always put from stackIN to simulate queue
        }

        public int dequeue()
        {
            if(stackOUT.Count > 0) //not empty stack
            {
                return stackOUT.Pop();
            }
            //empty peek/pop stackOut, we fill it with everything from stackIn
            while(stackIN.Count > 0) //We empty stackIn
            {
                stackOUT.Push(stackIN.Pop());
            }
            
            return stackOUT.Pop(); //We always return from stackOUT to simulate queue
        }

        public int peek()
        {
            if(stackOUT.Count > 0) //not empty stack, we have itens to pop/peek
            {
                return stackOUT.Peek();
            }
            //empty peek/pop stackOut, we fill it with everything from stackIn
            while(stackIN.Count > 0) //We empty stackIn
            {
                stackOUT.Push(stackIN.Pop());
            }
            
            return stackOUT.Peek(); //We always return from stackOUT to simulate queue
        }
    }
}
