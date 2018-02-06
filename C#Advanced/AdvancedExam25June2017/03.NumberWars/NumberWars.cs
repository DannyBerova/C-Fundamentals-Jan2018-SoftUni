using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NumberWars
{
    public class NumberWars
    {
        public static void Main()
        {
            var firstLine = Console.ReadLine();
            var deckOne = new Queue<Card>(firstLine.Split().Select(x => new Card(x)));

            var secondLine = Console.ReadLine();
            var deckTwo = new Queue<Card>(secondLine.Split().Select(x => new Card(x)));

            int turn = 0;

            while (turn < 1000000 && deckOne.Count > 0 && deckTwo.Count > 0)
            {
                turn++;
                var firstPCard = deckOne.Dequeue();
                var secondPCard = deckTwo.Dequeue();
                var table = new List<Card>() { firstPCard, secondPCard };
                Queue<Card> currentWinDeck = null;

                if (firstPCard.Number > secondPCard.Number)
                {
                    currentWinDeck = deckOne;
                }
                else if (firstPCard.Number < secondPCard.Number)
                {
                    currentWinDeck = deckTwo;
                }
                else
                {
                    while (currentWinDeck == null && deckOne.Count >= 3 && deckTwo.Count >= 3)
                    {
                        int sumOne = deckOne.Take(3).Sum(x => x.Letter);
                        int sumTwo = deckTwo.Take(3).Sum(x => x.Letter);

                        for (int i = 0; i < 3; i++)
                        {
                            table.Add(deckOne.Dequeue());
                            table.Add(deckTwo.Dequeue());
                        }

                        if (sumOne > sumTwo)
                        {
                            currentWinDeck = deckOne;
                        }
                        else if (sumOne < sumTwo)
                        {
                            currentWinDeck = deckTwo;
                        }
                    }
                }

                if (currentWinDeck != null)
                {
                    foreach (var card in table.OrderByDescending(x => x.Number).ThenByDescending(x => x.Letter))
                    {
                        currentWinDeck.Enqueue(card);
                    }
                }
            }

            if (deckOne.Count > deckTwo.Count)
            {
                Console.WriteLine($"First player wins after {turn} turns");
            }
            else if (deckOne.Count < deckTwo.Count)
            {
                Console.WriteLine($"Second player wins after {turn} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turn} turns");
            }
        }

        public class Card
        {

            public Card(string card)
            {
                Number = int.Parse(card.Substring(0, card.Length - 1));
                Letter = card[card.Length - 1] - 98;
            }
            public int Number { get; }
            public int Letter { get; }
        }
    }
}
