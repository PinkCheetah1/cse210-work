// This is the file for the Entry Class

// Entry
using System.Net;
using System.IO; 

public class Entry
{
    // Attributes
    private string _question;
    private string _response;
    private string _date;

    


    // Constructor
    public Entry(string question, string response, string date)
    {
        _question = question;
        _response = response;
        _date = date;
    }
    public Entry(string question = "BLANK", string response = "BLANK")
    {
        _question = question;
        _response = response;
        DateTime theCurrentTime = DateTime.Now;
        _date = theCurrentTime.ToShortDateString();
    }

    public void PrintEntry()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_question}");   
        Console.WriteLine(_response);
        Console.WriteLine();
    }


    public string GetEntryString()
    {
        return $"{_date}||{_question}||{_response}";
    }

    public string GetQuestion()
    {   
        return _question;
    }

    public string GetResponse()
    {
        return _response;
    }

    public string GetDate()
    {
        return _date;
    }
}
