namespace Lesson7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя файла:");
            string path = Console.ReadLine() + ".txt";

            if (!File.Exists(path))
            {
                using (File.Create(path));
            }

            while (true)
            {
                Console.WriteLine($"Меню:\n1 - Ввод текста для записи\n2 - Дополнение текста\n3 - Чтение записанного текста\nВыберите действие:");
                string? textinput = Console.ReadLine();

                if (int.TryParse(textinput, out int menu))
                {
                    switch (menu)
                    {
                        case 1:
                            Writetxt();
                            break;
                        case 2:
                            ReWritetxt();
                            break;
                        case 3:
                            Readtxt();
                            break;
                        default:
                            Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректное значение. Попробуйте снова.");
                }
            }

            void Writetxt()
            {
                Console.WriteLine("Введите текст для записи:");
                string? Text = Console.ReadLine();

                if (!string.IsNullOrEmpty(Text))
                {
                    File.WriteAllText(path, Text);
                }
                else
                {
                    Console.WriteLine("Пустой ввод. Текст не был записан.");
                }
            }

            void ReWritetxt()
            {
                Console.WriteLine("Введите текст для записи:");
                File.AppendAllText(path, Console.ReadLine());
            }

            void Readtxt()
            {
                FileInfo fileInfo = new FileInfo(path);

                if (fileInfo.Length == 0)
                {
                    Console.WriteLine("Файл пустой.");
                }
                else
                {
                    string Text = File.ReadAllText(path);
                    Console.WriteLine("Содержимое файла:");
                    Console.WriteLine(Text);
                }
            }
        }
    }
}

