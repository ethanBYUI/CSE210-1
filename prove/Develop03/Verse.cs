public class Verse
{
    private List<Word> _words;

    public Verse(string text)
    {
        _words = new List<Word>();
        foreach (string part in text.Split(' '))
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(Random rand, int count)
    {
        var visibleWords = _words.Where(w => w.IsVisible).ToList();
        for (int i = 0; i < count && visibleWords.Any(); i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(w => w.Display()));
    }

    public bool AllWordsHidden() => _words.All(w => !w.IsVisible);
}
