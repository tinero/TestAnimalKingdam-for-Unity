using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.Card;
using System.Reflection;

public class CardManager : MonoBehaviour
{
    private List<int> Id = new List<int>();
    private List<int> Power = new List<int>();
    private List<string> Name = new List<string>();
    private List<string> Group = new List<string>();
    private List<string> Type = new List<string>();
    private List<string> Image = new List<string>();
    private List<object> Ability = new List<object>();

    private List<int> sortId = new List<int>();

    public Text cardPower1;
    public Text cardPower2;
    public Text cardPower3;
    public Text cardPower4;
    public Text cardPower5;
    public Text cardPower6;
    public Image cardImage1;
    public Image cardImage2;
    public Image cardImage3;
    public Image cardImage4;
    public Image cardImage5;
    public Image cardImage6;
    public Image typeImage1;
    public Image typeImage2;
    public Image typeImage3;
    public Image typeImage4;
    public Image typeImage5;
    public Image typeImage6;

    private List<Text> cardPower = new List<Text>();
    private List<Image> cardImage = new List<Image>();
    private List<Image> typeImage = new List<Image>();

    private string[] cardList = new string[] { "SetCard1", "SetCard2", "SetCard3", "SetCard4", "SetCard5", "SetCard6" };
    private string[] powerList = new string[] { "setPower1", "setPower2", "setPower3", "setPower4", "setPower5", "setPower6" };
    private string[] typeList = new string[] { "setType1", "setType2", "setType3", "setType4", "setType5", "setType6" };
    [NonSerialized] public int firstKey = 0;//�I�𕔂̍ł����̃J�[�h�̏ꏊ���w��

    [NonSerialized] public bool pageMove = false;//page�̐؂�ւ��p

    [NonSerialized] public int pageMax;
    [NonSerialized] public int pageMin;

    private DeckOrigin preDeck;
    private SelectDeck preSelectDeck;//�I������Ă���f�b�L


    private void Awake()
    {
        preSelectDeck = Resources.Load<SelectDeck>("Decklist/preSelectDeck");
        AllFindCard();
        SortList();
        preDeck = Resources.Load<DeckOrigin>("DeckList/Deck1");
        preDeck.deckName = "testDeck1";

    }
    void Start()
    {
        Debug.Log(string.Join(",", Id));
        SetCard();
        pageMax = Id.Count - 6;
        pageMin = Id.Min();
    }

    void Update()
    {
        if (pageMove == true)
        {
            pageMove = false;
            SetCard();
        }
    }

    /// <summary>
    /// �J�[�h�����ׂĎ擾
    /// </summary>
    private void AllFindCard()
    {
        //ICard���p�������N���X�̒���GameObject�ɃA�^�b�`����Ă�����̂��擾
        ICard[] getAllCard = GetCard.FindObjectOfInterfaces<ICard>();
        for (int i = 0; i < getAllCard.Length; i++)
        {
            /*object��type�ɕϊ�*/
            var card = getAllCard[i].GetType();

            Debug.Log("0cardType0 "+card);
            /*�C���X�^���X�𐶐�*/
            var getCard = gameObject.AddComponent(card);

            //�e�N���X�̃v���p�e�B���擾���eList�ɒǉ�
            Id.Add((int)card.InvokeMember("Id", BindingFlags.GetProperty, null, getCard, null));
            sortId.Add((int)card.InvokeMember("Id", BindingFlags.GetProperty, null, getCard, null));
            Group.Add((string)card.InvokeMember("CardGroup", BindingFlags.GetProperty, null, getCard, null));
            Image.Add((string)card.InvokeMember("CardImage", BindingFlags.GetProperty, null, getCard, null));
            Name.Add((string)card.InvokeMember("CardName", BindingFlags.GetProperty, null, getCard, null));
            Power.Add((int)card.InvokeMember("CardPower", BindingFlags.GetProperty, null, getCard, null));
            Type.Add((string)card.InvokeMember("CardType", BindingFlags.GetProperty, null, getCard, null));
            Ability.Add(card.InvokeMember("CardAbility", BindingFlags.GetProperty, null, getCard, null));

        }

        sortId.Sort();

    }

    /// <summary>
    /// List���̃\�[�g
    /// </summary>
    private void SortList()
    {
        List<int> sortPower = new List<int>();
        List<string> sortName = new List<string>();
        List<string> sortGroup = new List<string>();
        List<string> sortType = new List<string>();
        List<string> sortImage = new List<string>();
        List<object> sortAbility = new List<object>();

        //sortList�ɒǉ�
        for (int i = 0; i < Id.Count; i++)
        {
            Debug.Log("Id" + string.Join(",", Id));
            Debug.Log("sortId" + string.Join(",", sortId));

            for (int j = 0; j < Id.Count; j++)
            {
                if (sortId[i] == Id[j])
                {
                    sortPower.Add(Power[j]);
                    sortName.Add(Name[j]);
                    sortGroup.Add(Group[j]);
                    sortType.Add(Type[j]);
                    sortImage.Add(Image[j]);
                    sortAbility.Add(Ability[j]);

                    Debug.Log(sortId[i]);
                    Debug.Log(Id[j]);
                    Debug.Log(Power[j]);

                    break;
                }
            }
        }
        //sortList�̒��g��List�ɒǉ�
        Id = sortId;
        Power = sortPower;
        Name = sortName;
        Group = sortGroup;
        Type = sortType;
        Image = sortImage;
        Ability = sortAbility;

    }




    /// <summary>
    /// �擾�����J�[�h��\��
    /// </summary>
    private void SetCard()
    {


        cardPower.Add(cardPower1);
        cardPower.Add(cardPower2);
        cardPower.Add(cardPower3);
        cardPower.Add(cardPower4);
        cardPower.Add(cardPower5);
        cardPower.Add(cardPower6);

        cardImage.Add(cardImage1);
        cardImage.Add(cardImage2);
        cardImage.Add(cardImage3);
        cardImage.Add(cardImage4);
        cardImage.Add(cardImage5);
        cardImage.Add(cardImage6);

        typeImage.Add(typeImage1);
        typeImage.Add(typeImage2);
        typeImage.Add(typeImage3);
        typeImage.Add(typeImage4);
        typeImage.Add(typeImage5);
        typeImage.Add(typeImage6);

        int firstCard = firstKey;

        Debug.Log(string.Join(",", Id));
        //�I�𕔂ɃZ�b�g
        for (int i = 0; i < 6; i++)
        {
            //�\���ꏊ���w��
            this.cardPower[i] = GameObject.Find(powerList[i]).GetComponent<Text>();
            this.typeImage[i] = GameObject.Find(typeList[i]).GetComponent<Image>();
            this.cardImage[i] = GameObject.Find(cardList[i]).GetComponent<Image>();

            cardPower[i].text = Power[firstKey].ToString();
            typeImage[i].sprite = Resources.Load<Sprite>(Type[firstKey]);
            cardImage[i].sprite = Resources.Load<Sprite>(Image[firstKey]);
            firstKey++;

        }
        firstKey = firstCard;
    }


}



