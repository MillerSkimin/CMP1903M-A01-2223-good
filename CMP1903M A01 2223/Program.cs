using System;
using System.Collections.Generic;
using CMP1903M_A01_2223;

class Program
{
    static void Main(string[] args)
    {
#if DEBUG
        Console.WriteLine("Running tests...");
        var test = new NewTest();
        test.TestCard();
        test.TestPack();
        Console.WriteLine("All tests passed.");
#endif

        Pack pack = new Pack();

        bool validInput = false;
        ShuffleType shuffleType = ShuffleType.FisherYates;

        while (!validInput)//error handling
        {
            Console.WriteLine("What type of shuffle do you want? (FisherYates, Riffle, Cut)");//the shuffle options and cut being no shuffle to the deck
            string shuffleTypeString = Console.ReadLine();

            if (Enum.TryParse(shuffleTypeString, true, out shuffleType))
            {
                validInput = true;
            }
            else //error handling
            {
                Console.WriteLine("Invalid input. Please try again.");//if option is not right this is printed
            }
        }

        pack.Shuffle(shuffleType);

        Console.WriteLine("Deck:");

        foreach (Card card in pack.GetCards())
        {
            Console.WriteLine(card);//prinnts all cards in shuffle option
        }

        Console.WriteLine();

        List<Card> dealtCards = pack.Deal(10);

        Console.WriteLine("Dealt cards:");

        foreach (Card card in dealtCards)
        {
            Console.WriteLine(card);
        }

        Console.WriteLine();

        Console.WriteLine("Remaining cards:");

        foreach (Card card in pack.GetCards())
        {
            Console.WriteLine(card);
        }

        Console.ReadKey();//keeps window open until key is pressed to close
    }
}
