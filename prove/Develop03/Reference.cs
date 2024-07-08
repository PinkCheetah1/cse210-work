// Reference:
// A
// - Book
// - Chapter
// - Start Verse
// - End Verse
// C 
// - (Book, Chapter, Start Verse)
// - (Book, Chapter, Start Verse, End Verse)
// M
// - GetReferenceString 
//     Return string with formatted reference


public class Reference
{
    // ATTRIBUTES:
    private string _book;
    private string _chapter;
    private string _verse;


    // CONSTRUCTORS:

    // single verse
    public Reference(string book, string chapter, string startVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
    }

    // verse range
    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = $"{startVerse}-{endVerse}";
    }

    // METHODS

    public string GetReferenceString()
    {
        // Return formatted version of reference
        return $"{_book} {_chapter}:{_verse}";
    }
}
