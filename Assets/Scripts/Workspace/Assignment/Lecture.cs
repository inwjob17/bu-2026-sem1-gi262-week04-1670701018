using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        public void Start()
        {
            // LCT01_SyntaxList();
             LCT02_SyntaxLinkedList();
            // LCT03_SyntaxHashTable();
            // LCT04_SyntaxDictionary();
        }

        #region Lecture

        public void LCT01_SyntaxList()
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_SyntaxLinkedList()
        {
            LinkedList<string> linkedlist = new LinkedList<string>();
            
            linkedlist.AddLast("Node 1");

            linkedlist.AddLast("Node 2");

            linkedlist.AddFirst("Node 0");

            LinkedListNode<string> FirstNode = linkedlist.First;
            Debug.Log("first: " + FirstNode.Value);

            LinkedListNode<string> LastNode = linkedlist.First;
            Debug.Log("Last: " + LastNode.Value);

            Debug.Log("firstNode.Next " + FirstNode.Next.Value);
            Debug.Log("firstNodeNext.Next: " + FirstNode.Next.Next.Value);

            Debug.Log("Last.Node.Previous " + LastNode.Previous.Value);
            Debug.Log("Last.Node.Previous.Previous " + LastNode.Previous.Previous.Value);

            if (FirstNode.Previous == null) Debug.Log("FirstNode.Previous == null");
            if (LastNode.Next == null) Debug.Log("LastNode.Next == null");

            linkedlist.AddAfter(FirstNode, "Node 0.5");
            linkedlist.AddBefore(LastNode, "Node 1.5");

            LinkedListNode<string> node1 = linkedlist.Find("Node 1");

            linkedlist.Remove("Node 1");
            linkedlist.Remove(node1);
            linkedlist.RemoveLast();
            linkedlist.RemoveFirst();

            linkedlist.Clear();
        }

        public void LCT03_SyntaxHashTable()
        {
            throw new System.NotImplementedException();
        }

        public void LCT04_SyntaxDictionary()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
