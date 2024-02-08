using System;

public class Lab1
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

    static void Task2() { }

    static void Task3() { }

    static void Task4() { }

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
