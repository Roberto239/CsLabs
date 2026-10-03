namespace Sem1Lab01;
class Program
{
    static void Main()
    {
        // Данные
        decimal GameVersion = 1.43m;
        string ServerTime = "04:32:15";
        float Ping = 90.2f;
        ushort PlayersCount = 65_535;
        string ServerStatus = "Заполнен";
        string LastUpdate = "18/09/2026";

        // Входной экран
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("       Добро пожаловать в игру!       ");
        Console.WriteLine($"          Версия игры: {GameVersion} ");
        Console.WriteLine("--------------------------------------");

        // Выбор сервера
        Console.WriteLine("---------------Сервер 1---------------");
        Console.WriteLine($"Время работы сервера: {ServerTime}");
        Console.WriteLine($"Пинг: {Ping} мс");
        Console.WriteLine($"Количество игроков на сервере: {PlayersCount}");
        Console.WriteLine($"Состояние сервера: {ServerStatus}");
        Console.WriteLine($"Поcледнее обновление: {LastUpdate}");
    }
}