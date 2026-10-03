namespace Sem1Lab02;

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество игроков на сервере: ");
        int PlayersCount = int.Parse(Console.ReadLine());

        Console.Write("Введите доступное количество оперативной памяти: ");
        int Memory = int.Parse(Console.ReadLine());

        Console.Write("Сервер публичный? (Да/Нет): ");
        string bufferPublic = Console.ReadLine();
        bool Public = bufferPublic == "Да" || bufferPublic == "да";

        Console.Write("Сервер защищён паролем? (Да/Нет): ");
        string bufferPassword = Console.ReadLine();
        bool Password = bufferPassword == "Да" || bufferPassword == "да";

        var result = CheckConfiguration(PlayersCount, Memory, Public, Password);
        Console.WriteLine(result);
    }
    public static string CheckConfiguration(int PlayersCount, int Memory, bool Public, bool Password)
    {
        if (PlayersCount == 0) return "Запуск невозможен: количество игроков должно быть больше нуля.";
        else if (PlayersCount > 50 && Memory < 8) return "Запуск возможен с предупреждением: для такого количества игроков рекомендуется больше оперативной памяти.";
        else if (Memory < 4) return "Запуск невозможен: серверу недостаточно оперативной памяти.";
        else if (Public && Password) return "Запуск возможен с предупреждением: публичный сервер защищён паролем.";
        return "Сервер готов к запуску.";
    }
}