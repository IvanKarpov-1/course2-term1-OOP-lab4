using System;

namespace Lab4
{
    public class ConsoleMenu
    {
        private readonly DigitCounter _counter;
        private readonly MyStack _stack;

        public ConsoleMenu()
        {
            _counter = new DigitCounter();
            _stack = new MyStack();
        }

        public void Start()
        {
            var isWorking = true;
            var isShowListOfCommands = true;

            while (isWorking)
            {
                if (isShowListOfCommands)
                {
                    Console.Clear();
                    Console.WriteLine("Виберіть частину завдання:\n" +
                                      "1 - Підрахунок кількості цифр у рядку;\n" +
                                      "2 - Робота зі стеком.\n\n" +
                                      "3 - Для виходу з програми.\n");
                }

                var number = Console.ReadKey(true).KeyChar;

                switch (number)
                {
                    case '1':
                    {
                        Console.Clear();
                        DigitCounterMenu();
                        isShowListOfCommands = true;
                        break;
                    }
                    case '2':
                    {
                        Console.Clear();
                        StackMenu();
                        isShowListOfCommands = true;
                        break;
                    }
                    case '3':
                    {
                        isWorking = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Команда введена невірно! Спробуйте ще раз");
                        isShowListOfCommands = false;
                        break;
                    }
                }
            }
        }

        private void DigitCounterMenu()
        {
            var isWorking = true;
            var rowCount = 9;
            var isFirstShowOfCommandsList = true;

            while (isWorking)
            {
                if (rowCount > 25 || isFirstShowOfCommandsList)
                {
                    Console.WriteLine("Виберіть спосіб для підрахунку кількості цифр в рядку, а потім введіть рядок.\n" +
                                      "Способи:\n" +
                                      "1 - анонімним методом;\n" +
                                      "2 - лямбда виразом.\n\n" +
                                      "3 - Назад.\n");
                    rowCount = 9;
                    isFirstShowOfCommandsList = false;
                }

                var number = Console.ReadKey(true).KeyChar;

                switch (number)
                {
                    case '1':
                    {
                        Console.Write("Рядок: ");
                        var str = Console.ReadLine();
                        var count = _counter.GetDigitCountByAnonymousMethod(str);
                        Console.WriteLine($"Кількість цифр в рядку - {count}");
                        rowCount += 2;
                        break;
                    }
                    case '2':
                    {
                        Console.Write("Рядок: ");
                        var str = Console.ReadLine();
                        var count = _counter.GetDigitCountByLambdaExpression(str);
                        Console.WriteLine($"Кількість цифр в рядку - {count}");
                        rowCount += 2;
                        break;
                    }
                    case '3':
                    {
                        isWorking = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Команда введена невірно! Спробуйте ще раз");
                        rowCount++;
                        break;
                    }
                }

                rowCount++;
                Console.WriteLine();
            }
        }

        private void StackMenu()
        {
            var isWorking = true;
            var rowCount = 9;
            var isFirstShowOfCommandsList = true;
            _stack.StackCleared += ShowMessage;

            while (isWorking)
            {
                if (rowCount > 25 || isFirstShowOfCommandsList)
                {
                    Console.Clear();
                    Console.WriteLine("Виберіть дію зі стеком:\n" +
                                      "1 - Показати кількість елементів в стеку;\n" +
                                      "2 - Додати символ до стеку;\n" +
                                      "3 - Додати рядок до стеку;\n" +
                                      "4 - Показати перший елемент стеку;\n" +
                                      "5 - Дістати перший елемент стеку;\n" +
                                      "6 - Очистити стек;\n\n" +
                                      "7 - Назад.\n");
                    rowCount = 9;
                    isFirstShowOfCommandsList = false;
                }

                var number = Console.ReadKey(true).KeyChar;

                switch (number)
                {
                    case '1':
                    {
                        Console.WriteLine($"Кількість елементів стеку - {_stack.Size}");
                        rowCount++;
                        break;
                    }
                    case '2':
                    {
                        Console.Write("Введіть символ для додавання до стеку: ");
                        var ch = Console.ReadLine()?[0];
                        _stack.Push(ch ?? ' ');
                        Console.WriteLine("Символ записано");
                        rowCount += 2;
                        break;
                    }
                    case '3':
                    {
                        Console.Write("Введіть рядок для додавання до стеку: ");
                        var str = Console.ReadLine();
                        _stack.Push(str);
                        Console.WriteLine("Рядок записано");
                        rowCount += 2;
                        break;
                    }
                    case '4':
                    {
                        Console.WriteLine($"Перший елемент стеку - {_stack.Peek()}");
                        rowCount++;
                        break;
                    }
                    case '5':
                    {
                        Console.WriteLine($"Перший елемент стеку - {_stack.Pop()}");
                        rowCount++;
                        break;
                    }
                    case '6':
                    {
                        _stack.Clear();
                        rowCount++;
                        break;
                    }
                    case '7':
                    {
                        isWorking = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Команда введена невірно! Спробуйте ще раз");
                        rowCount++;
                        break;
                    }
                }

                rowCount++;
                Console.WriteLine();
            }

            _stack.StackCleared -= ShowMessage;
        }

        public void ShowMessage(object sender, StackClearedEventArgs args)
        {
            Console.WriteLine(args.Message);
        }
    }
}