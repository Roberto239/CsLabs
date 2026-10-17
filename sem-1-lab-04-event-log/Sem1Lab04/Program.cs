namespace Sem1Lab04;

using System;

public class LogEntry
{
    public DateTime Timestamp;
    public string Level = string.Empty;
    public string Category = string.Empty;
    public string Message = string.Empty;
}

public class Program
{

    //Разделение на время, уровень, категорию и текст
    public static LogEntry[] ParseLog(string[] lines)
    {
        LogEntry[] entries = new LogEntry[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            LogEntry entry = new LogEntry();

            string line = lines[i];
                
            int levelStart = line.IndexOf('[');
            int levelEnd = line.IndexOf(']', levelStart);
            int categStart = line.IndexOf('[', levelEnd);
            int categEnd = line.IndexOf(']', categStart);

            entry.Timestamp = DateTime.Parse(line.Substring(0, 23));
            entry.Level = line.Substring(levelStart + 1, levelEnd - levelStart - 1);
            entry.Category = line.Substring(categStart + 1, categEnd - categStart - 1);
            entry.Message = line.Substring(categEnd + 1).TrimStart();

            entries[i] = entry;
        }
        return entries;
    }

    //Фильтрация для возврата записи
    private static LogEntry[] FilterEntries(LogEntry[] entries, Func<LogEntry, bool> condition)
    {
        LogEntry[] temporary = new LogEntry[entries.Length];
        int count = 0;

        foreach (LogEntry entry in entries)
        {
            if (condition(entry))
            {
                temporary[count] = entry;
                count++;
            }
        }

        LogEntry[] result = new LogEntry[count];
        Array.Copy(temporary, result, count);
        return result;
    }

    //Возврат записи даты
    public static LogEntry[] FilterByDate(LogEntry[] entries, DateTime date)
    {
        return FilterEntries(entries, entry => entry.Timestamp.Date == date.Date);
    }

    //Возврат записи уровня
    public static LogEntry[] FilterByLevel(LogEntry[] entries, string level)
    {
        return FilterEntries(entries, entry => entry.Level == level);
    }

    //Возврат записи категории
    public static LogEntry[] FilterByCategory(LogEntry[] entries, string category)
    {
        return FilterEntries(entries, entry => entry.Category == category);
    }

    //Возврат записи текста
    public static LogEntry[] Search(LogEntry[] entries, string text)
    {
        return FilterEntries(entries, entry => entry.Message.Contains(text, StringComparison.OrdinalIgnoreCase));
    }

    //Возврат количества записей переданного уровня
    public static int CountByLevel(LogEntry[] entries, string level)
    {
        int count = 0;

        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i].Level == level)
            {
                count++;
            }
        }

        return count;
    }

    //Возврат состояния сервера
    public static string GetServerStatus(LogEntry[] entries)
    {
        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i].Level == "Fatal" && entries[i].Category == "Server")
            {
                return "КРИТИЧЕСКАЯ ОШИБКА: сервер остановлен";
            }
        }

        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i].Level == "Error")
            {
                return "Есть ошибки: требуется проверка";
            }
        }

        return "Сервер работает штатно";
    }

    //Чтение строк и состояние сервера
    public static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("event_server.log");
        LogEntry[] entries = ParseLog(lines);
        DateTime date = DateTime.Parse("2026-09-02");
        foreach (LogEntry line in FilterByDate(ParseLog(lines), date))
        {
            Console.WriteLine(line.Message);
        }

        Console.WriteLine(GetServerStatus(entries));
    }
}