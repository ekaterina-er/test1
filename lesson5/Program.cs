//Задание 5

int[] arr = new int[3];
int count = 0;

Console.WriteLine("Введите числа, для завершения введите значение '0'");
while (true)
{
    if (count == arr.Length)
    {
        Array.Resize(ref arr, arr.Length * 2);
        //Console.WriteLine("Массив увеличен до " + arr.Length);
    }
    if (int.TryParse(Console.ReadLine(), out int num))
    {
        if (num == 0)
        {
            break;
        }
        bool prnum = true;
        if (num > 1)
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    prnum = false;
                }
            }
            if (prnum)
            {
                arr[count] = num;
                count++;
            }
        }
    }
    else Console.WriteLine("Введено некорректное значение. Поробуйте ещё раз.");
}
Console.WriteLine("Введите порядковый номер");
int number = int.Parse(Console.ReadLine()) - 1;
Console.Write(arr[number]);