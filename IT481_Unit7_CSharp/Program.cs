using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace IT481_Unit7_CSharp
{
    class Program
    {
       
            //Create the stopwatch object
            private static Stopwatch stopwatch;

        //Create a debug for printing
        private static bool debug = false;

        static void Main(string[] args)
        {


            //Set type using number:
            // 1 = bubble sort
            // 2 = quicksort
            int type = 1;


            //create a small integer array (10)
            int[] smallArray = getArray(10, 100);

            //Deep copy to new array used for removing duplicates
            int[] newSmallArray = new int[smallArray.Length];
            Array.Copy(smallArray, 0, newSmallArray, 0, newSmallArray.Length);

            //Deep copy to another array used fopr quick sorting
            int[] quickSmallArray = new int[newSmallArray.Length];
            Array.Copy(newSmallArray, 0, quickSmallArray, 0, quickSmallArray.Length);

            //run the small bubble sort
            String size = "small";
            runSortArray(smallArray, size, type);


            //Medium array

            //create as medium integer array (1000)
            int[] mediumArray = getArray(1000, 100);

            //Deep copy to a new array used for removing duplicates
            int[] newMediumArray = new int[mediumArray.Length];
            Array.Copy(newMediumArray, 0, newMediumArray, 0, newMediumArray.Length);

            //Deep copy to another array using for quick sorting
            int[] quickMediumArray = new int[newMediumArray.Length];
            Array.Copy(newMediumArray, 0, quickMediumArray, 0, quickMediumArray.Length);

            //run the medium bubble sort
            size = "medium";
            runSortArray(mediumArray, size, type);

            //Large array

            //create a large integer array (10,000)
            int[] largeArray = getArray(10000, 100);

            //Deep copy to a new array used for removing duplicates
            int[] newLargeArray = new int[largeArray.Length];
            Array.Copy(largeArray, 0, newLargeArray, 0, newLargeArray.Length);

            //Deep copy to another array used for quick sorting
            int[] quickLargeArray = new int[newLargeArray.Length];
            Array.Copy(newLargeArray, 0, quickLargeArray, 0, quickLargeArray.Length);

            //run the large bubble sort
            size = "large";
            runSortArray(largeArray, size, type);


            //Set to remove duplicates

            //Remove duplicates and rerun tests

            //new small array by removing duplicates
            newSmallArray = onlyUniqueElements(newSmallArray);
            size = "new small unique";
            runSortArray(newSmallArray, size, type);

            //new medium array by removing duplicates
            newMediumArray = onlyUniqueElements(newMediumArray);
            size = "new medium unique";
            runSortArray(newMediumArray, size, type);

            //new large array by removing duplicates
            newLargeArray = onlyUniqueElements(newLargeArray);
            size = "new large unique";
            runSortArray(newLargeArray, size, type);


            //Quicksort

            //Set the type to run quicksort
            type = 2;

            //Use the quicksort
            size = "quick small";

            //Run the array for timing
            runSortArray(quickSmallArray, size, type);

            //Use the quick sort
            size = "quick medium";

            //Run the array for timing
            runSortArray(quickMediumArray, size, type);

            //Use the quicksort
            size = "quick large";
            runSortArray(quickLargeArray, size, type);

            Console.Read();

        }



        //Get array of integers of sizes as determined by parameters passed
        private static int[] getArray(int size, int randomMaxSize)
        {

            //Create the array with size
            int[] myArray = new int[size];

            //Get the random values for the array
            for (int i = 0; i < myArray.Length; i++)
            {
                //Get the random number with randomMaxSize as the upper limit of 1 - randomMaxSize.
                myArray[i] = GetRandomNumber(1, randomMaxSize);

            }

            //Return the filled array
            return myArray;


        }



        //Run the sort actions by printing and timing the arrays

        private static void runSortArray(int[] arr, String size, int type)
        {

            long elapsedTime = 0;


            //Set the sort type as a string
            String sort = null;

            if (type == 1)
            {

                sort = "bubble";

            }
            else if (type == 2)
            {

                sort = "quick";
            }


            //print array before sorting using bubble sort algorithm
            if (debug)
            {
                Console.WriteLine("Array berfore the " + sort + "sort");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }

            }


            //Start the timer
            stopwatch = Stopwatch.StartNew();

            //sort an array using bubble sort algorithm
            if (type == 1)
            {
                bubbleSort(arr);
            }
            else if (type == 2)
            {

                //Set low and high values for a quick sort
                int low = 0;
                int high = arr.Length - 1;
                sortAsc(arr, low, high);



            }
            Console.WriteLine();

            //print array after sorting using bubble sort algorithm

            if (debug)
            {
                Console.WriteLine("Array after the " + sort + "sort");

                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }

            }

            //Stop the wait timer
            stopwatch.Stop();

            //Get the time elapsed for waiting
            elapsedTime = stopwatch.ElapsedTicks;

            long frequency = Stopwatch.Frequency;

            long nanosecondsPerTick = (1000L * 1000L * 1000L) / frequency;

            elapsedTime = elapsedTime * nanosecondsPerTick;

            Console.WriteLine("\n");

            //Print out the time in nanaseconds
            Console.WriteLine("The run time is for the " + size + "array in nanoseconds is " + elapsedTime);

            Console.WriteLine("\n\n");


        }


        //Perform the bubble sort

        private static void bubbleSort(int[] intArray)
        {



            int temp = 0;

            for (int i = 0; i < intArray.Length; i++)
            {
                for (int j = 0; j < intArray.Length - 1; j++)
                {
                    if (intArray[j] > intArray[j + 1])
                    {
                        temp = intArray[j + 1];
                        intArray[j + 1] = intArray[j];
                        intArray[j] = temp;

                    }
                }
            }
        }

        //Remove duplicates in an array using a set

        private static int[] onlyUniqueElements(int[] inputArray)
        {
            //create the set
            HashSet<int> set = new HashSet<int>();

            //create the temporary array
            int[] tmp = new int[inputArray.Length];
            int index = 0;

            //use the set to remove duplicates and add to new array
            foreach (int i in inputArray)
                if (set.Add(i))
                    tmp[index++] = i;

            //return the array
            return set.ToArray();
        }


        //Quicksort and compare numbers

        private static void sortAsc(int[] x, int low, int high)
        {

            if (x == null || x.Length == 0)
                return;

            if (low >= high)
                return;

            //pick the pivot
            int middle = low + (high - low) / 2;
            int pivot = x[middle];

            //make left < pivot and right > pivot
            int i = low, j = high;
            while (i <= j)
            {
                while (x[i] < pivot)
                {
                    i++;
                }

                while (x[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++;
                    j--;
                    //count = count + 1; //counts number of swaps during the sort


                }

            }

            //recursively sort two sub parts
            if (low < j)
                sortAsc(x, low, j);

            if (high > i)
                sortAsc(x, i, high);

        }

        //Random number methods
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return getrandom.Next(min, max);
            }
        }


        }



        }












        

        
        
    

