using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRightBox : MonoBehaviour
{
    public GameManager gameManager;

    public int rightYearValue;

    public Rigidbody2D rb;

    public bool OnCollisionEnter = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
           /* if (collision.gameObject.tag == "TableTop")
            {
                rightYearValue = 9999;
                Debug.Log("The cards release year is" + rightYearValue);

                //rb.simulated = false;

            }*/
            if (collision.gameObject.name == "CardNull")
            {
                rightYearValue = gameManager.cardNull.year;
                Debug.Log("The cards release year is" + rightYearValue);

            }
            else if (collision.gameObject.name == "Card (1)")
            {
                rightYearValue = gameManager.card1.year;
                Debug.Log("The cards release year is" + rightYearValue);

            }
            else if (collision.gameObject.name == "Card (2)")
            {
                rightYearValue = gameManager.card2.year;
                Debug.Log("The cards release year is" + rightYearValue);


            }
            else if (collision.gameObject.name == "Card (3)")
            {
                rightYearValue = gameManager.card3.year;
                Debug.Log("The cards release year is" + rightYearValue);


            }
        

        

    }
}
