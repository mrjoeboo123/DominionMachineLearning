﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionMachineLearning.CardClassFiles
{
    class Village : Card
    {
        //All variables are set to the according values for the Village card
        //notable variable of the Village card:
        //  cost = 3
        //  name = "VILLAGE"
        //  isAction = true
        //  bonusDraw = 1
        //  bonusAction = 2


        public Village()
        {
            cost = 3;

            name = "VILLAGE";

            isAction = true;
            isVictory = false;
            isTreasure = false;

            bonusAction = 2;
            bonusTreasure = 0;
            bonusDraw = 1;
            bonusBuy = 0;

            victoryPoint = 0;

            hasOwnAttribute = false;
        }

        public void playCard(IPlayers player)
        {
            GameManager.drawCard(player);

            player.currentAction--;
            player.currentAction += bonusAction;
        }

        public int cost //cost to buy the card
        {
            get;
            set;
        }

        public string name     //name of the card
        {
            get;
            set;
        }

        public bool isAction   //true if the card is an action card
        {
            get;
            set;
        }

        public bool isVictory  //true if the card is a victory card
        {
            get;
            set;
        }

        public bool isTreasure //true if the card is a treasure card
        {
            get;
            set;
        }

        public int bonusAction     //number of bonus actions the card gives when played
        {
            get;
            set;
        }

        public int bonusTreasure   //number of bonus treasure the card gives when played
        {
            get;
            set;
        }

        public int bonusDraw       //number of bonus draws the card gives when played
        {
            get;
            set;
        }

        public int bonusBuy        //number of bonus buys the card gives when played
        {
            get;
            set;
        }

        public int victoryPoint    //number of victory points this card is worth
        {
            get;
            set;
        }

        public bool hasOwnAttribute    //true when the card has a specific action when played that
        {                       //  applies to this card
            get;
            set;
        }
    }
}
