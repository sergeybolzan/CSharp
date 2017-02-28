using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinker
{
    class Player
    {
        public string Name { get; set; }
        public List<Card> cardsPlayer;
        public Player(string name)
        {
            cardsPlayer = new List<Card>();
            Name = name;
        }
        public void PrintPlayerCards()
        {
            if (cardsPlayer.Count > 0)
            {
                Console.Write("{0,-10}", Name);
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                foreach (var item in cardsPlayer)
                {
                    Console.Write("{0,-4}", item);
                }
                Console.WriteLine();
            }
        }
        public void AddCard(Card card)
        {
            cardsPlayer.Add(card);
        }
        public Card PutCard()
        {
            Card temp = cardsPlayer[0];
            cardsPlayer.RemoveAt(0);
            return temp;
        }

    }
}
