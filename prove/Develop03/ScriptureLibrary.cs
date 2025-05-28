public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _rand;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _rand = new Random();
    }

    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0) return null;
        int index = _rand.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
