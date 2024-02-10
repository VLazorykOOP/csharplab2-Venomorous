using System;

public class Lab2
{
    static int[] GenerateRandomArray(int length, int minValue, int maxValue)
    {
        int[] array = new int[length];
        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(minValue, maxValue + 1);
        }

        return array;
    }

    static double[] GenerateRandomArray(int length, double minValue, double maxValue)
    {
        double[] array = new double[length];
        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            double randomValue = minValue + (maxValue - minValue) * random.NextDouble();
            array[i] = Math.Round(randomValue, 2);
        }

        return array;
    }

    static int[,] GenerateRandomMatrix(int rows, int columns, int minValue, int maxValue)
    {
        int[,] matrix = new int[rows, columns];
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }

        return matrix;
    }

    static int[][] GenerateRandomSteppedArray(int n, int minValue, int maxValue)
    {
        int[][] array = new int[n][];
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            array[i] = new int[i + 1];
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                array[i][j] = random.Next(minValue, maxValue + 1);
            }
        }

        return array;
    }

    static int CalculateSumWithinIntervalArray(int[] array, int min, int max)
    {
        int sum = 0;

        foreach (int number in array)
        {
            if (number >= min && number <= max)
            {
                sum += number;
            }
        }

        return sum;
    }

    static double CalculateSumWithinIntervalArray(double[] array, double min, double max)
    {
        double sum = 0;

        foreach (double number in array)
        {
            if (number >= min && number <= max)
            {
                sum += number;
            }
        }

        return sum;
    }

    static int CalculateSumWithinIntervalMatrix(int[,] matrix, int min, int max)
    {
        int sum = 0;
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i, j] >= min && matrix[i, j] <= max)
                {
                    sum += matrix[i, j];
                }
            }
        }

        return sum;
    }

    static void PrintArray(int[] array)
    {
        foreach (int el in array)
        {
            Console.Write(el + " ");
        }
        Console.WriteLine();
    }

    static void PrintArray(double[] array)
    {
        foreach (double el in array)
        {
            Console.Write(el + " ");
        }
        Console.WriteLine();
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Task1Array()
    {
        Console.WriteLine("Enter size of an array: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] numbers = GenerateRandomArray(n, -100, 100);

        Console.WriteLine("Generated array:");
        PrintArray(numbers);

        Console.WriteLine("Enter borders of an interval (min): ");
        int min = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter borders of an interval (max): ");
        int max = Convert.ToInt32(Console.ReadLine());

        int sum = CalculateSumWithinIntervalArray(numbers, min, max);
        Console.WriteLine($"Sum of numbers within the interval: {sum}");
    }

    static void Task1Matrix()
    {
        Console.WriteLine("Enter the number of rows for the matrix: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the number of columns for the matrix: ");
        int columns = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = GenerateRandomMatrix(rows, columns, -100, 100);

        Console.WriteLine("Generated matrix:");
        PrintMatrix(matrix);

        Console.WriteLine("Enter borders of an interval (min): ");
        int min = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter borders of an interval (max): ");
        int max = Convert.ToInt32(Console.ReadLine());

        int sum = CalculateSumWithinIntervalMatrix(matrix, min, max);
        Console.WriteLine($"Sum of numbers within the interval: {sum}");
    }

    static void Task1()
    {
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Array");
        Console.WriteLine("2. Matrix");
        Console.Write("Enter your choice (1 or 2): ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Task1Array();
                break;

            case "2":
                Task1Matrix();
                break;

            default:
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                break;
        }
    }

    static void Task2()
    {
        Console.WriteLine("Enter size of an array: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] numbers = GenerateRandomArray(n, -100.0, 100.0);
        //double[] numbers = new double[n];

        //for (int i = 0; i < n; i++)
        //{
        //    Console.WriteLine($"Enter the {i + 1} element: ");
        //    numbers[i] = Convert.ToDouble32(Console.ReadLine());
        //}

        Console.WriteLine("Generated array:");
        PrintArray(numbers);
        Console.WriteLine("-----------------------------------------------------------");

        int indexOfMin = Array.IndexOf(numbers, numbers.Min());
        int indexOfMax = Array.IndexOf(numbers, numbers.Max());

        Console.WriteLine(
            $"Index of the min number: {indexOfMin}\n" + $"Index of the max number: {indexOfMax}"
        );

        if (indexOfMax < indexOfMin)
        {
            Console.WriteLine("Min number is after the max number");
            return;
        }

        double sum = CalculateSumWithinIntervalArray(numbers, numbers.Min(), numbers.Max());
        Math.Round(sum, 2);
        Console.WriteLine($"Sum of numbers within the interval: {sum}");
    }

    static void SwapLinesIfEven(int[,] matrix)
    {
        int rows = matrix.GetLength(0);

        if (rows % 2 == 0)
        {
            for (int i = 0; i < rows; i += 2)
            {
                if (i + 1 < rows)
                {
                    SwapRows(matrix, i, i + 1);
                }
            }
        }
    }

    static void SwapRows(int[,] matrix, int row1, int row2)
    {
        int columns = matrix.GetLength(1);

        for (int j = 0; j < columns; j++)
        {
            int temp = matrix[row1, j];
            matrix[row1, j] = matrix[row2, j];
            matrix[row2, j] = temp;
        }
    }

    static void Task3()
    {
        Console.WriteLine("Enter the number of rows for the matrix: ");
        int rows = Convert.ToInt32(Console.ReadLine());
        int columns = rows;

        int[,] matrix = GenerateRandomMatrix(rows, columns, -100, 100);

        Console.WriteLine("Generated matrix:");
        PrintMatrix(matrix);

        SwapLinesIfEven(matrix);

        Console.WriteLine("Matrix after swapping lines:");
        PrintMatrix(matrix);
    }

    static int[] FindLastOddElements(int[][] array)
    {
        int rows = array.Length;
        int columns = FindMaxColumns(array);

        int[] lastOddElements = new int[columns];

        for (int j = 0; j < columns; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                if (j < array[i].Length && array[i][j] % 2 != 0)
                {
                    lastOddElements[j] = array[i][j];
                }
            }
        }

        return lastOddElements;
    }

    static int FindMaxColumns(int[][] array)
    {
        int maxColumns = 0;

        foreach (var row in array)
        {
            maxColumns = Math.Max(maxColumns, row.Length);
        }

        return maxColumns;
    }

    static void Task4()
    {
        Console.WriteLine("Enter a number of rows: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[][] steppedArray = GenerateRandomSteppedArray(n, -100, 100);
        Console.WriteLine("-----------------------------------------------------------");
        PrintSteppedArray(steppedArray);
        Console.WriteLine("-----------------------------------------------------------");

        int[] lastOddElements = FindLastOddElements(steppedArray);

        Console.WriteLine("\nLast Odd Elements in Each Column:");
        PrintArray(lastOddElements);
    }

    static void PrintSteppedArray(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        //Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Select a Task:");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Task 3");
            Console.WriteLine("4. Task 4");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------");

            switch (choice)
            {
                case "1":
                    Task1();
                    break;

                case "2":
                    Task2();
                    break;

                case "3":
                    Task3();
                    break;

                case "4":
                    Task4();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
