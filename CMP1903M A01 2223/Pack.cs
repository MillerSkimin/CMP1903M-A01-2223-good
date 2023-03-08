using System;
using System.Collections.Generic;
using CMP1903M_A01_2223;

public enum ShuffleType
{
    FisherYates,
    Riffle,
    Cut
}

public class Pack
{
    private List<Card> _cards;

    public Pack()
    {
        _cards = new List<Card>();

        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] values = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        foreach (string suit in suits)
        {
            foreach (string value in values)
            {
                _cards.Add(new Card(suit, value));
            }
        }
    }

    public void Shuffle(ShuffleType type)
    {
        switch (type)
        {
            case ShuffleType.FisherYates:
                FisherYatesShuffle();
                break;
            case ShuffleType.Riffle:
                RiffleShuffle();
                break;
            case ShuffleType.Cut:
                CutShuffle();
                break;
        }
    }

    private void FisherYatesShuffle()
    {
        Random random = new Random();

        // Fisher-Yates shuffle algorithm-  iterating through the array and swapping each element with a randomly chosen element that comes after it in the array
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Card temp = _cards[i];
            _cards[i] = _cards[j];
            _cards[j] = temp;
        }
    }
    //dividing the deck into two roughly equal halves and then combining them together
    private void RiffleShuffle()
    {
        List<Card> shuffled = new List<Card>();

        int half = _cards.Count / 2;
        int i = 0;
        int j = half;

        while (i < half && j < _cards.Count)
        {
            shuffled.Add(_cards[i++]);
            shuffled.Add(_cards[j++]);
        }

        while (i < half)
        {
            shuffled.Add(_cards[i++]);
        }

        while (j < _cards.Count)
        {
            shuffled.Add(_cards[j++]);
        }

        _cards = shuffled;
    }
    //no shuffle, ordered as a pack of cards comes
    private void CutShuffle()
    {
        Random random = new Random();
        int cutIndex = random.Next(_cards.Count - 1) + 1;

        List<Card> shuffled = new List<Card>(_cards.GetRange(cutIndex, _cards.Count - cutIndex));
        shuffled.AddRange(_cards.GetRange(0, cutIndex));

        _cards = shuffled;
    }

    public List<Card> Deal(int numCards)
    {
        List<Card> dealt = new List<Card>();

        if (numCards <= _cards.Count)
        {
            dealt = _cards.GetRange(0, numCards);
            _cards.RemoveRange(0, numCards);
        }

        return dealt;
    }

    public List<Card> GetCards()
    {
        return _cards;
    }
}
