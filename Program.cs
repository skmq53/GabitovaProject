using System;

class Program
{
    static void Main(string[] args)
    {
        string playerName;
        bool hasFirstArtifact = false;
        bool hasSecondArtifact = false;
        bool hasThirdArtifact = false;
        bool hasKey = false;
        bool hasLockpick = false;
        int ventAttempts = 0;

        // 1. Игрок вводит имя
        Console.WriteLine("Проснитесь! Как ваше имя?");
        playerName = Console.ReadLine();

        // Цикл выбора действий
        while (true)
        {
            Console.WriteLine($"\n{playerName}, что вы хотите сделать?");
            Console.WriteLine("1. Открыть дверь");
            Console.WriteLine("2. Заглянуть под кровать");
            Console.WriteLine("3. Открыть ящик");
            Console.WriteLine("4. Открыть вентиляцию");
            Console.WriteLine("5. Взглянуть на тумбочку");
            Console.WriteLine("6. Взглянуть на статую");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (hasLockpick)
                    {
                        Console.WriteLine($"{playerName}, вы успешно использовали отмычку и открыли дверь. Побег удался!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Дверь заперта, нужно найти способ её открыть.");
                    }
                    break;

                case "2":
                    if (!hasFirstArtifact)
                    {
                        Console.WriteLine($"{playerName}, вы нашли первый артефакт под кроватью!");
                        hasFirstArtifact = true;
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, под кроватью больше ничего нет.");
                    }
                    break;

                case "3":
                    if (hasKey)
                    {
                        if (!hasLockpick)
                        {
                            Console.WriteLine($"{playerName}, вы открыли ящик и нашли отмычку!");
                            hasLockpick = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, ящик уже пуст.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, ящик заперт. Нужно найти ключ.");
                    }
                    break;

                case "4":
                    ventAttempts++;
                    if (ventAttempts >= 3)
                    {
                        if (!hasSecondArtifact)
                        {
                            Console.WriteLine($"{playerName}, после нескольких попыток вы открыли вентиляцию и нашли второй артефакт!");
                            hasSecondArtifact = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, в вентиляции больше ничего нет.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, вентиляция не открывается. Попробуйте ещё раз.");
                    }
                    break;

                case "5":
                    if (!hasThirdArtifact)
                    {
                        Console.WriteLine($"{playerName}, на тумбочке лежит третий артефакт.");
                        hasThirdArtifact = true;
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, на тумбочке больше ничего нет.");
                    }
                    break;
                case "6":
                    if (hasFirstArtifact && hasSecondArtifact && hasThirdArtifact)
                    {
                        if (!hasKey)
                        {
                            Console.WriteLine($"{playerName}, статуя активирована! Вы получили ключ от ящика.");
                            hasKey = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, статуя уже активирована.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, для активации статуи нужны три артефакта.");
                    }
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}