using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    public enum TestSortType
    {
        BubbleSort,
        QuickSort,
        SelectionSort,
        HeapSort,
        InsertionSort,
        ShellSort,
        MergeSort
    }
    class Program
    {
        static TestSortType testSortType = new TestSortType();
        static void Main(string[] args)
        {
            long[] inputArray = new long[1000];

            Random rnd = new Random();

            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = rnd.Next();
            }


            var testSorting = new TestSorting();
            //Change the enum value to test speed or walk through different sort algorithms
            testSortType = TestSortType.MergeSort;

            switch(testSortType)
            {
                case TestSortType.BubbleSort:
                    Console.WriteLine("Bubble Sort");
                    WriteDateTimeMillisecond();
                    testSorting.BubbleSort(inputArray);
                    WriteDateTimeMillisecond();
                    break;
                case TestSortType.HeapSort:
                    Console.WriteLine("Heap Sort");
                    WriteDateTimeMillisecond();
                    testSorting.HeapSort(inputArray);
                    WriteDateTimeMillisecond();
                    break;
                case TestSortType.InsertionSort:
                    Console.WriteLine("Insertion Sort");
                    WriteDateTimeMillisecond();
                    testSorting.InsertionSort(inputArray);
                    WriteDateTimeMillisecond();
                    break;
                case TestSortType.MergeSort:
                    Console.WriteLine("Merge Sort");
                    WriteDateTimeMillisecond();
                    testSorting.MergeSort(inputArray);
                    WriteDateTimeMillisecond();
                    break;
                case TestSortType.QuickSort:
                    Console.WriteLine("Quick Sort");
                    WriteDateTimeMillisecond();
                    testSorting.QuickSort(inputArray);
                    WriteDateTimeMillisecond();
                    break;
                case TestSortType.SelectionSort:
                    Console.WriteLine("Selection Sort");
                    WriteDateTimeMillisecond();
                    testSorting.SelectionSort(inputArray);
                    WriteDateTimeMillisecond();
                    break;
                case TestSortType.ShellSort:
                    Console.WriteLine("Shell Sort");
                    WriteDateTimeMillisecond();
                    testSorting.ShellSort(inputArray);
                    WriteDateTimeMillisecond();
                    break;
            }
            Console.ReadLine();

        }

        static void WriteDateTimeMillisecond()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + ":" + DateTime.Now.Millisecond);
        }



        public class TestSorting
        {
            private void Swap(ref long valOne, ref long valTwo)
            {
                valOne = valOne + valTwo;
                valTwo = valOne - valTwo;
                valOne = valOne - valTwo;
            }

            private void SwapWithTemp(ref long valOne, ref long valTwo)
            {
                long temp = valOne;
                valOne = valTwo;
                valTwo = temp;
            }


            /*   
    Worst-case performance	
    O(n2)
    O(n^{2})
    Best-case performance	
    O(n)
    O(n)
    Average performance	
    O(n2)
    O(n^{2})
    Worst-case space complexity	
    O(1)
    O(1) auxiliary
                 https://en.wikipedia.org/wiki/Bubble_sort
                  */
            public void BubbleSort(long[] inputArray)
            {
                for (int iterator = 0; iterator < inputArray.Length; iterator++)
                {
                    for (int index = 0; index < inputArray.Length - 1; index++)
                    {
                        if (inputArray[index] > inputArray[index + 1])
                        {
                            Swap(ref inputArray[index], ref inputArray[index + 1]);
                        }
                    }
                }
            }

            /*
             * 
             * 
             * 
    Worst-case performance	O(n2)
    Best-case performance	O(n log n) (simple partition)
    or O(n) (three-way partition and equal keys)
    Average performance	O(n log n)
    Worst-case space complexity	O(n) auxiliary (naive)
    O(log n) auxiliary (Sedgewick 1978)
                https://en.wikipedia.org/wiki/Quicksort
             * 
             */
            public void QuickSort(long[] inputArray)
            {
                int left = 0;
                int right = inputArray.Length - 1;
                InternalQuickSort(inputArray, left, right);
            }


            // Internal recursive sort uses divide and conquer based on  pivot

            private void InternalQuickSort(long[] inputArray, int left, int right)
            {
                int pivotNewIndex = Partition(inputArray, left, right);
                long pivot = inputArray[(left + right) / 2];
                if (left < pivotNewIndex - 1)
                    InternalQuickSort(inputArray, left, pivotNewIndex - 1);
                if (pivotNewIndex < right)
                    InternalQuickSort(inputArray, pivotNewIndex, right);
            }

            //This operation returns a new pivot everytime it is called recursively
            //and swaps the array elements based on pivot value comparison
            private int Partition(long[] inputArray, int left, int right)
            {
                int i = left, j = right;
                long pivot = inputArray[(left + right) / 2];

                while (i <= j)
                {
                    while (inputArray[i] < pivot)
                        i++;
                    while (inputArray[j] < pivot)
                        j--;
                    if (i <= j)
                    {
                        SwapWithTemp(ref inputArray[i], ref inputArray[j]);
                        i++; j--;
                    }
                }
                return i;
            }

            /*
             * 
             * 
    Worst-case performance	О(n2) comparisons, О(n) swaps
    Best-case performance	О(n2) comparisons, О(n) swaps
    Average performance	О(n2) comparisons, О(n) swaps
    Worst-case space complexity
    https://en.wikipedia.org/wiki/Selection_sort
             * 
             * 
             */

            public void SelectionSort(long[] inputArray)
            {
                long index_of_min = 0;
                for (int iterator = 0; iterator < inputArray.Length - 1; iterator++)
                {
                    index_of_min = iterator;
                    for (int index = iterator + 1; index < inputArray.Length; index++)
                    {
                        if (inputArray[index] < inputArray[index_of_min])
                            index_of_min = index;
                    }
                    Swap(ref inputArray[iterator], ref inputArray[index_of_min]);
                }
            }

            /*
             *  
    Worst-case performance	
    O(n log⁡ n)
    O(n\log n)
    Best-case performance	
    O(n log⁡ n)
    O(n\log n) (distinct keys)
    or 
    O(n)
    O(n) (equal keys)
    Average performance	
    O(n log⁡ n)
    O(n\log n)
    Worst-case space complexity	
    O(1)
    O(1) auxiliary
    https://en.wikipedia.org/wiki/Heapsort
    */
            public void HeapSort(long[] inputArray)
            {
                for (int index = (inputArray.Length / 2) - 1; index >= 0; index--)
                    Heapify(inputArray, index, inputArray.Length);
                for (int index = inputArray.Length - 1; index >= 1; index--)
                {
                    SwapWithTemp(ref inputArray[0], ref inputArray[index]);
                    Heapify(inputArray, 0, index - 1);
                }
            }

            private void Heapify(long[] inputArray, int root, int bottom)
            {
                bool completed = false;
                int maxChild;

                while ((root * 2 <= bottom) && (!completed))
                {
                    if (root * 2 == bottom)
                        maxChild = root * 2;
                    else if (inputArray[root * 2] > inputArray[root * 2 + 1])
                        maxChild = root * 2;
                    else
                        maxChild = root * 2 + 1;

                    if (maxChild == inputArray.Count())
                        maxChild = inputArray.Count() - 1;

                    if (inputArray[root] < inputArray[maxChild])
                    {
                        SwapWithTemp(ref inputArray[root], ref inputArray[maxChild]);
                        root = maxChild;
                    }
                    else
                    {
                        completed = true;
                    }
                }
            }


            /****
             * 
    Worst-case performance	О(n2) comparisons, swaps
    Best-case performance	O(n) comparisons, O(1) swaps
    Average performance	О(n2) comparisons, swaps
    Worst-case space complexity	О(n) total, O(1) auxiliary
    https://en.wikipedia.org/wiki/Insertion_sort
             * 
             */
            public void InsertionSort(long[] inputArray)
            {
                long j = 0;
                long temp = 0;
                for (int index = 1; index < inputArray.Length; index++)
                {
                    j = index;
                    temp = inputArray[index];
                    while ((j > 0) && (inputArray[j - 1] > temp))
                    {
                        inputArray[j] = inputArray[j - 1];
                        j = j - 1;
                    }
                    inputArray[j] = temp;
                }
            }



            /**
Worst-case performance	O(n2) (worst known gap sequence)
O(n log2n) (best known gap sequence)[1]
Best-case performance	O(n log n)[2]
Average performance	depends on gap sequence
Worst-case space complexity	О(n) total, O(1) auxiliary
https://en.wikipedia.org/wiki/Shellsort
             * **/
            public void ShellSort(long[] inputArray)
            {
                long j, temp = 0;
                int increment = (inputArray.Length) / 2;
                while (increment > 0)
                {
                    for (int index = 0; index < inputArray.Length; index++)
                    {
                        j = index;
                        temp = inputArray[index];
                        while ((j >= increment) && inputArray[j - increment] > temp)
                        {
                            inputArray[j] = inputArray[j - increment];
                            j = j - increment;
                        }
                        inputArray[j] = temp;
                    }
                    if (increment / 2 != 0)
                        increment = increment / 2;
                    else if (increment == 1)
                        increment = 0;
                    else
                        increment = 1;
                }
            }

            /*
             *
             *  
    Worst-case performance	O(n log n)
    Best-case performance	
    O(n log n) typical,

    O(n) natural variant
    Average performance	O(n log n)
    Worst-case space complexity	О(n) total with O(n) auxiliary, O(1) auxiliary with linked lists[1]
    https://en.wikipedia.org/wiki/Merge_sort
     */
            public void MergeSort(long[] inputArray)
            {
                int left = 0;
                int right = inputArray.Length - 1;
                InternalMergeSort(inputArray, left, right);
            }

            private void InternalMergeSort(long[] inputArray, int left, int right)
            {
                int mid = 0;
                if (left < right)
                {
                    mid = (left + right) / 2;
                    InternalMergeSort(inputArray, left, mid);
                    InternalMergeSort(inputArray, (mid + 1), right);
                    MergeSortedArray(inputArray, left, mid, right);
                }
            }

            private void MergeSortedArray(long[] inputArray, int left, int mid, int right)
            {
                int index = 0;
                int total_elements = right - left + 1; //BODMAS rule
                int right_start = mid + 1;
                int temp_location = left;
                long[] tempArray = new long[total_elements];

                while ((left <= mid) && right_start <= right)
                {
                    if (inputArray[left] <= inputArray[right_start])
                    {
                        tempArray[index++] = inputArray[left++];
                    }
                    else
                    {
                        tempArray[index++] = inputArray[right_start++];
                    }
                }
                if (left > mid)
                {
                    for (int j = right_start; j <= right; j++)
                        tempArray[index++] = inputArray[right_start++];
                }
                else
                {
                    for (int j = left; j <= mid; j++)
                        tempArray[index++] = inputArray[left++];
                }
                //Array.Copy(tempArray, 0, inputArray, temp_location, total_elements);
                // just another way of accomplishing things (in-built copy)
                for (int i = 0, j = temp_location; i < total_elements; i++, j++)
                {
                    inputArray[j] = tempArray[i];
                }
            }

        }
    }
}
