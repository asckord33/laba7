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

}