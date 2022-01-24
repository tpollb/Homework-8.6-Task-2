/// <summary>
/// проверка номера телефона
/// </summary>
long PhoneNumberCheck (string str)
{
    
    string str_rem_spaces = str.Replace(" ", "");
    
    bool flag = long.TryParse(str_rem_spaces, out long result);
    int len = str_rem_spaces.Length;
   
    char first = str_rem_spaces[0];

    if (flag == false || len != 11 || first != '8')
    {
        return 0;
    } else
    {
        return result;
    }
}

Dictionary<long, string> phonebook = new();

Console.WriteLine("Телефонный справочник:");
Console.WriteLine("Введите номер телефона (81234567890)");
string phone = Console.ReadLine();
string name;

/// <summary>
/// ввод данных
/// </summary>
while (string.IsNullOrEmpty(phone) == false)
{
    while (PhoneNumberCheck(phone) == 0)
    {
        Console.WriteLine("Введите номер телефона (81234567890):");
        phone = Console.ReadLine();

        if (string.IsNullOrEmpty(phone) == true)
        {
            break;
        }
    }
    Console.WriteLine("Введите имя:");
    name = Console.ReadLine();

    if (string.IsNullOrEmpty(name) == true)
    {
        break;
    }

    phonebook.Add(PhoneNumberCheck(phone), name);

    phone = "1";
}

Console.WriteLine("Введите номер телефона для поиска (81234567890):");
phone = Console.ReadLine();
while (PhoneNumberCheck(phone) == 0)
{
    Console.WriteLine("Введите номер телефона для поиска (81234567890):");
    phone = Console.ReadLine();

    if (string.IsNullOrEmpty(phone) == true)
    {
        break;
    }
}

string value;
bool flag = phonebook.TryGetValue(PhoneNumberCheck(phone), out value);

if (flag == true)
{
    Console.WriteLine($"Найдена запись: {value}");
} else
{
    Console.WriteLine($"Телефон не найден.");
}


Console.ReadKey();