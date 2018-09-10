using System;
using System.Diagnostics;

namespace ComparisonOfWorkOfAlgorithms
{
    static class SortTesting
    {
        static private int iterations = 100;
        static private int[] array;
        static private void shellSort(int[] arr)
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

        static private void hoareSort(int[] array, int start, int end)
        {
            if (end == start) return;
            var pivot = array[end];
            var storeIndex = start;
            for (int i = start; i <= end - 1; i++)
                if (array[i] <= pivot)
                {
                    var t = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = t;
                    storeIndex++;
                }

            var n = array[storeIndex];
            array[storeIndex] = array[end];
            array[end] = n;
            if (storeIndex > start) hoareSort(array, start, storeIndex - 1);
            if (storeIndex < end) hoareSort(array, storeIndex + 1, end);
        }

        static private void hoareSort(int[] array)
        {
            if (array.Length == 0) return;
            hoareSort(array, 0, array.Length - 1);
        }

        static private void bubbleSort(int[] array)
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

        static private double calculateTime(Action<int[]> sortingAlgoritm)
        {
            var averageTime = 0.0;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < iterations; i++)
                sortingAlgoritm((int[])array.Clone());
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            averageTime = (ts.Hours * 1000 * 60 * 60 + ts.Minutes * 1000 * 60 + ts.Seconds * 1000 + ts.Milliseconds);
            return averageTime / iterations;
        }

        static private int[] generateArray(int length=1000)
        {
            var random = new Random();
            var array = new int[length];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next();
            return array;
        }

        static public string setIterations(string[] args)
        {
            int res;
            if(args.Length < 2)
                return "У команды iterations не может быть меньше одного аргумента.";
            if (args.Length > 2)
                return "У команды iterations не может быть больше одного аргумента.";
            if (!Int32.TryParse(args[1], out res))
                return "Не является числом.";
            iterations = res;
            return "Количество итераций: " + iterations;
        }

        static public string SetRandomArray(string[] args)
        {
            int res;
            if(args.Length<2)
            {
                array = generateArray();
                return "Последовательность установлена.";
            }

            if (args.Length > 2)
                return "У команды random не может быть больше одного аргумента.";
            if (!Int32.TryParse(args[1], out res))
                return "Не является числом.";
            if (res < 0)
                return "Введите положительное.";
             array=generateArray(res);
             return "Последовательность установлена.";
        }

        static public string setArray(string[] arrayString)
        {
            array = new int[arrayString.Length - 1];
            for (int i = 1; i < arrayString.Length; i++)
            {
                if (!Int32.TryParse(arrayString[i], out array[i - 1]))
                {
                    return "Неверный формат массива.";
                }
            }
            return "Последовательнсоть установлена";
        }

        static public string Test(string[]args)
        {
            return "Итераций: " + iterations + ", Размер массива: " + array.Length + "\nШелл: " 
                + calculateTime(shellSort) + " мс\nQuickSort: " + calculateTime(hoareSort) + " мс\nПузырек: " 
                + calculateTime(bubbleSort) + " мс";
        }
    }
}
