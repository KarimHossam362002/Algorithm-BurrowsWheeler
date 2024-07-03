using System;
using System.Collections.Generic;
using System.Linq;

public class BWT
{
        /*BWT Encode*/
    public static string Encode(string input)
    {
        

        int n = input.Length;
        //abfacadabfa for example the suffixarray is abf and the circularing index goes as equation at line 16
        int[] suffixArray = GenerateSuffixArray(input);

        string bwtEncoded = "";
        for (int i = 0; i < n; i++)
        {
            int index = (suffixArray[i] + n - 1) % n; // Circular index
            bwtEncoded += input[index];
        }

        return bwtEncoded;
    }

    private static int[] GenerateSuffixArray(string input)
    {
        int n = input.Length;
        int[] suffixArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            suffixArray[i] = i; /*for abfacadabfa so n = 11*/
        }

        // Perform QuickSort on the suffix array based on suffixes
        QuickSortSuffixArray(input, suffixArray, 0, n - 1);

        return suffixArray;
    }

    private static void QuickSortSuffixArray(string input, int[] suffixArray, int left, int right)
    {
        if (left < right)
        {
            int partitionIndex = Partition(input, suffixArray, left, right);
            QuickSortSuffixArray(input, suffixArray, left, partitionIndex - 1);
            QuickSortSuffixArray(input, suffixArray, partitionIndex + 1, right);
        }
    }
    /*Divide step*/
    private static int Partition(string input, int[] suffixArray, int left, int right)
    {
        int pivotIndex = suffixArray[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (CompareSuffixes(input, suffixArray[j], pivotIndex) <= 0)
            {
                i++;
                Swap(suffixArray, i, j);
            }
        }

        Swap(suffixArray, i + 1, right);
        return i + 1;
    }

    private static int CompareSuffixes(string input, int index1, int index2)
    {
        string suffix1 = input.Substring(index1);
        string suffix2 = input.Substring(index2);
        return string.Compare(suffix1, suffix2);
    }

    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    /*BWT Decoding */
    public static string Decode(string bwt, int[] next, int originalIndex)
    {
        int length = bwt.Length;
        char[] originalOrder = new char[length];
        int index = originalIndex;

        for (int i = 0; i < length; i++)
        {
            originalOrder[i] = bwt[index];
            index = next[index];
        }

        string decodedText = new string(originalOrder);
        decodedText = decodedText.Substring(1) + decodedText[0];
        return decodedText;
    }
}
