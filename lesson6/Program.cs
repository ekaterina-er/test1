using Lesson6;
using System;
using System.Reflection.Emit;

namespace Lesson6
{
    internal class Program
    {
        private List<Bird> chickens = new List<Bird>(); 
        private List<Bird> turkeys = new List<Bird>(); 
        private int feedSupply = 30;                    
        private int eggSupplyChickens = 0;
        private int eggSupplyTurkeys = 0;              
        private int poultryMeatChickens = 0;
        private int poultryMeatTurkeys = 0;

        public Program(int numberOfChickens, int numberOfTurkeys)
        {
            // Инициализация списка куриц и индюков, разделенных на группы для яиц и для мяса
            chickens.AddRange(Enumerable.Range(0, numberOfChickens).Select(i => new Chicken { IsForEggs = i < numberOfChickens / 2 }));
            turkeys.AddRange(Enumerable.Range(0, numberOfTurkeys).Select(i => new Turkey { IsForEggs = i < numberOfTurkeys / 2 }));
        }

        // Метод для кормления выбранной птицы (курицы или индюка)
        private void Feed(string birdType, List<int> indices)
        {
            foreach (var index in indices)
            {
                if (birdType == "chickens")
                {
                    if (index >= 0 && index < chickens.Count) 
                    {
                        var chicken = chickens[index];
                        if (chicken.IsAlive && feedSupply > 0) 
                        {
                            chicken.UpdateHunger();
                            feedSupply--;
                            Console.WriteLine($"Курица {index + 1} покормлена.");
                        }
                        else
                        {
                            Console.WriteLine("Эта курица не может быть покормлена.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный индекс курицы.");
                    }
                }
                else if (birdType == "turkeys")
                {
                    if (index >= 0 && index < turkeys.Count)
                    {
                        var turkey = turkeys[index];
                        if (turkey.IsAlive && feedSupply > 0) 
                        {
                            turkey.UpdateHunger();
                            feedSupply--;
                            Console.WriteLine($"Индюк {index + 1} покормлен.");
                        }
                        else
                        {
                            Console.WriteLine("Этот индюк не может быть покормлен.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный индекс индюка.");
                    }
                }
            }
        }

        // Метод для сбора всех яиц
        public void CollectEggs()
        {
            foreach (Chicken chicken in chickens)
            {
                if (chicken.IsAlive && chicken.IsForEggs)
                {
                    eggSupplyChickens += chicken.ProduceEggs();
                }
            }
            Console.WriteLine($"Собрано яиц курицы: {eggSupplyChickens}");
            foreach (Turkey turkey in turkeys)
            {
                if (turkey.IsAlive && turkey.IsForEggs)
                {
                    eggSupplyTurkeys += turkey.ProduceEggs();
                }
            }
            Console.WriteLine($"Собрано яиц индейки: {eggSupplyTurkeys}");
        }
        // Метод для резки птиц
        public void KillBirds(string birdType, List<int> indices)
        {
            foreach (var index in indices)
            {
                if (birdType == "chickens")
                {
                    if (index >= 0 && index < chickens.Count) 
                    {
                        var chicken = chickens[index];
                        chicken.IsAlive = false;
                    }
                    else
                    {
                        Console.WriteLine("Неверный индекс курицы.");
                    }
                }
                else if (birdType == "turkeys")
                {
                    if (index >= 0 && index < turkeys.Count)
                    {
                        var turkey = turkeys[index];
                        turkey.IsAlive = false;
                    }
                    else
                    {
                        Console.WriteLine("Неверный индекс индюка.");
                    }
                }
            }
        }

        // Метод для сбора мяса 
        public void CollectMeat()
        {
            foreach (Chicken chicken in chickens)
            {
                if (!chicken.IsAlive && !chicken.IsForEggs)
                {
                    poultryMeatChickens += chicken.GetMeat();
                }
            }
            Console.WriteLine($"Собрано мяса курицы: {poultryMeatChickens}");
            foreach (Turkey turkey in turkeys)
            {
                if (!turkey.IsAlive && !turkey.IsForEggs)
                {
                    poultryMeatTurkeys += turkey.GetMeat();
                }
            }
            Console.WriteLine($"Собрано мяса индейки: {poultryMeatTurkeys}");
        }

        // Основной метод для взаимодействия с пользователем
        static void Main(string[] args)
        {
            var program = new Program(10, 10); // Создаем экземпляр Program с 10 курицами и 10 индюками

            while (true)
            {
                Console.WriteLine("Выберите действие: 1 - Покормить птиц, 2 - Собрать яйца, 3 - Собрать мясо, 4 - Выйти");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Кого покормить? Введите 'chickens' для куриц или 'turkeys' для индюков:");
                        var birdType = Console.ReadLine();

                        Console.WriteLine("Введите номера птиц через запятую от 1 до 10(например, 1,3,5):");
                        var input = Console.ReadLine();

                        var indices = input.Split(',')
                                           .Select(s => int.TryParse(s.Trim(), out int i) ? i - 1 : -1)
                                           .Where(i => i >= 0)
                                           .ToList();
                        if (indices.Any())
                        {
                            // Вызываем метод Feed с выбранным типом птицы и списком индексов.
                            program.Feed(birdType, indices);
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод номеров.");
                        }
                        break;
                    case "2":
                        program.CollectEggs();
                        break;

                    case "3":
                        Console.WriteLine("Кого убить? Введите 'chickens' для куриц или 'turkeys' для индюков:");
                        var birdType2 = Console.ReadLine();

                        Console.WriteLine("Введите номера птиц через запятую от 6 до 10(например, 6,8,10):");
                        var input2 = Console.ReadLine();

                        var indices2 = input2.Split(',')                                          
                                           .Select(s => int.TryParse(s.Trim(), out int i) ? i - 1 : -1)                                        
                                           .Where(i => i >= 0)                                         
                                           .ToList();                       
                        if (indices2.Any())
                        {                           
                            program.KillBirds(birdType2, indices2);
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод номеров.");
                        }
                        program.CollectMeat();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }
            }
        }
    }
}
