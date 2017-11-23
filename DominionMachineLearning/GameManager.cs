﻿using DominionMachineLearning.CardClassFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominionMachineLearning;

namespace DominionMachineLearning
{
    /// <summary>
    /// keeps track of the game state
    /// and runs all necesary clean up of the actual game itself
    /// </summary>
    public class GameManager
    {
        public static Random rnd = new Random();
        public static List<IPlayers> players = new List<IPlayers>();
        public static bool gameEnd = true;

        public static List<Card> supplyPile = new List<Card>();

        /// <summary>
        /// runs a game of dominion
        /// </summary>
        public static void playGame()
        {
            setupGame();
            do
            {
                foreach(IPlayers player in players)
                {
                    player.playTurn();
                }


            }while(gameEnd);
        }

        /// <summary>
        /// sets up the game, gives players correct cards, sets up piles etc
        /// </summary>
        public static void setupGame()
        {
            
        }

        /// <summary>
        /// the player draws 5 cards from the deck
        /// </summary>
        /// <param name="player"></param>
        public static void drawHand(IPlayers player)
        {
            for(int i=0; i<5; i++)
            {
                drawCard(player);
            }
        }

        /// <summary>
        /// draws a single card from deck and places it in hand
        /// if the deck is empty it copys the discard to the deck, and clears the deck
        /// </summary>
        /// <param name="player"></param>
        public static void drawCard(IPlayers player)
        {
            if(player.deck.Count > 0)
            {
                Card rndCard = player.deck.ElementAt(rnd.Next(1, player.deck.Count));
                player.deck.Remove(rndCard);
                player.hand.Add(rndCard);
            }
            else
            {
                if(player.discard.Count > 0)
                {
                    player.deck = player.discard;

                    player.discard.Clear();

                    Card rndCard = player.deck.ElementAt(rnd.Next(1, player.deck.Count));
                    player.deck.Remove(rndCard);
                    player.hand.Add(rndCard);
                }
            }
        }

        /// <summary>
        /// outputs the supply piles
        /// displays the name of the card, cost, and how many of the card are available
        /// </summary>
        public static void outputSupplyPiles()
        {
            List<Card> tempCardList = new List<Card>(); //temporary list of cards for searching through

            int[] numOfCard = new int[supplyPile.Count];    //array of how many of each card are in the supply pile


            int i = 0;

            foreach(Card card in supplyPile)
            {
                if (tempCardList.Contains(card))
                {
                    numOfCard[i]++;
                }
                else
                {
                    i++;
                    tempCardList.Add(card);
                }
            }

            i = 0;
            Console.WriteLine("Name Cost #Available");
            foreach(Card card in tempCardList)
            {
                Console.WriteLine(card.name + " " + card.cost + " " + numOfCard[i]);
                i++;
            }
        }
    }
}
