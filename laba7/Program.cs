using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("Выберите задачу:");
            Console.WriteLine("1. Лайнландия (*)");
            Console.WriteLine("2. Очередь (Queue) (*)");
            Console.WriteLine("3. Решение уравнений (*)");
            Console.WriteLine("4. Карточная игра (*)");
            Console.WriteLine("5. Класс Rectangle (*)");
            Console.WriteLine("6. Минимальный вес еды (**)");
            Console.WriteLine("7. Компоненты связности (**)");
            Console.WriteLine("8. Кафе (Купоны) (***)");
            Console.WriteLine("0. Выход");
            Console.WriteLine("=========================================");
            Console.Write("Ваш выбор: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    RunTask("Лайнландия", Task1);
                    break;
                case "2":
                    RunTask("Очередь (Queue)", Task2);
                    break;
                case "3":
                    RunTask("Решение уравнений", Task3);
                    break;
                case "4":
                    RunTask("Карточная игра", Task4);
                    break;
                default:
                    Console.WriteLine("Неверный выбор! Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void RunTask(string taskName, Action taskMethod)
    {
        Console.Clear();
        Console.WriteLine($"========== {taskName} ==========");
        Console.WriteLine("Введите входные данные (следуйте формату задачи):");
        Console.WriteLine("(Для завершения ввода используйте Ctrl+Z или введите пустую строку где необходимо)");
        Console.WriteLine();

        try
        {
            taskMethod();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при выполнении задачи: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("=========================================");
        Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }


    // Задача 1: Лайнландия

    static void Task1()
    {
        Console.Write("Введите количество городов N: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input)) return;

        int N = int.Parse(input);

        Console.Write($"Введите {N} цен через пробел: ");
        string? pricesLine = Console.ReadLine();
        if (string.IsNullOrEmpty(pricesLine)) return;

        string[] pricesStr = pricesLine.Split(' ');
        int[] prices = new int[N];
        for (int i = 0; i < N; i++)
        {
            prices[i] = int.Parse(pricesStr[i]);
        }

        Console.Write("Результат: ");
        for (int i = 0; i < N; i++)
        {
            int result = -1;
            for (int j = i + 1; j < N; j++)
            {
                if (prices[j] < prices[i])
                {
                    result = j;
                    break;
                }
            }
            Console.Write(result + (i == N - 1 ? "" : " "));
        }
        Console.WriteLine();
    }
    // Задача 2: Очередь (Queue)

    static void Task2()
    {
        Queue<int> queue = new Queue<int>();
        Console.WriteLine("Введите команды (push n, pop, front, size, clear, exit):");
        string? command;

        while ((command = Console.ReadLine()) != null)
        {
            if (string.IsNullOrEmpty(command)) continue;

            string[] parts = command.Split(' ');
            string cmd = parts[0];

            if (cmd == "push")
            {
                if (parts.Length > 1)
                {
                    int n = int.Parse(parts[1]);
                    queue.Enqueue(n);
                    Console.WriteLine("ok");
                }
            }
            else if (cmd == "pop")
            {
                if (queue.Count == 0)
                    Console.WriteLine("error");
                else
                    Console.WriteLine(queue.Dequeue());
            }
            else if (cmd == "front")
            {
                if (queue.Count == 0)
                    Console.WriteLine("error");
                else
                    Console.WriteLine(queue.Peek());
            }
            else if (cmd == "size")
            {
                Console.WriteLine(queue.Count);
            }
            else if (cmd == "clear")
            {
                queue.Clear();
                Console.WriteLine("ok");
            }
            else if (cmd == "exit")
            {
                Console.WriteLine("bye");
                break;
            }
        }
    }

    // Задача 3: Решение уравнений (params)

    static void Task3()
    {
        Console.Write("Введите коэффициенты уравнения через пробел (1-3 числа): ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input)) return;

        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double[] coefficients = new double[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            coefficients[i] = double.Parse(parts[i]);
        }

        double[] roots = Solve(coefficients);
        Console.Write("Корни уравнения: ");
        Print(roots);
    }

    static double[] Solve(params double[] coefficients)
    {

        if (coefficients.Length == 3)
        {
            double a = coefficients[0];
            double b = coefficients[1];
            double c = coefficients[2];
            double discriminant = b * b - 4 * a * c;

            if (a == 0)
            {
                if (b == 0) return new double[0];
                return new double[] { -c / b };
            }
            if (discriminant < 0) return new double[0];
            if (Math.Abs(discriminant) < 1e-10) return new double[] { -b / (2 * a) };

            double sqrtD = Math.Sqrt(discriminant);
            double x1 = (-b - sqrtD) / (2 * a);
            double x2 = (-b + sqrtD) / (2 * a);
            return new double[] { Math.Min(x1, x2), Math.Max(x1, x2) };
        }

        else if (coefficients.Length == 2)
        {
            double b = coefficients[0];
            double c = coefficients[1];
            if (Math.Abs(b) < 1e-10) return new double[0];
            return new double[] { -c / b };
        }

        else if (coefficients.Length == 1)
        {
            double c = coefficients[0];
            if (Math.Abs(c) < 1e-10) return new double[] { 0 };
            return new double[0];
        }
        return new double[0];
    }

    static void Print(params double[] roots)
    {
        if (roots.Length == 0)
        {
            Console.WriteLine("нет корней");
            return;
        }

        Array.Sort(roots);
        for (int i = 0; i < roots.Length; i++)
        {
            Console.Write(roots[i].ToString("0.##") + (i == roots.Length - 1 ? "" : " "));
        }
        Console.WriteLine();
    }

    // Задача 4: Карточная игра (Queue)

    static void Task4()
    {
        Console.Write("Введите карты первого игрока (3 числа через пробел): ");
        string? firstInput = Console.ReadLine();

        Console.Write("Введите карты второго игрока (3 числа через пробел): ");
        string? secondInput = Console.ReadLine();

        if (string.IsNullOrEmpty(firstInput) || string.IsNullOrEmpty(secondInput)) return;

        string[] firstCards = firstInput.Split(' ');
        string[] secondCards = secondInput.Split(' ');

        Queue<int> first = new Queue<int>();
        Queue<int> second = new Queue<int>();

        for (int i = 0; i < 3; i++)
        {
            first.Enqueue(int.Parse(firstCards[i]));
            second.Enqueue(int.Parse(secondCards[i]));
        }

        int moves = 0;

        while (moves < 100 && first.Count > 0 && second.Count > 0)
        {
            moves++;
            int card1 = first.Dequeue();
            int card2 = second.Dequeue();

            if (card1 > card2)
            {
                first.Enqueue(card1);
                first.Enqueue(card2);
            }
            else
            {
                second.Enqueue(card1);
                second.Enqueue(card2);
            }
        }

        if (first.Count == 0)
            Console.WriteLine("second " + moves);
        else
            Console.WriteLine("first " + moves);
    }


}