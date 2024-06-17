

using System.Security.AccessControl;

public class Job(string company, string jobTitle, int startYear, int endYear)
{
    public string _company = company;
    public string _jobTitle = jobTitle;
    public int _startYear = startYear;
    public int _endYear = endYear;

    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }



}