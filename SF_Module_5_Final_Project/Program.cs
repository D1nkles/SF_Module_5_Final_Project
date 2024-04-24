class Program
{
    static (string name, string surname, int age, bool hasPet, int petAmount, string[] petNames, int favColorAmount, string[] favColors) CreateCortage()
    {
        (string name, string surname, int age, bool hasPet, int petAmount, string[] petNames, int favColorAmount, string[] favColors) User;

        Console.Write(">>Введите имя пользователя: ");
        User.name = Console.ReadLine();

        Console.Write(">>Введите фамилию пользователя: ");
        User.surname = Console.ReadLine();

        Console.Write(">>Введите возраст пользователя в формате целого числа: ");
        string strAge = Console.ReadLine();
        User.age = numCheck(strAge);

        string strHasPet;
        bool inputWrong = true;
        User.hasPet = false;
        while (inputWrong)
        {
            Console.Write(">>Есть ли у пользователя питомец? Ответ напишите в формате 'Да', 'Нет': ");
            strHasPet = Console.ReadLine();

            if (strHasPet.ToLower() == "да")
            {
                User.hasPet = true;
                inputWrong = false;
            }
            else if (strHasPet.ToLower() == "нет")
            {
                User.hasPet = false;
                inputWrong = false;
            }
            else
            {
                Console.WriteLine(">>Вы ввели ответ в неверном формате, попробуйте снова... ");
            }
        }

        string strPetAmount;
        User.petAmount = 0;
        User.petNames = null;
        if (User.hasPet)
        {
            Console.Write(">>Введите кол-во питомцев пользователя в формате целого числа: ");
            strPetAmount = Console.ReadLine();
            User.petAmount = numCheck(strPetAmount);

            Console.WriteLine(">>Введите клички питомцев: ");
            User.petNames = arrayFill(User.petAmount);
        }

        Console.Write(">>Введите кол-во любимых цветов пользователя: ");
        string strFavColorAmount = Console.ReadLine();
        User.favColorAmount = numCheck(strFavColorAmount);

        Console.WriteLine(">>Введите любимые цвета: ");
        User.favColors = arrayFill(User.favColorAmount);

        return User;
    }
    static int numCheck(string _unchecked)
    {
        while (true)
        {
            if (int.TryParse(_unchecked, out int _checked) && _checked > 0)
            {
                return _checked;
            }
            else
            {
                Console.WriteLine(">>Вы ввели данные в неверном формате, попробуйте снова...");
                Console.Write(">>Введите целочисленное значение, обозначающее запрошенные у вас ранее данные: ");
                _unchecked = Console.ReadLine();
            }
        }
    }
    static string[] arrayFill(int elementsAmount)
    {
        string[] array = new string[elementsAmount];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{i + 1}. ");
            string element = Console.ReadLine();
            array[i] = element;
        }
        return array;
    }

    static void OutputCortage((string name, string surname, int age, bool hasPet, int petAmount, string[] petNames, int favColorAmount, string[] favColors) User)
    {
        Console.WriteLine($">>Имя пользователя: {User.name}.\n" +
                          $">>Фамилия пользователя: {User.surname}.\n" +
                          $">>Возраст пользователя: {User.age}.");

        if (User.hasPet)
        {
            Console.Write($">>У пользователя есть {User.petAmount} ");
            int inclPetCheck = User.petAmount % 10;
            if ((inclPetCheck >= 5 && inclPetCheck <= 9))
            {
                Console.WriteLine("питомцев:");
            }
            else if (inclPetCheck == 1)
            {
                Console.WriteLine("питомец:");
            }
            else if (inclPetCheck >= 2 || inclPetCheck <= 4)
            {
                Console.WriteLine("питомца:");
            }

            for (int i = 0; i < User.petNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {User.petNames[i]}.");
            }
        }
        else
            Console.WriteLine(">>У пользователя нет питомцев.");

        Console.Write($">>У пользователя {User.favColorAmount} ");
        int inclColorCheck = User.favColorAmount % 10;
        if ((inclColorCheck >= 5 && inclColorCheck <= 9))
        {
            Console.WriteLine("любимых цветов:");
        }
        else if (inclColorCheck == 1)
        {
            Console.WriteLine("любимый цвет:");
        }
        else if (inclColorCheck >= 2 || inclColorCheck <= 4)
        {
            Console.WriteLine("любимых цвета:");
        }

        for (int i = 0; i < User.favColors.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {User.favColors[i]}.");
        }
    }
    static void Main(string[] args)
    {
        var User = CreateCortage();
        Console.WriteLine();
        OutputCortage(User);
    }
}