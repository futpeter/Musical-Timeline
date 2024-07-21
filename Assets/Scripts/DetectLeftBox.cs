using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectLeftBox : MonoBehaviour
{
   public GameManager gameManager;

    public int leftYearValue;

    public Rigidbody2D rb;

    DetectRightBox detectRightBox;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

           /* if (collision.gameObject.tag == "TableTop")
            {
                leftYearValue = -9999;
                Debug.Log("The cards release year is" + leftYearValue);

                //rb.simulated = false;
            }*/
            if (collision.gameObject.name == "CardNull")
            {
                leftYearValue = gameManager.cardNull.year;
                Debug.Log("The cards release year is" + leftYearValue);
                //return;


            }
            else if (collision.gameObject.name == "Card (1)")
            {
                leftYearValue = gameManager.card1.year;
                Debug.Log("The cards release year is" + leftYearValue);

            }
            else if (collision.gameObject.name == "Card (2)")
            {
                leftYearValue = gameManager.card2.year;
                Debug.Log("The cards release year is" + leftYearValue);


            }
            else if (collision.gameObject.name == "Card (3)")
            {
                leftYearValue = gameManager.card3.year;
                Debug.Log("The cards release year is" + leftYearValue);


            }
        

    }
}
