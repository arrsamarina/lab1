using System;

class Program

//LAB 1
{
    static void Main()

    //FIRST PART
    {
        double[] arr = { 2.0, 0.0, -3.5, 5.0, 7.0, 0.0, -2.0, 8.0, 0.0, 1.0 };

        // TASK 1.1: MINIMUM ARRAY ELEMENT
        double minElement = arr.Min();

        // TASK 1.2: THE SUM OF THE ARRAY ELEMENTS LOCATED BETWEEN THE FIRST AND LAST POSITIVE ELEMENTS
        int firstPositiveIndex = -1;
        int lastPositiveIndex = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > 0)
            {
                if (firstPositiveIndex == -1)
                {
                    firstPositiveIndex = i;
                }
                lastPositiveIndex = i;
            }
        }

        double sumBetweenPositives = 0.0;

        if ((firstPositiveIndex != -1) && (lastPositiveIndex != -1))
        {
            sumBetweenPositives = arr.Skip(firstPositiveIndex + 1)
                                     .Take(lastPositiveIndex - firstPositiveIndex - 1)
                                     .Sum();
        }

        double[] zeroElements = arr.Where(x => x == 0.0).ToArray();
        double[] nonZeroElements = arr.Where(x => x != 0.0).ToArray();

        double[] newArray = zeroElements.Concat(nonZeroElements).ToArray();

        // RESULT OF THE FIRST PART
        Console.WriteLine("Минимальный элемент: " + minElement);
        Console.WriteLine("Сумма между первым и последним положительными элементами: " + sumBetweenPositives);
        Console.WriteLine("Массив после преобразования: [" + string.Join(", ", newArray) + "]");



        // SECOND PART
        //TASK 2.1: THE SUM OF THE ELEMENTS IN THE ROWS OF AN INTEGER RECTANGULAR MATRIX THAT CONTAIN AT LEAST ONE NEGATIVE ELEMENT
        int[,] matrix = {
            {1, -12, 3, 4},
            {-1, -10, 6, 8},
            {-1, -13, 9, 3},
        };

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int sum = 0;

        for (int i = 0; i < rows; i++)
        {
            bool hasNegative = false;

            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < 0)
                {
                    hasNegative = true;
                    break; // Если найден отрицательный элемент, можно прекратить проверку в данной строке
                }
            }

            if (hasNegative)
            {
                for (int j = 0; j < cols; j++)
                {
                    sum += matrix[i, j];
                }
            }
        }


        //TASK 2.2: ROW AND COLUMS NUMBERS OF ALL SADDLE POINTS OF AN INTEGER RECTAGULAR MATRIX
        //Создаём список, в котором будут храниться координаты седловых точек (строка и столбец)
        List<Tuple<int, int>> saddlePoints = new List<Tuple<int, int>>();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int currentElement = matrix[i, j];
                bool isSaddlePoint = true; // предполагааем, что это седловая точка

                // Проверяем, является ли текущий элемент минимальным в своей строке
                for (int k = 0; k < cols; k++)
                {
                    if (currentElement > matrix[i, k])
                    {
                        isSaddlePoint = false;
                        break;
                    }
                }

                // Проверяем, является ли текущий элемент максимальным в своем столбце
                for (int k = 0; k < rows; k++)
                {
                    if (currentElement < matrix[k, j])
                    {
                        isSaddlePoint = false;
                        break;
                    }
                }

                if (isSaddlePoint)
                {
                    saddlePoints.Add(new Tuple<int, int>(i, j));
                }
            }
        }

        //RESULT OF THE SECOND PART

        Console.WriteLine("Сумма элементов в строках с отрицательными элементами: " + sum);

        Console.WriteLine("Седловые точки матрицы:");

        foreach (var point in saddlePoints)
        {
            Console.WriteLine($"Строка {point.Item1}, Столбец {point.Item2}");
        }
    }
}