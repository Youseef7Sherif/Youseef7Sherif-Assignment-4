using System.Text;
namespace Assignment4;

internal class Program
{
    static void Main(string[] args)
    {
        string[] sessionNames =
       {
            "C# Basics",
            "Arrays",
            "Functions",
            "Date and Time",
            "Exception Handling"
       };

        DateTime[] sessionDates =
       {
            new DateTime(2026, 9, 10, 18, 0, 0),
            new DateTime(2026, 9, 13, 18, 0, 0),
            new DateTime(2026, 9, 17, 18, 0, 0),
            new DateTime(2026, 9, 20, 18, 0, 0),
            new DateTime(2026, 9, 24, 18, 0, 0)
       };

        int[] sessionDurations =
        {
             180,
             240,
             180,
             240,
             180
        };

        Console.WriteLine("All Sessions:");
        DisplayAllSessions(sessionNames, sessionDates, sessionDurations);
        Console.WriteLine("Search for a session:");
        SearchForSession(sessionNames, sessionDates, sessionDurations);
        string[] sortedNames = SortArray(sessionNames);
        Console.WriteLine("\nSorted Session Names:");
        DisplayArray(sortedNames);
        string[] reversedNames = ReverseArray(sessionNames);
        Console.WriteLine("\nReversed Session Names:");
        DisplayArray(reversedNames);
        Console.WriteLine("\nFind Session Index:");
        int index = FindSessionIndex(sessionNames);
        Console.WriteLine(index == -1 ? "Session not found." : $"Session index: {index}");
        Console.WriteLine("\nCheck if Session Exists:");
        bool exists = SessionExists(sessionNames);
        Console.WriteLine(exists ? "Session exists." : "Session does not exist.");
        Console.WriteLine("\nFind Session:");
        string? foundSession = FindSession(sessionNames);
        Console.WriteLine(string.IsNullOrEmpty(foundSession) ? "Session not found." : $"Found session: {foundSession}");
        Console.WriteLine("\nFind Index of Session:");
        int foundIndex = FindIndex(sessionNames);
        Console.WriteLine(foundIndex == -1 ? "Session not found." : $"Session index: {foundIndex}");
        Console.WriteLine("\nCopy Array and Modify:");
        CopyArrayAndModify(sessionNames);
        Console.WriteLine("\nCalculate Total Duration:");
        int totalDuration = CalculateTotalDuration(sessionDurations);
        Console.WriteLine($"Total Duration: {totalDuration} minutes");
        Console.WriteLine("\nCalculate Average Duration:");
        double averageDuration = CalculateAverageDuration(sessionDurations);
        Console.WriteLine($"Average Duration: {averageDuration} minutes");
        Console.WriteLine("\nshortest duration");
        int shortestDuration = FindShortestDuration(sessionDurations);
        Console.WriteLine($"Shortest Duration: {shortestDuration} minutes");
        Console.WriteLine("\nLongest duration");
        int longestDuration = FindLongestDuration(sessionDurations);
        Console.WriteLine($"longest Duration: {longestDuration} minutes");
        SortDurations(sessionDurations);
        Console.WriteLine("\nSession Details:");
        DisplaySessionDetails(sessionNames[0], sessionDates[0], sessionDurations[0]);

        Console.WriteLine("\nSession End Time:");
        DateTime endTime = GetSessionEndTime(sessionDates[0], sessionDurations[0]);

        Console.WriteLine($"End Time: {endTime:hh:mm tt}");

        Console.WriteLine("\nRead Session Date:");
        DateTime newDate = ReadSessionDate();
        Console.WriteLine($"Entered Date: {newDate:dd MMMM yyyy}");

        Console.WriteLine("\nReport Using String:");
        string report = BuildReportUsingString(sessionNames, sessionDates, sessionDurations);

        Console.WriteLine(report);

        Console.WriteLine("\nReport Using StringBuilder:");
        string reportBuilder = BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations);

        Console.WriteLine(reportBuilder);

        int number = 10;

        Console.WriteLine($"\nBefore: {number}");

        ChangeValue(ref number);

        Console.WriteLine($"After: {number}");

        bool isFound = GetSessionInfo(sessionNames, sessionDurations, out int sessionIndex, out int duration);
        if (isFound)
        {
            Console.WriteLine($"Session found at index {sessionIndex} with duration {duration} minutes.");
        }
        Console.WriteLine("\nChange Array Element:");
        Console.WriteLine("\nBefore change:");
        DisplayArrayElements(sessionNames);
        ChangeArrayElement(sessionNames);
        Console.WriteLine("\nAfter change:");
        DisplayArrayElements(sessionNames);
        int total1 = CalculateTotalDurationWithParams(120, 180);
        int total2 = CalculateTotalDurationWithParams(120, 180, 240);
        int total3 = CalculateTotalDurationWithParams(60, 90, 120, 180, 240);

        Console.WriteLine($"\nTotal 1: {total1}");
        Console.WriteLine($"\nTotal 2: {total2}");
        Console.WriteLine($"\nTotal 3: {total3}");


        SessionDateDetails(sessionNames, sessionDurations, sessionDates);

        CalculateDateDifference(sessionNames, sessionDates);

        DisplaySessionStatus(sessionNames, sessionDates);

        FindNextSession(sessionNames, sessionDates, sessionDurations);
        Console.WriteLine("\nDate Formatting:");
        DisplayDateFormats(sessionNames, sessionDates);

        Console.WriteLine("\nRead and Validate Date:");

        DateTime validDate = ReadAndValidateDate();

        Console.WriteLine($"Valid Date: {validDate:yyyy-MM-dd HH:mm}");

        int choice = ReadMenuOption();
        Console.WriteLine($"You selected option: {choice}");

        InvalidArrayIndex(sessionNames);
    }

    public static void DisplayAllSessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        for (int i = 0; i < sessionNames.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {sessionNames[i]}");
            Console.WriteLine($"Date: {sessionDates[i]:dd MMMM yyyy}");
            Console.WriteLine($"Start Time: {sessionDates[i]:hh:mm tt}");
            Console.WriteLine($"Duration: {sessionDurations[i]} minutes");
            Console.WriteLine();
        }
    }
    public static void DisplaySessionDetails(string name, DateTime date, int duration)
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Date: {date:dd MMMM yyyy}");
        Console.WriteLine($"Start Time: {date:hh:mm tt}");
        Console.WriteLine($"Duration: {duration} minutes");
    }
    public static DateTime GetSessionEndTime(DateTime startTime, int duration)
    {
        return startTime.AddMinutes(duration);
    }
    public static DateTime ReadSessionDate()

    {
        Console.Write("Enter session date (dd/MM/yyyy): ");
        string input = Console.ReadLine() ?? "";

        DateTime date;

        while (!DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
        {
            Console.Write("Invalid date. Enter again (dd/MM/yyyy): ");
            input = Console.ReadLine() ?? "";
        }

        return date;
    }
    public static string BuildReportUsingString(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        string report = "";

        for (int i = 0; i < sessionNames.Length; i++)
        {
            report += $"Session: {sessionNames[i]}\n";
            report += $"Date: {sessionDates[i]:dd MMMM yyyy}\n";
            report += $"Start Time: {sessionDates[i]:hh:mm tt}\n";
            report += $"Duration: {sessionDurations[i]} minutes\n";

            DateTime endTime = GetSessionEndTime(sessionDates[i], sessionDurations[i]);

            report += $"End Time: {endTime:hh:mm tt}\n";
            report += "-------------------------\n";
        }

        return report;
    }
    public static string BuildReportUsingStringBuilder(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        StringBuilder report = new StringBuilder();

        for (int i = 0; i < sessionNames.Length; i++)
        {
            report.AppendLine($"Session: {sessionNames[i]}");
            report.AppendLine($"Date: {sessionDates[i]:dd MMMM yyyy}");
            report.AppendLine($"Start Time: {sessionDates[i]:hh:mm tt}");
            report.AppendLine($"Duration: {sessionDurations[i]} minutes");

            DateTime endTime = GetSessionEndTime(sessionDates[i], sessionDurations[i]);

            report.AppendLine($"End Time: {endTime:hh:mm tt}");
            report.AppendLine("-------------------------");
        }

        return report.ToString();
    }
    public static void SearchForSession(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        Console.Write("Enter session name: ");
        string searchName = Console.ReadLine() ?? "";

        int index = Array.IndexOf(sessionNames, searchName);

        if (index != -1)
        {
            Console.WriteLine($"Name: {sessionNames[index]}");
            Console.WriteLine($"Date: {sessionDates[index]:dd MMMM yyyy}");
            Console.WriteLine($"Start Time: {sessionDates[index]:hh:mm tt}");
            Console.WriteLine($"Duration: {sessionDurations[index]} minutes");
        }
        else
        {
            Console.WriteLine("Session not found.");
        }
    }
    public static string[] SortArray(string[] arr)
    {
        string[] sortedArray = new string[arr.Length];
        Array.Copy(arr, sortedArray, arr.Length);
        Array.Sort(sortedArray);
        return sortedArray;
    }
    public static void DisplayArray(string[] arr)
    {
        foreach (string item in arr)
        {
            Console.WriteLine(item);
        }

    }
    public static string[] ReverseArray(string[] arr)
    {
        string[] reversedArray = new string[arr.Length];
        Array.Copy(arr, reversedArray, arr.Length);
        Array.Reverse(reversedArray);
        return reversedArray;
    }
    public static int FindSessionIndex(string[] arr)
    {
        Console.WriteLine("Enter the session name to find its index:");
        string sessionName = Console.ReadLine() ?? "";
        return Array.IndexOf(arr, sessionName);
    }
    public static bool SessionExists(string[] arr)
    {
        Console.WriteLine("Enter the session name to find if it exists:");
        string sessionName = Console.ReadLine() ?? "";
        return Array.Exists(arr, item => sessionName == item);
    }
    public static string? FindSession(string[] arr)
    {
        Console.WriteLine("Enter the session name to find it:");
        string sessionName = Console.ReadLine() ?? "";
        return Array.Find(arr, item => sessionName == item);
    }
    public static int FindIndex(string[] arr)
    {
        Console.WriteLine("Enter the session name to find index of it:");
        string sessionName = Console.ReadLine() ?? "";
        return Array.FindIndex(arr, item => sessionName == item);
    }
    public static void CopyArrayAndModify(string[] sessionNames)
    {
        string[] copySessionNames = new string[sessionNames.Length];
        Array.Copy(sessionNames, copySessionNames, sessionNames.Length);
        copySessionNames[0] = "C# Advanced";
        Console.WriteLine("\nOriginal Session Names:");
        foreach (string session in sessionNames)
        {
            Console.WriteLine(session);
        }
        Console.WriteLine("\nCopied Session Names:");
        foreach (string session in copySessionNames)
        {
            Console.WriteLine(session);
        }
    }
    public static int CalculateTotalDuration(int[] durations)
    {
        int totalDuration = 0;
        foreach (int duration in durations)
        {
            totalDuration += duration;
        }
        return totalDuration;
    }
    public static double CalculateAverageDuration(int[] durations)
    {
        double averageDuration = (double)CalculateTotalDuration(durations) / durations.Length;
        return averageDuration;
    }
    public static int FindShortestDuration(int[] durations)
    {
        int shortestDuration = durations[0];
        foreach (int duration in durations)
        {
            if (duration < shortestDuration)
            {
                shortestDuration = duration;
            }
        }
        return shortestDuration;
    }
    public static int FindLongestDuration(int[] durations)
    {
        int longestDuration = durations[0];
        foreach (int duration in durations)
        {
            if (duration > longestDuration)
            {
                longestDuration = duration;
            }
        }
        return longestDuration;
    }
    public static void SortDurations(int[] durations)
    {
        int[] sortedDuration = new int[durations.Length];
        Array.Copy(durations, sortedDuration, durations.Length);
        Array.Sort(sortedDuration);
        Console.WriteLine("\nDurations of the sessions after sorting ");
        for (int i = 0; i < sortedDuration.Length; i++)
        {
            Console.WriteLine($"Duration of session {i + 1} :{sortedDuration[i]}");
        }
    }
    public static void ChangeValue(ref int number)
    {
        number += 10;
    }
    public static bool GetSessionInfo(string[] sessionNames, int[] sessionDurations, out int index, out int duration)
    {
        Console.WriteLine("Enter the session name to get its index and duration:");
        string sessionName = Console.ReadLine() ?? "";
        index = Array.IndexOf(sessionNames, sessionName);
        if (index != -1)
        {
            duration = sessionDurations[index];
            return true;
        }
        else
        {
            duration = 0;
            return false;
        }
    }
    public static void ChangeArrayElement(string[] arr)
    {
        arr[0] = "C# Advanced";
    }
    public static void DisplayArrayElements(string[] arr)
    {
        foreach (string item in arr)
        {
            Console.WriteLine(item);
        }
    }
    public static int CalculateTotalDurationWithParams(params int[] durations)
    {
        int totalDuration = CalculateTotalDuration(durations);
        return totalDuration;
    }
    public static void SessionDateDetails(string[] sessionNames, int[] sessionDurations, DateTime[] sessionDates)
    {
        Console.WriteLine("enter session name:");
        string sessionName = Console.ReadLine() ?? "";
        int index = Array.IndexOf(sessionNames, sessionName);
        if (index != -1)
        {
            Console.WriteLine($"Date: {sessionDates[index]:dd MMMM yyyy}");
            Console.WriteLine($"Day: {sessionDates[index].DayOfWeek}");
            Console.WriteLine($"Year: {sessionDates[index].Year}");
            Console.WriteLine($"Month: {sessionDates[index].Month}");
            Console.WriteLine($"Day Number: {sessionDates[index].Day}");
            Console.WriteLine($"Start Time: {sessionDates[index]:hh:mm tt}");
            Console.WriteLine($"Duration: {sessionDurations[index]} minutes");
            Console.WriteLine($"End Time: {sessionDates[index].AddMinutes(sessionDurations[index]):hh:mm tt}");

        }
        else
        {
            Console.WriteLine("Session not found.");
        }
    }
    public static void CalculateDateDifference(string[] sessionNames, DateTime[] sessionDates)
    {
        Console.WriteLine("enter First Session name:");
        string sessionName1 = Console.ReadLine() ?? "";
        int index1 = Array.IndexOf(sessionNames, sessionName1);
        Console.WriteLine("enter Second Session name:");
        string sessionName2 = Console.ReadLine() ?? "";
        int index2 = Array.IndexOf(sessionNames, sessionName2);
        if (index1 != -1 && index2 != -1)
        {
            TimeSpan diffTime = (sessionDates[index1] - sessionDates[index2]).Duration();// for negative
            Console.WriteLine($"Difference:\n{diffTime.TotalDays} days\n{diffTime.TotalHours} hours");
        }
        else
            Console.WriteLine("session not found");
    }
    public static void DisplaySessionStatus(string[] sessionNames, DateTime[] sessionDates)
    {
        string status;
        for (int i = 0; i < sessionNames.Length; i++)
        {
            if (sessionDates[i] > DateTime.Now)
                status = "Upcoming";
            else
                status = "Past";
            Console.WriteLine($"{sessionNames[i]} {status}");

        }
    }
    public static void FindNextSession(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        var nextSessionIndex = -1;
        for (int i = 0; i < sessionNames.Length; i++)
        {
            if (sessionDates[i] > DateTime.Now && (nextSessionIndex == -1 || sessionDates[i] < sessionDates[nextSessionIndex]))
            {
                nextSessionIndex = i;
            }
        }
        if (nextSessionIndex == -1)
        {
            Console.WriteLine("No upcoming sessions.");
            return;
        }
        Console.WriteLine($"Next Session: {sessionNames[nextSessionIndex]}");
        DisplaySessionDetails(sessionNames[nextSessionIndex], sessionDates[nextSessionIndex], sessionDurations[nextSessionIndex]);
        Console.WriteLine($"End Time: {GetSessionEndTime(sessionDates[nextSessionIndex], sessionDurations[nextSessionIndex]):hh:mm tt}");
        Console.WriteLine("Time Remaining:");
        TimeSpan remainingTime = sessionDates[nextSessionIndex] - DateTime.Now;
        Console.WriteLine($"{remainingTime.Days}  days");
        Console.WriteLine($"{remainingTime.Hours}  hours");


    }
    public static void DisplayDateFormats(string[] sessionNames, DateTime[] sessionDates)
    {
        Console.Write("Enter session name: ");
        string sessionName = Console.ReadLine() ?? "";

        int index = Array.IndexOf(sessionNames, sessionName);

        if (index != -1)
        {
            DateTime sessionDate = sessionDates[index];

            Console.WriteLine($"yyyy-MM-dd: {sessionDate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"dd/MM/yyyy: {sessionDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"dd MMMM yyyy: {sessionDate.ToString("dd MMMM yyyy")}");
            Console.WriteLine($"dddd, dd MMMM yyyy: {sessionDate.ToString("dddd, dd MMMM yyyy")}");
            Console.WriteLine($"hh:mm tt: {sessionDate.ToString("hh:mm tt")}");
        }
        else
        {
            Console.WriteLine("Session not found.");
        }
    }
    public static DateTime ReadAndValidateDate()
    {
        Console.Write("Enter date (yyyy-MM-dd HH:mm): ");
        string input = Console.ReadLine() ?? "";

        DateTime date;

        while (!DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out date))
        {
            Console.Write("Invalid date. Enter again (yyyy-MM-dd HH:mm): ");
            input = Console.ReadLine() ?? "";
        }

        return date;
    }
    public static int ReadMenuOption()
    {
        Console.WriteLine("Choose an option:");
        string option = Console.ReadLine() ?? "";
        int choice = 0;
        bool flag = true;
        while (flag)
        {
            try
            {
                choice = int.Parse(option);
                flag = false;
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.WriteLine("\nChoose an option:");
                option = Console.ReadLine() ?? "";
            }
        }
        return choice;
    }
    public static void InvalidArrayIndex(string[] sessionNames)
    {
        Console.WriteLine("Enter the index of the session name you want to access:");
        int index = ReadMenuOption();
        try
        {
            Console.WriteLine($"Session name at index {index}: {sessionNames[index]}");

        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("The selected session index is out of range.");

        }
    }
}