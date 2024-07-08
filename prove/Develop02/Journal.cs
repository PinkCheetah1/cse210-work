// This is the file for my Journal Class


// Journal
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.IO; 

public class Journal
{
    // Attributes: list of journal entries
    private List<Entry> _entries;


    // Constructor:
    public Journal()
    {
        _entries = new List<Entry>();
        _entries.Add(new Entry("a", "a"));
        _entries.Add(new Entry("b", "b"));
        _entries.Add(new Entry("c", "c"));
    }


    // Print the Journal:
    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.PrintEntry();
        }
    }


    // Write new Journal Entry:
    public void NewEntry()
    {
        string prompt = RandomQuestion();
        Console.Write(prompt);
        string response = Console.ReadLine();
        Entry newEntry = new Entry(prompt, response);
        _entries.Add(newEntry);
    }


    // Save the Journal
    public void Save(string file)
    {
        foreach (Entry entry in _entries)
        {
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                string entryString = entry.GetEntryString();
                outputFile.WriteLine(entryString);
            }
        }

        Console.WriteLine("Your journal has been saved!");
    }


    // Load the Journal

    public void Load(string fileName)
    {

        // We're going to rewrite any entires already in the journal
        // and replace with new, loaded-in entries.
        _entries.Clear();

        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {

            // "||" is what is used to divide data in files
            string[] lineParts = line.Split("||");

            string date = lineParts[0];
            string question = lineParts[1];
            string response = lineParts[2];

            // Turns this info into an entry and adds it to journal
            Entry newEntry = new Entry(question, response, date);
            _entries.Add(newEntry);

        }
    }

    private string RandomQuestion()
    {

        //I got the list part of this code from ChatGPT
        // I was confused on lists and how they worked. I understand
        // the following code as creating a new list for me with
        // all of the questions I intend to use. 
        // The code after that creates a random class and
        // gets me a random number within the range of the
        // length of the list.
        // I understand this code now.
        List<string> _questions = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "How many cats did you pet today? What was the cutest one?",
        "What's the weirdest hat you saw this week?",
        "Tell me about a fabulous thought you had today."
     };
        
        // Get a random question
        Random random = new Random();
        int index = random.Next(_questions.Count);
        string randomQuestion = _questions[index];

        return randomQuestion;
    }

}