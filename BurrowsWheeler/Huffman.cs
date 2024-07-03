using System.Collections.Generic;
using System.Linq;
/*FAILED*/
public class HuffmanNode : IComparable<HuffmanNode>
{
    public char Symbol { get; set; }
    public int Frequency { get; set; }
    public HuffmanNode Left { get; set; }
    public HuffmanNode Right { get; set; }

    public int CompareTo(HuffmanNode? other)
    {
        throw new NotImplementedException();
    }
}

public class Huffman 
{
    public static HuffmanNode BuildHuffmanTree(string text)
    {
        // Count frequencies
        Dictionary<char, int> charFrequencies = new Dictionary<char, int>();
        foreach (char c in text)
        {
                /*low frequency*/
            if (charFrequencies.ContainsKey(c))
                charFrequencies[c]++;
            else
                /*high frequency*/
                charFrequencies[c] = 1;
        }

        // Initialize priority queue with leaf nodes
        PriorityQueue<HuffmanNode> pq = new PriorityQueue<HuffmanNode>();
        foreach (var pair in charFrequencies)
        {
            pq.Enqueue(new HuffmanNode { Symbol = pair.Key, Frequency = pair.Value });
        }

        // Build Huffman tree
        while (pq.Count > 1)
        {
            HuffmanNode x = pq.Dequeue();
            HuffmanNode y = pq.Dequeue();

            HuffmanNode z = new HuffmanNode
            {
                Frequency = x.Frequency + y.Frequency,
                Left = x,
                Right = y
            };

            pq.Enqueue(z);
        }

        // Return root of the Huffman tree
        return pq.Dequeue();
    }
}


