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
            Console.WriteLine($"Duration of session {i+1} :{sortedDuration[i]}");
        }
    }

}

