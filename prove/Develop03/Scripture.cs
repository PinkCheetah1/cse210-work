// Scripture:
// A
// - _reference
// - _words
// - _visibleWordIndexi
// C
// - (reference, Scripture)
// M
// - HideWords
//     Hide some words in the Scripture randomly
//     Generate random letter in range 1-len(visible words)
//     Find that word's index in _visibleWordIndexi
//     Set that word to hidden
// - DisplayRender
//     Display the scripture with the hidden words
// - AllWordsHidden
//     Test to see if there are still some words


public class Scripture
{
    // don't make me ;-;

    //ATTRIBUTES:
    private Reference _reference;
    private List<Word> _words;
    private List<int> _visibleWordsIndexi;


    // CONSTRUCTORS
    public Scripture(Reference reference, string scripture)
    {

        _reference = reference;


        // Constructor that takes string for scripture and
        // splits on every space to make list of words
        _words = new List<Word>();
        string[] splitWords = scripture.Split(" ");
        foreach (string w in splitWords)
        {
            Word word = new Word(w);
            _words.Add(word);
        }

        // Create _visibleWordIndexi
        // Following code came from ChatGPT
        _visibleWordsIndexi = new List<int>();
        int wordsCount = _words.Count();
        for (int i = 0; i < wordsCount; i++)
        {
            _visibleWordsIndexi.Add(i);
        }

    }

    // METHODS:

    public void HideWords(int num)
    {
        // - HideWords
        //     Hide some words in the Scripture randomly
        //     Generate random letter in range 1-len(visible words)
        //     Find that word's index in _visibleWordIndexi
        //     Set that word to hidden

        Random random = new Random();
        for (int i = 0; i <= num; i++) 
        {
            if (_visibleWordsIndexi.Count() != 0)
            {
                // Checks how many words are still visible
                // and creates a random number within that range
                int visibleWordIndex = random.Next(0, _visibleWordsIndexi.Count());
                // Gets word index from list of index of words still visible
                int wordIndex = _visibleWordsIndexi[visibleWordIndex];
                // Set that word to hidden
                _words[wordIndex].Hide();
                // Removes that index from list because that word will no longer
                // be visible (it will be hidden)
                _visibleWordsIndexi.Remove(_visibleWordsIndexi[visibleWordIndex]);
            }

        }

    }

    public void DisplayRender()
    {
        // - DisplayRender
        //     Display the scripture with the hidden words

        Console.WriteLine(_reference.GetReferenceString());

        foreach (Word word in _words)
        {
            Console.Write(word.GetRender());
        }
        Console.WriteLine();

    }

    public bool AllWordsHidden()
    {
        // - AllWordsHidden
        //     Test to see if there are still some words
        bool allWordsHidden = false;
        if (_visibleWordsIndexi.Count() == 0)
        {
            allWordsHidden = true;
        }
        
        return allWordsHidden;
    }

}


