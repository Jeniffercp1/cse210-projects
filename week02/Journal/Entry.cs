using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Mood: {_mood}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }

    public string ToCsvLine()
    {
        return $"{EscapeCsv(_date)},{EscapeCsv(_promptText)},{EscapeCsv(_entryText)},{EscapeCsv(_mood)}";
    }

    public static Entry FromCsvLine(string line)
    {
        List<string> fields = ParseCsvLine(line);

        Entry entry = new Entry();
        entry._date = fields.Count > 0 ? fields[0] : "";
        entry._promptText = fields.Count > 1 ? fields[1] : "";
        entry._entryText = fields.Count > 2 ? fields[2] : "";
        entry._mood = fields.Count > 3 ? fields[3] : "";

        return entry;
    }

    private static string EscapeCsv(string value)
    {
        if (value == null)
        {
            value = "";
        }

        return $"\"{value.Replace("\"", "\"\"")}\"";
    }

    private static List<string> ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        string currentField = "";
        bool insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char currentChar = line[i];

            if (currentChar == '"' && insideQuotes && i + 1 < line.Length && line[i + 1] == '"')
            {
                currentField += '"';
                i++;
            }
            else if (currentChar == '"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (currentChar == ',' && !insideQuotes)
            {
                fields.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += currentChar;
            }
        }

        fields.Add(currentField);
        return fields;
    }
}
