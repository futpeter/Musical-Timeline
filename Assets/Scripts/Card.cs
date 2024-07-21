using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject leftDetector;
    public GameObject rightDetector;
    public DetectRightBox detectRightBox;
    public DetectLeftBox detectLeftBox;

    public Draggable draggable;
    public HealthAndPointTracker healthAndPointTracker;

    public int id;
    public int year;
    public string artistName;
    public string songName;
    public string genreName;

    private bool detectButton;

    public Card()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TableTop")
        {
            detectButton = true;
        }
    }

    public void destroyDetector()
    {
        if (detectButton == true)
        {
            {
                Component.Destroy(draggable);
                
                leftDetector.SetActive(true);
                rightDetector.SetActive(true);
                HealthTracker();
                //ContinueGame
                
            }

        }
    }

    public void HealthTracker()
    {
        if (healthAndPointTracker.canScore == true && year > detectRightBox.rightYearValue)
        {
            healthAndPointTracker.canScore = false;
            healthAndPointTracker.health = healthAndPointTracker.health - 1;

            Debug.Log("LostHealth" + healthAndPointTracker.health);
        }

        if (healthAndPointTracker.canScore == true && year < detectLeftBox.leftYearValue)
        {
            healthAndPointTracker.canScore = false;
            healthAndPointTracker.health = healthAndPointTracker.health - 1;

            Debug.Log("Lost Health" + healthAndPointTracker.health);
        }

        else if (healthAndPointTracker.canScore == true)
        {
            healthAndPointTracker.canScore = false;
            healthAndPointTracker.point++;
            Debug.Log("Point increased" + healthAndPointTracker.point);
        }

    }
}
