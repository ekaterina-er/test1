// See https://aka.ms/new-console-template for more information



// Задание 4

string[] arr = new string[3];
int warn = 0;       //счетчик кол-ва ошибок пользователя
int count = 0;   //счетчик кол-ва чисел в массиве

while (true)
{
    Console.WriteLine($"Меню: \nПродолжить - 1 \nОчистить - 2 \nВыйти - 3 ");
    int num = int.Parse(Console.ReadLine());
    switch (num)
    {
        case 1:
            InputNumbers();
            break;
        case 2:
            ClearArray();
            break;
        case 3:
            PrintArray();
            break;
    }
}

void InputNumbers()
{
    
    Console.WriteLine("Выполните ввод чисел:");

    while (true)
    {
        if (count == arr.Length)
        {
            var temp = new string[arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
            {
                temp[i] = arr[i];
            }
            arr = temp;
            Console.WriteLine("Массив увеличен до " + arr.Length);
        }
        string input = Console.ReadLine();

        if (input.ToLower() == "q")
        {
            break;
        }
        else if (int.TryParse(input, out int number))
        {
            arr[count] = input;
            count++;
        }
        else
        {
            warn++;
            Console.WriteLine("Ошибка: введите корректное число или 'q' для выхода.");
        }
    }
    PrintArray();
}

void ClearArray()
{
    Array.Clear(arr, 0, arr.Length);
    count = 0;
}

void PrintArray()
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i] + " ");
    }
    Console.WriteLine();
}
