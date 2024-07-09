// Word
// A
// - Word
// - Is Hidden? 
// C
// - (Word) isHidden = False
// M
// - Hide (set to hidden)
// - Show (set to not hidden)
// - GetRendered (return ___ if hidden, return word if not)


public class Word
{
    // ATTRIBUTES: word (string), isHidden (bool)
    private string _letters;
    private bool _isHidden;


    // CONSTRUCTORS: 
    public Word(string letters)
    {
        _letters = letters;
        _isHidden = false;
    }


    // METHODS
    public void Hide()
    {
        _isHidden = true;
    }
    public void Show()
    {
        _isHidden = false;
    }

    public string GetRender()
    {
        // This method returns the appropriate
        // string for the word, either the full
        // word or a list of "_" equal to the length
        // of the word if the word is set to hidden


        string render = "";

        if (_isHidden)
        {
            // TODO
            // Get length of word and
            // return _ for each letter
            render = "_ ";
        }
        else
        {
            render = _letters + " ";
        }

        return render;
    }

}
