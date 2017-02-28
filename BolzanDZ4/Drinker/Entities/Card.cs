using Drinker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinker
{
    class Card : IComparable
    {
        public TypeCard TypeCard { get; set; }
        public ValueCard ValueCard { get; set; }
        public int CompareTo(Object obj)
        {
            Card objCard = (Card)obj;
            if (ValueCard > objCard.ValueCard) return 1;
            if (ValueCard < objCard.ValueCard) return -1;
            return 0;
        }
        public override string ToString()
        {
            string type = null;
            switch (TypeCard)
            {
                case TypeCard.Diamond:
                    type = "♦";
                    break;
                case TypeCard.Club:
                    type = "♣";
                    break;
                case TypeCard.Spade:
                    type = "♠";
                    break;
                case TypeCard.Heart:
                    type = "♥";
                    break;
                default:
                    break;
            }

            string value = null;
            switch (ValueCard)
            {
                case ValueCard.Six:
                    value = "6";
                    break;
                case ValueCard.Seven:
                    value = "7";
                    break;
                case ValueCard.Eight:
                    value = "8";
                    break;
                case ValueCard.Nine:
                    value = "9";
                    break;
                case ValueCard.Ten:
                    value = "10";
                    break;
                case ValueCard.Jack:
                    value = "J";
                    break;
                case ValueCard.Queen:
                    value = "Q";
                    break;
                case ValueCard.King:
                    value = "K";
                    break;
                case ValueCard.Ace:
                    value = "A";
                    break;
                default:
                    break;
            }

            return value + type;
        }
    }
}
