namespace Sem1Lab03;

public class Program
{

    public static string BuildReport(string[] lines)
    {

        //Название ивента
        static string getEventName(string[] lines)
        {
            foreach (string line in lines)
            {
                if (line.Contains("Событие началось:"))
                {
                    int nameStart = line.IndexOf("ь:");
                    string eventName = line.Substring(nameStart + 2);
                    return eventName;
                }
            }
            return "";
        }

        //Время начала
        static string getEventTime(string[] lines)
        {
            foreach (string line in lines)
            {
                if (line.Contains("Событие началось:"))
                {
                    int timeEnd = line.IndexOf("[") - 1;
                    string dateTimeStr = line.Substring(0, timeEnd);
                    DateTime dateTime = DateTime.Parse(dateTimeStr);
                    return dateTime.ToString("dd.MM.yyyy");
                }
            }
            return "";
        }

        //Победители
        static string getWinnerTeam(string[] lines)
        {
            foreach (string line in lines)
            {
                if (line.Contains("объявлены победителями события"))
                {
                    int winnerFirst = line.IndexOf(']') + 1;
                    int winnerStart = line.IndexOf(']', winnerFirst) + 1;
                    int winnerSecond = line.IndexOf(" ", winnerFirst);
                    int winnerLen = line.IndexOf("объявлены") - winnerSecond;
                    string winnerTeam = line.Substring(winnerStart, winnerLen);
                    return winnerTeam;
                }
            }
            return "";
        }

        //Счёт победителя
        static string getWinnerScore(string[] lines)
        {
            foreach (string line in lines)
            {
                if (line.Contains("очков события"))
                {
                    int scoreStart = line.IndexOf("и");
                    int scoreEnd = line.IndexOf("очков");
                    string winnerScore = line.Substring(scoreStart + 3, scoreEnd - scoreStart - 4);
                    return winnerScore;
                }
            }
            return "";
        }

        //Ивентовый предмет
        static string getEventItem(string[] lines)
        {
            foreach (string line in lines)
            {
                if (line.Contains("получили ивентовый предмет:"))
                {
                    int itemStart = line.IndexOf("т:");
                    string eventItem = line.Substring(itemStart + 2);
                    return eventItem;
                }
            }
            return "";
        }

        //Проигравшие
        static string getLoserTeam(string[] lines)
        {
            foreach (string line in lines)
            {
                if (line.Contains("утешительную награду:"))
                {
                    int loserStart = line.IndexOf("d]");
                    int loserEnd = line.IndexOf("получили");
                    int loserLen = loserEnd - loserStart;
                    string loserTeamName = line.Substring(loserStart + 3, loserLen - 11) + "х";
                    string loserTeamSubname = line.Substring(loserStart + 11, loserLen - 13) + "ов";
                    return loserTeamName + loserTeamSubname;
                }
            }
            return "";
        }

        //Утешитильный приз
        static string getComfortPrize(string[] lines)
        {
            foreach (string line in lines)
            {
                if (line.Contains("утешительную награду:"))
                {
                    int prizeStart = line.IndexOf("у:");
                    int prizeEnd = line.IndexOf("очков");
                    int prizeLen = prizeEnd - prizeStart;
                    string comfortPrize = line.Substring(prizeStart + 2, prizeLen + 3);
                    return comfortPrize;
                }
            }
            return "";
        }

        //Предупреждения
        static int getWarnings(string[] lines)
        {
            int warningsStart = 0;
            int warningsEnd = 0;
            foreach (string line in lines)
            {
                if (line.Contains("Событие началось:")) { warningsStart = lines.IndexOf(line); }
                if (line.Contains("Событие успешно завершено:")) { warningsEnd = lines.IndexOf(line); }
            }
            int warningsCount = 0;
            foreach (string line in lines[warningsStart..warningsEnd])
            {
                if (line.Contains("[Warning]")) { warningsCount++; }
            }
            return warningsCount;
        }

        //Ошибки
        static int getErrors(string[] lines)
        {
            int errorsStart = 0;
            int errorsEnd = 0;
            foreach (string line in lines)
            {
                if (line.Contains("Событие началось:")) { errorsStart = lines.IndexOf(line); }
                if (line.Contains("Событие успешно завершено:")) { errorsEnd = lines.IndexOf(line); }
            }
            int errorsCount = 0;
            foreach (string line in lines[errorsStart..errorsEnd])
            {
                if (line.Contains("[Error]")) { errorsCount++; }
            }
            return errorsCount;
        }

        //Отчёт
        return $"# Итоги события:{getEventName(lines)}" +
            $"\nДата: {getEventTime(lines)}" +
            $"\nПобедитель:{getWinnerTeam(lines)}" +
            $"\nОчки победителя:{getWinnerScore(lines)}" +
            $"\nИвентовый предмет:{getEventItem(lines)}" +
            $"\nУтешительная награда {getLoserTeam(lines)}:{getComfortPrize(lines)}" +
            $"\nПредупреждений во время события: {getWarnings(lines)}" +
            $"\nОшибок во время события: {getErrors(lines)}";
    }

    //Чтение строк
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("event_server.log");
        Console.WriteLine(BuildReport(lines));
    }

}