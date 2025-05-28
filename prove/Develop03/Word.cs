public class Word
{
    private string _text;
    private bool _visible;

    public Word(string text)
    {
        _text = text;
        _visible = true;
    }

    public bool IsVisible => _visible;

    public void Hide() => _visible = false;

    public string Display() => _visible ? _text : "____";
}
