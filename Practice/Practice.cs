namespace LogParse;

internal class Program
{
    public static DateTime GetLogDateTime(string line)
    {

        int start = line.IndexOf(' ');
        int end = line.IndexOf(' ', start + 1);

        string datetimeStr = line.Substring(0, end);

        DateTime dateTime = DateTime.Parse(datetimeStr);
        return dateTime;
    }

    public static string GetLogLevel(string line)
    {
        int start = line.IndexOf('[');
        int end = line.IndexOf(']', start);

        return line.Substring(start + 1, end - start - 1);
    }

    public static string GetLogType(string line)
    {
        int start = line.IndexOf('[', line.IndexOf('[') + 1);
        int end = line.IndexOf(']', start);

        return line.Substring(start + 1, end - start - 1);
    }

    public static string GetLogText(string line)
    {
        int start = line.IndexOf(']');
        int end = line.IndexOf(']', start + 1);

        return line.Substring(end + 1);
    }

    public static (DateTime, string, string, string) GetLogParts(string line)
    {
        return (GetLogDateTime(line), GetLogLevel(line), GetLogType(line), GetLogText(line));
    }

    public static void Main()
    {
        string[] lines = File.ReadAllLines("event_server.log");
        foreach (string line in lines)
        {
            Console.WriteLine(GetLogParts(line));
        }
    }
}