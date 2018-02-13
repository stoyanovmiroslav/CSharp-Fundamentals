using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputFirstLine = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] inputSecondtLine = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> firstPlayer = new Queue<string>(inputFirstLine);
            Queue<string> secondPlayer = new Queue<string>(inputSecondtLine);

            int turn = 1;
            while (turn < 1_000_000 || firstPlayer.Count == 0 || secondPlayer.Count == 0)
            {
                List<CardsOnDesk> cardOnDesckList = new List<CardsOnDesk>();

                string playerOneCard = firstPlayer.Dequeue();
                AddCardsOnDesk(playerOneCard, cardOnDesckList);

                string playerTwoCard = secondPlayer.Dequeue();
                AddCardsOnDesk(playerTwoCard, cardOnDesckList);

                if (cardOnDesckList[0].Number == cardOnDesckList[1].Number)
                {
                    Wars(cardOnDesckList, firstPlayer, secondPlayer, turn);
                }
                else if (cardOnDesckList[0].Number > cardOnDesckList[1].Number)
                {
                    SortCards(ref cardOnDesckList);
                    for (int i = 0; i < cardOnDesckList.Count; i++)
                    {
                        string card = $"{cardOnDesckList[i].Number}{cardOnDesckList[i].Character}";
                        firstPlayer.Enqueue(card);
                    }
                }
                else if (cardOnDesckList[0].Number < cardOnDesckList[1].Number)
                {
                    SortCards(ref cardOnDesckList);
                    for (int i = 0; i < cardOnDesckList.Count; i++)
                    {
                        string card = $"{cardOnDesckList[i].Number}{cardOnDesckList[i].Character}";
                        secondPlayer.Enqueue(card);
                    }
                }

                if (firstPlayer.Count == 0)
                {

                    Console.WriteLine("Second player wins after {0} turns", turn);
                    Environment.Exit(0);
                }
                else if (secondPlayer.Count == 0)
                {
                    Console.WriteLine("First player wins after {0} turns", turn);
                    Environment.Exit(0);
                }

                turn++;

                if (turn > 10000)
                {
                    turn = 1000000;
                    break;
                }
            }

            if (firstPlayer.Count < secondPlayer.Count)
            {

                Console.WriteLine("Second player wins after {0} turns", turn);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("First player wins after {0} turns", turn);
                Environment.Exit(0);
            }
        }

        private static void SortCards(ref List<CardsOnDesk> cardOnDesckList)
        {
            cardOnDesckList = cardOnDesckList.OrderByDescending(x => x.Number).ThenByDescending(x => x.Character).ToList();
        }

        private static void Wars(List<CardsOnDesk> cardOnDesckList, Queue<string> firstPlayer, Queue<string> secondPlayer, int turn)
        {
            if (firstPlayer.Count == 0 || secondPlayer.Count == 0)
            {
                Console.WriteLine("Draw after {0} turns", turn);
                Environment.Exit(0);
            }

            for (int i = 0; i < 3; i++)
            {
                string playerCard = firstPlayer.Dequeue();
                AddCardsOnDesk(playerCard, cardOnDesckList);
            }

            int sumFirstPlayer = 0;

            for (int i = cardOnDesckList.Count - 3; i < cardOnDesckList.Count; i++)
            {
                sumFirstPlayer += cardOnDesckList[i].Character;
            }

            for (int i = 0; i < 3; i++)
            {
                string playerCard = secondPlayer.Dequeue();
                AddCardsOnDesk(playerCard, cardOnDesckList);
            }

            int sumSecondPlayer = 0;

            for (int i = cardOnDesckList.Count - 3; i < cardOnDesckList.Count; i++)
            {
                sumSecondPlayer += cardOnDesckList[i].Character;
            }

            if (sumFirstPlayer == sumSecondPlayer)
            {
                Wars(cardOnDesckList, firstPlayer, secondPlayer, turn);
            }
            else if (sumFirstPlayer > sumSecondPlayer)
            {
                SortCards(ref cardOnDesckList);
                for (int i = 0; i < cardOnDesckList.Count; i++)
                {
                    string card = $"{cardOnDesckList[i].Number}{cardOnDesckList[i].Character}";
                    firstPlayer.Enqueue(card);
                }
            }
            else if (sumFirstPlayer < sumSecondPlayer)
            {
                SortCards(ref cardOnDesckList);
                for (int i = 0; i < cardOnDesckList.Count; i++)
                {
                    string card = $"{cardOnDesckList[i].Number}{cardOnDesckList[i].Character}";
                    secondPlayer.Enqueue(card);
                }
            }
        }

        private static void AddCardsOnDesk(string playerCard, List<CardsOnDesk> cardOnDesckList)
        {
            int cardNumber = int.Parse(playerCard.Substring(0, playerCard.Length - 1));
            char cardCharacter = char.Parse(playerCard.Substring(playerCard.Length - 1));

            CardsOnDesk cardOnDesck = new CardsOnDesk();
            cardOnDesck.Number = cardNumber;
            cardOnDesck.Character = cardCharacter;
            cardOnDesckList.Add(cardOnDesck);
        }
    }
}
class CardsOnDesk
{
    public int Number { get; set; }
    public char Character { get; set; }
}