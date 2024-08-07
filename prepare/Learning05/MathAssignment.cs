public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    //Constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }


    public string GetHomeworkString()
    {
        return $"{_textbookSection} {_problems}";
    }

}