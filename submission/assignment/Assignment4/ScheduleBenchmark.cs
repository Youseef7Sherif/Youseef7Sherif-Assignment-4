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

    [Params(100, 1000, 10000, 100000)]
    public int Iterations;

    [Benchmark]
    public string StringConcatenation()
    {
        string report = "";

        for (int i = 0; i < Iterations; i++)
        {
            report += $"{sessionNames[i % sessionNames.Length]}";
            report += $" - {sessionDates[i % sessionDates.Length]:dd/MM/yyyy}";
            report += $" {sessionDates[i % sessionDates.Length]:hh:mm tt}";
            report += $" - {sessionDurations[i % sessionDurations.Length]} minutes\n";
        }

        return report;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        StringBuilder report = new StringBuilder();

        for (int i = 0; i < Iterations; i++)
        {
            report.Append($"{sessionNames[i % sessionNames.Length]}");
            report.Append($" - {sessionDates[i % sessionDates.Length]:dd/MM/yyyy}");
            report.Append($" {sessionDates[i % sessionDates.Length]:hh:mm tt}");
            report.AppendLine($" - {sessionDurations[i % sessionDurations.Length]} minutes");
        }

        return report.ToString();
    }
}