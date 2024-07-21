using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Card cardNull;
    public Card card1;
    public Card card2;
    public Card card3;

    public GameObject CardNull;
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;

    public GameObject LeftBox;
    public GameObject LeftBox1;
    public GameObject LeftBox2;
    public GameObject LeftBox3;

    public GameObject RightBox;
    public GameObject RightBox1;
    public GameObject RightBox2;
    public GameObject RightBox3;

    public GameObject ContinueButton;

    public void Start()
    {
        CardNull = GameObject.Find("CardNull");
        Card1 = GameObject.Find("Card (1)");
        Card2 = GameObject.Find("Card (2)");
        Card3 = GameObject.Find("Card (3)");


        cardNull = CardNull.GetComponent<Card>();
        card1 = Card1.GetComponent<Card>();
        card2 = Card2.GetComponent<Card>();
        card3 = Card3.GetComponent<Card>();

        LeftBox = CardNull.transform.GetChild(4).gameObject;
        LeftBox1 = Card1.transform.GetChild(4).gameObject;
        LeftBox2 = Card2.transform.GetChild(4).gameObject;
        LeftBox3 = Card3.transform.GetChild(4).gameObject;

        RightBox = CardNull.transform.GetChild(3).gameObject;
        RightBox1 = Card1.transform.GetChild(3).gameObject;
        RightBox2 = Card2.transform.GetChild(3).gameObject;
        RightBox3 = Card3.transform.GetChild(3).gameObject;

        ContinueButton.SetActive(false);

        yearDetectorFalse();
    }

    public void yearDetectorFalse()
    {
        LeftBox.SetActive(false);
        LeftBox1.SetActive(false);
        LeftBox2.SetActive(false);
        LeftBox3.SetActive(false);

        RightBox.SetActive(false);
        RightBox1.SetActive(false);
        RightBox2.SetActive(false);
        RightBox3.SetActive(false);

    }    
}

