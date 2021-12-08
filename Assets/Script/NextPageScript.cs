using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPageScript : MonoBehaviour
{
    private GameObject manager;
    private CardManager cardManager;
    private Button nextButton;

    void Start()
    {
        //CardManagerを取得
        manager = GameObject.Find("CardManager");
        cardManager = manager.GetComponent<CardManager>();

        //現在のボタンを取得
        nextButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cardManager.firstKey >= cardManager.pageMax)
        {
            cardManager.firstKey = cardManager.pageMax;
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }
    }

    public void OnClick()
    {
        cardManager.firstKey += 6;
        cardManager.pageMove = true;
        Debug.Log("firstKey"+cardManager.firstKey);
    }
}
