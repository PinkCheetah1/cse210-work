using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Billy Bob Bobson", "SPACE");
        MathAssignment math = new MathAssignment("SALLY", "sadness", "5", "8-10");
        WritingAssignment writing = new WritingAssignment("Joe", "mama", "The science of the things and the place");

        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine();

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkString());
        Console.WriteLine();

        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
        Console.WriteLine();
    }
}