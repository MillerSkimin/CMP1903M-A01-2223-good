using System;
using System.Collections.Generic;
using CMP1903M_A01_2223;

public class NewTest
{
    public void TestCard()
    {
        Card card = new Card("Hearts", "Ace");
        Console.WriteLine(card.ToString());
    }

    public void TestPack()
    {
        Pack pack = new Pack();
        Console.WriteLine("Initial pack:");

        foreach (Card card in pack.GetCards())
        {
            Console.WriteLine(card);
        }

        Console.WriteLine("Shuffled pack:");
        pack.Shuffle(ShuffleType.Riffle);

        foreach (Card card in pack.GetCards())
        {
            Console.WriteLine(card);
        }

        Console.WriteLine("Dealing 10 cards:");
        List<Card> dealtCards = pack.Deal(10);

        foreach (Card card in dealtCards)
        {
            Console.WriteLine(card);
        }

        Console.WriteLine("Remaining cards:");
        foreach (Card card in pack.GetCards())
        {
            Console.WriteLine(card);
        }
    }
}
