public class Scripture
{
    private Reference _reference;
    private List<Verse> _verses;

    public Scripture(Reference reference, List<string> verseTexts)
    {
        _reference = reference;
        _verses = verseTexts.Select(text => new Verse(text)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference);
        foreach (var verse in _verses)
        {
            Console.WriteLine(verse.GetDisplayText());
        }
    }

    public void HideRandomWords(Random rand, int count)
    {
        foreach (var verse in _verses)
        {
            verse.HideRandomWords(rand, count);
        }
    }

    public bool AllWordsHidden() => _verses.All(v => v.AllWordsHidden());
}
