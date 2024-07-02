// This is the file for the Entry Class

// Entry
using System.Net;

public class Entry
{
    // Attributes
    private string _question;
    private string _response;
    private DateTime _date;


    // Constructor
    public Entry(string question = "BLANK", string response = "BLANK")
    {
        _question = question;
        _response = response;
        _date = DateTime.Today;
    }

    public void PrintEntry()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_question}");   
        Console.WriteLine(_response);
        Console.WriteLine();

    }

    public string GetEntryPrompt()
    {
        return _question;
    }

    public string GetEntryResponse()
    {
        return _response;
    }

    public DateTime GetEntryDate()
    {
        return _date;
    }
}

