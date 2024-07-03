using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurrowsWheeler
{
    public class QuickSort
    {
        public static void QuickSortAlgorithm(int[] array)
        {
            QuickSortHelper(array, 0, array.Length - 1);
        }

        private static void QuickSortHelper(int[] array, int first, int last)
        {
    /*Divide*/
            if (first < last)
            {
                int splitPoint = Partition(array, first, last);
                QuickSortHelper(array, first, splitPoint - 1);
                QuickSortHelper(array, splitPoint + 1, last);
            }
        }
        /*Conquer*/
        private static int Partition(int[] array, int first, int last)
        {
            int pivotValue = array[first];
            int leftMark = first + 1;
            int rightMark = last;
            bool done = false;

            while (!done)
            {
                while (leftMark <= rightMark && array[leftMark] <= pivotValue)
                {
                    leftMark++; // left pointer goes forward
                }

                while (rightMark >= leftMark && array[rightMark] >= pivotValue)
                {
                    rightMark--; // right pointer goes backward
                }

                if (rightMark < leftMark)
                {
                    done = true;
                }
                else
                {
                    int temp = array[leftMark];
                    array[leftMark] = array[rightMark];
                    array[rightMark] = temp;
                }
            }

            int temp2 = array[first];
            array[first] = array[rightMark];
            array[rightMark] = temp2;

            return rightMark;
        }
    }
}
