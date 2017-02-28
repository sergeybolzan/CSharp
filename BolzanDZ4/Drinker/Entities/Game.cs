using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drinker.Entities;
using Loger;

namespace Drinker
{
    class Game
    {
        private List<Card> cards;
        private List<Card> cardsOnTable;
        private List<Player> players;
        public Game(int numPlayers)
        {
            Logger.Write("Game", TypeMessage.Begin);
            CreateDeck();
            ShuffleCards(cards);
            Console.WriteLine("Колода карт после перетасовки:");
            PrintDeck();
            players = new List<Player>();
            for (int i = 0; i < numPlayers; i++)
            {
                players.Add(new Player(String.Format("Player {0}" , i + 1)));
            }
            Console.WriteLine("\nСписок карт каждого игрока после раздачи:");
            Distribution();
            Console.WriteLine();
            cardsOnTable = new List<Card>();
            int counterMove = 0;
            while (players.Count != 1)
            {
                Move(players, cardsOnTable);
                counterMove++;
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].cardsPlayer.Count == 0)
                    {
                        Console.WriteLine("{0} выбыл из игры на {1}-м ходу игры", players[i].Name, counterMove);
                        players.Remove(players[i]);
                        i--;
                    }
                }
                
                if (counterMove % 500 == 0) // Каждый 500-й ход карты перемешиваются, чтобы игра не была бесконечной
                {
                    foreach (var item in players)
                    {
                        ShuffleCards(item.cardsPlayer);
                    }
                }
            }
            Logger.Write("Game", TypeMessage.End);
            Console.WriteLine("Победил {0}", players[0].Name);
        }
        /// <summary>
        /// Создаем колоду из 36 карт
        /// </summary>
        private void CreateDeck()
        {
            cards = new List<Card>();
            Array typeCard = Enum.GetValues(typeof(TypeCard));
            Array valueCard = Enum.GetValues(typeof(ValueCard));
            for (int i = 0; i < valueCard.Length; i++)
            {
                for (int j = 0; j < typeCard.Length; j++)
                {
                    Card newCard = new Card();
                    newCard.ValueCard = (ValueCard)valueCard.GetValue(i);
                    newCard.TypeCard = (TypeCard)typeCard.GetValue(j);
                    cards.Add(newCard);
                }
            }
        }
        /// <summary>
        /// Перетасовка карт
        /// </summary>
        private void ShuffleCards(List<Card> cardsForShuffle)
        {
            Random random = new Random();
            int n = cardsForShuffle.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card temp = cardsForShuffle[k];
                cardsForShuffle[k] = cardsForShuffle[n];
                cardsForShuffle[n] = temp;
            }  
        }
        private void PrintDeck()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            foreach (var item in cards)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Раздача карт - даем из колоды по одной карте каждому игроку, пока в колоде не закончились карты, и выводим на экран карты каждого игрока с именем игрока
        /// </summary>
        private void Distribution()
        {
            do
            {
                foreach (var item in players)
                {
                    item.AddCard(cards[0]);
                    cards.RemoveAt(0);
                }
            }
            while (cards.Count != 0);
            foreach (var item in players)
            {
                item.PrintPlayerCards();
            }
        }
        /// <summary>
        /// Ход - ложим по одной карте на стол, находим максимальную. Если она одна, запоминаем индекс максимальной карты на столе, отдаем все карты игроку с этим индексом.
        /// Если максимальных карт несколько, то рекурсивно входим в этот же метод, пока максимальная карта не будет одна.
        /// Если при входе в метод рекурсивно второй (и более) раз у игрока заканчиваются карты, он удаляется из списка игроков.
        /// При поиске максимальной карты среди двух шестерка больше туза.
        /// Все накопившиеся карты кидаем в поле cards и в конце метода (без входа в рекурсию) отдаем их выйгравшему игроку.
        /// </summary>
        private void Move(List<Player> players, List<Card> cardsInMove)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].cardsPlayer.Count != 0)
                {
                    Card card = players[i].PutCard();
                    cards.Add(card);
                    cardsInMove.Add(card);
                }
                else
                {
                    players.Remove(players[i]);
                }
            }

            Card cardMax;
            if (cardsInMove.Count == 2)
            {
                if (cardsInMove[0].ValueCard == ValueCard.Six & cardsInMove[1].ValueCard == ValueCard.Ace) cardMax = cardsInMove[0];
                else if (cardsInMove[0].ValueCard == ValueCard.Ace & cardsInMove[1].ValueCard == ValueCard.Six) cardMax = cardsInMove[1];
                else cardMax = cardsInMove.Max();
            }
            else cardMax = cardsInMove.Max();

            int indexWinPlayer = 0;
            int counterMaxCards = 0;
            List<Player> playersForDisput = new List<Player>();

            for (int i = 0; i < cardsInMove.Count; i++)
            {
                if (cardMax.ValueCard == cardsInMove[i].ValueCard)
                {
                    indexWinPlayer = i;
                    counterMaxCards++;
                    playersForDisput.Add(players[i]);
                }
            }
            if (counterMaxCards > 1) Move(playersForDisput, new List<Card>());
            else
            {
                int count = cards.Count;
                for (int i = 0; i < count; i++)
                {
                    players[indexWinPlayer].AddCard(cards[0]);
                    cards.RemoveAt(0);
                }
            }
            cardsInMove.Clear();
        }
    }
}
