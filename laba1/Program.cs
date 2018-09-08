using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;


namespace laba1
{
    public delegate void SortingAlgorithm(int[] input);
    public static class SortsAlgorithms
    {
        static public void ShellSort(int[] arr)
        {
            int j;
            int step = arr.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (arr.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (arr[j] > arr[j + step]))
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + step];
                        arr[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }
        static public void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        int t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;
                    }
        }
        static private int partition(int[] array, int start, int end)
        {
            int temp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end]) //array[end] is pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }
        static private void quicksort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            quicksort(array, start, pivot - 1);
            quicksort(array, pivot + 1, end);
        }
        static public void QuickSort(int[] array)
        {
            quicksort(array, 0, array.Length-1);
        }
    }

    class SortingAlgorithmTester
    {
        private Dictionary<string, SortingAlgorithm> testAlgorithms = new Dictionary<string, SortingAlgorithm>();
        private Dictionary<string, double> lastTestResult = new Dictionary<string, double>();
        public int Iterations; /*{ get { return iterations; }set { value} }*/
        public int[]TestValues{get;set;}//t
        public SortingAlgorithmTester(Dictionary<string,SortingAlgorithm> sortingAlgorithms)
        {
            foreach (string name in sortingAlgorithms.Keys)
            {
                lastTestResult.Add(name,0.0);
            }
            TestValues =new int[]{ 1, 4, 2, 78, 43, 4 };
            testAlgorithms = sortingAlgorithms;
            Iterations=10000;
        }

        private void RunTest()
        {
            foreach(string name in testAlgorithms.Keys)
            {
                var timer = 0.0;
                Stopwatch stopwatch = new Stopwatch();
                for (int i = 0; i < Iterations; i++)
                {
                    int[] testValues=(int[])TestValues.Clone();
                    stopwatch.Start();
                    testAlgorithms[name](testValues);
                    stopwatch.Stop();
                    timer += stopwatch.ElapsedMilliseconds;
                }
                lastTestResult[name] = timer/Iterations;
            }
        }
        public Dictionary<string,double> GetTestResult()
        {
            RunTest();
            return lastTestResult;
        }
    }

    static class RequestHandler
    {
        private static SortingAlgorithmTester sortingAlgorithmTester =
                new SortingAlgorithmTester(new Dictionary<string, SortingAlgorithm>
                                            { { "ShellSort", SortsAlgorithms.ShellSort },
                                            { "QuickSort", SortsAlgorithms.QuickSort},
                                            {"BubleSort",SortsAlgorithms.BubbleSort}});
        public static void HandleRequest(string userRequest)
        {            
            var parsedRequest = userRequest.Split(' ');
            switch (parsedRequest[0])
            {
                case "help":
                    Console.WriteLine();
                    break;
                case "iterations":
                    var iterations = Convert.ToInt32(parsedRequest[1]);
                    sortingAlgorithmTester.Iterations = iterations;
                    break;
                case "sequence":
                    var sequence = new int[parsedRequest.Length-1];
                    for (int i = 1; i < parsedRequest.Length; i++)
                        sequence[i - 1] = Convert.ToInt32(parsedRequest[i]);
                    sortingAlgorithmTester.TestValues = sequence;
                    break;
                case "start":
                    var result = sortingAlgorithmTester.GetTestResult();
                    Console.WriteLine("Итераций: " + sortingAlgorithmTester.Iterations + 
                                      ", Размер массивa: " + sortingAlgorithmTester.TestValues.Length);
                    foreach (string res in result.Keys)
                        Console.WriteLine(res +": "+result[res]+"ms");
                    break;
            }
        }
    }

    class Program
    {             
        static void Main(string[] args)
        {
            string input;
            input=Console.ReadLine();
            RequestHandler.HandleRequest(input);
            Console.ReadLine();
        }
    }
}
