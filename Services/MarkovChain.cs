using System.Collections.Generic;
using System.Linq;

public class MarkovChain
{
    private readonly Dictionary<string, List<string>> _chains = new();
    public bool IsTrained { get; private set; }

    public void Train(IEnumerable<string> sentences)
    {
        foreach (var sentence in sentences)
        {
            if (!string.IsNullOrEmpty(sentence))
            {
                var words = sentence.Split(' ');
                for (int i = 0; i < words.Length - 1; i++)
                {
                    if (!_chains.ContainsKey(words[i]))
                        _chains[words[i]] = new List<string>();

                    _chains[words[i]].Add(words[i + 1]);
                }
            }
        }

        IsTrained = true;
    }

    public string Generate()
    {
        if (!IsTrained)
            throw new InvalidOperationException("The Markov chain has not been trained.");

        var keys = _chains.Keys.ToList();
        var random = new Random();
        var currentWord = keys[random.Next(keys.Count)];
        var result = new List<string> { currentWord };

        for (int i = 0; i < 20; i++) // Limit to 20 words
        {
            if (!_chains.ContainsKey(currentWord) || _chains[currentWord].Count == 0)
                break;

            var nextWords = _chains[currentWord];
            currentWord = nextWords[random.Next(nextWords.Count)];
            result.Add(currentWord);
        }

        return string.Join(" ", result);
    }
}
