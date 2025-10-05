using System;
class Program
{
    static void Main(string[] args)
    {
        var userData = GetUserData();
        DisplayUserData(userData);
    }
    static (string Name, string Surname, int Age, bool Hasper, int PetCount, string[] PetNames, int ColorCount, string[] FavoriteColors) GetUserData()
    {
        Console.WriteLine("=== Заполнение данных пользователя ===");

        Console.Write("Введите имя:");
        string name = Console.ReadLine();

        Console.WriteLine("Введите фамилию:");
        string surname = Console.ReadLine();

        int age = GetPositiveNumber("Введите возрост:");

        bool hasPet = GetYesNoAnswer("Есть ли у васпитомец?(да/нет):");

        int petCount = 0;
        string[] petNames = Array.Empty<string>();

        if (hasPet)
        {
            petCount = GetPositiveNumber("Введите количество питомцев:");
            petNames = GetPetName(petCount);
        }
        int colorCount = GetPositiveNumber("Введите количество любимых цветов:");
        string[] favoriteColor = GetFavoriteColors(colorCount);

        return (name, surname, age, hasPet, petCount, petNames, colorCount, favoriteColor);
    }
    static int GetPositiveNumber(string message)
    {
        int number;
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (int.TryParse(input, out number) && number > 0)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Ошибка! Введите целое число больше 0.");
            }
        }
    }
    static bool GetYesNoAnswer(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine().ToLower();
            if (input == "да" || input == "д" || input == "yes" || input == "у")
            {
                return true;
            }
            else if (input == "нет" || input == "н" || input == "no" || input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Ошибка! Введите 'да' или 'нет'.");
            }
        }
    }
    static string[] GetPetName(int count)
    {
        string[] names = new string[count];

        Console.WriteLine($"Введите клички {count} питомцев:");
        for (int i = 0; i < count; i++)
        {
            Console.Write("$ Кличка питомца {i + 1}:");
            names[i] = Console.ReadLine();
        }
        return names;
    }
    static string[] GetFavoriteColors(int count)
    {
        string[] colors = new string[count];

        Console.WriteLine($"Введите {count} любимых цветов:");
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Цвет{i + 1}:");
            colors[i] = Console.ReadLine();
        }
        return colors;
    }
    static void DisplayUserData((string Name, string Surname, int Age, bool Haspet, int PetCount, string[] PetNames, int ColorCount, string[] FavoriteColors) userData)
    {
        {
            Console.WriteLine("\n=== ВАШИ ДАННЫЕ ===");
            Console.WriteLine($"Имя : {userData.Name}");
            Console.WriteLine($"Фамилия: {userData.Surname}");
            Console.WriteLine($"Возраст: {userData.Age}");

            if (userData.Haspet)
            {
                Console.WriteLine($"Количество питомцев: {userData.PetCount}:");
                Console.WriteLine("Количество питомцев:");
                foreach (string name in userData.PetNames)
                {
                    Console.WriteLine($" - {name}");
                }
            }
            else
            {
                Console.WriteLine("Питомцев нет");
            }
            Console.WriteLine($"Количество любимых цветов: {userData.ColorCount}");
            Console.WriteLine("Любимые цвета:");
            foreach (string color in userData.FavoriteColors)
            {
                Console.WriteLine($" - {color}");
            }
        }
    }
}

           
    


