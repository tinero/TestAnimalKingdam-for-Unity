using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Card
{
    public class TestPower8 : MonoBehaviour, ICard
    {
        public int Id
        {
            get { return 20; }
        }
        public object CardAbility
        {
            get { return null; }
        }

        public string CardGroup
        {
            get { return "test"; }
        }

        public string CardImage
        {
            get { return "CardImage/TestPower8"; }
        }

        public string CardName
        {
            get { return "TestPower8"; }
        }

        public int CardPower
        {
            get { return 8; }
        }

        public string CardType
        {
            get { return "OtherImage/Middle"; }
        }
    }
}