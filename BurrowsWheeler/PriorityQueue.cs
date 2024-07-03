using System;
using System.Collections.Generic;

public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> items;

    public PriorityQueue()
    {
        items = new List<T>();
    }

    public int Count
    {
        get { return items.Count; }
    }

    public void Enqueue(T item)
    {
        items.Add(item);
        HeapUp(items.Count - 1);
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            Console.WriteLine("Queue is empty");
        }

        T topItem = items[0];
        int lastIndex = Count - 1;
        items[0] = items[lastIndex];
        items.RemoveAt(lastIndex);

        if (Count > 1)
        {
            HeapDown(0);
        }

        return topItem;
    }
        /*starts with the new element index at the end of the heap
         and comparing with the parent if while(element is < parent) swap(element,parent)
        until element in correct position or reach root of heap
         */
    private void HeapUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (items[parentIndex].CompareTo(items[index]) > 0)
            {
                Swap(parentIndex, index);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void HeapDown(int index)
    {
        int leftChild, rightChild, minIndex;

        while (true)
        {
            leftChild = 2 * index + 1;
            rightChild = 2 * index + 2;
            minIndex = index;

            if (leftChild < Count && items[leftChild].CompareTo(items[minIndex]) < 0)
            {
                minIndex = leftChild;
            }

            if (rightChild < Count && items[rightChild].CompareTo(items[minIndex]) < 0)
            {
                minIndex = rightChild;
            }

            if (minIndex != index)
            {
                Swap(index, minIndex);
                index = minIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void Swap(int index1, int index2)
    {
        T temp = items[index1];
        items[index1] = items[index2];
        items[index2] = temp;
    }
}
