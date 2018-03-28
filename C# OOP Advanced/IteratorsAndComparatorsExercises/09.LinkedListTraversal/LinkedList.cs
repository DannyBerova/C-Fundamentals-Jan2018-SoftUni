using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void Add(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            var newTail = new ListNode<T>(element) { PrevNode = this.tail };
            this.tail.NextNode = newTail;
            this.tail = newTail;
        }

        this.Count++;
    }

    public bool Remove(T element)
    {
        if (this.Count == 0)
        {
            return false;
        }

        ListNode<T> node = this.head;
        ListNode<T> currentNode = this.head;
        ListNode<T> previousNode = null;

        while (node != null)
        {
            currentNode = node;

            if (node.Value.Equals(element))
            {
                if (previousNode != null)
                {
                    previousNode.NextNode = currentNode.NextNode;
                }
                else
                {
                    this.head = this.head.NextNode;
                }

                break;
            }

            previousNode = currentNode;
            node = node.NextNode;
        }

        int count = 0;
        ListNode<T> tempNode = this.head;

        while (tempNode != null)
        {
            count++;
            tempNode = tempNode.NextNode;
        }

        if (this.Count > count)
        {
            this.Count--;
            return true;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class ListNode<T>
    {
        public T Value { get; private set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode<T> PrevNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }
}