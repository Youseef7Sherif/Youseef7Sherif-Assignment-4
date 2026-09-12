using BenchmarkDotNet.Attributes;
using System.Text;

namespace Assignment4;

[MemoryDiagnoser]
public class ScheduleBenchmark
{
    private string[] sessionNames =
    {
        "C# Basics",
        "Arrays",
        "Functions",
        "Date and Time",
        "Exception Handling"
    };

    private DateTime[] sessionDates =
    {
        new DateTime(2026, 9, 10, 18, 0, 0),
        new DateTime(2026, 9, 13, 18, 0, 0),
        new DateTime(2026, 9, 17, 18, 0, 0),
        new DateTime(2026, 9, 20, 18, 0, 0),
        new DateTime(2026, 9, 24, 18, 0, 0)
    };

    private int[] sessionDurations =
    {
        180,
        240,
        180,
        240,
        180
    };

    [Benchmark]
    public string StringConcatenation()
    {
        string report = "";

        for (int i = 0; i < sessionNames.Length; i++)
        {
            report += $"{sessionNames[i]}";
            report += $" - {sessionDates[i]:dd/MM/yyyy}";
            report += $" {sessionDates[i]:hh:mm tt}";
            report += $" - {sessionDurations[i]} minutes\n";
        }

        return report;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        StringBuilder report = new StringBuilder();

        for (int i = 0; i < sessionNames.Length; i++)
        {
            report.Append($"{sessionNames[i]}");
            report.Append($" - {sessionDates[i]:dd/MM/yyyy}");
            report.Append($" {sessionDates[i]:hh:mm tt}");
            report.AppendLine($" - {sessionDurations[i]} minutes");
        }

        return report.ToString();
    }
}