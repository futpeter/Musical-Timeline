using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using JetBrains.Annotations;
using Unity.VisualScripting;
using System;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 r;

    //public int health = 3;
    //public GameObject RightBox;
    //public GameObject LeftBox;

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    public enum Slot{ HAND, PLAYED };
    public Slot typeOfCard = Slot.HAND;

    GameObject placeholder;

    public bool canDrag = true;

    //public DetectLeftBox detectLeftBox;
    //public DetectRightBox detectRightBox;
    //public Card card;

    //private void Start()
    //{
      //  RightBox.SetActive(false);
        //LeftBox.SetActive(false);
    //}

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag == true)
        {
            Debug.Log("OnBeginDrag");

            placeholder = new GameObject();
            placeholder.transform.SetParent(this.transform.parent);
            LayoutElement le = placeholder.AddComponent<LayoutElement>();
            le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
            le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
            RectTransform rt = placeholder.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(125, 200);
            le.flexibleWidth = 0;
            le.flexibleHeight = 0;

            placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            parentToReturnTo = this.transform.parent;
            placeholderParent = parentToReturnTo;
            this.transform.SetParent(this.transform.parent.parent);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag == true)
        {
            //Debug.Log ("OnDrag");

            this.transform.position = eventData.position;

            if (placeholder.transform.parent != placeholderParent)
                placeholder.transform.SetParent(placeholderParent);

            int newSiblingIndex = placeholderParent.childCount;

            for (int i = 0; i < placeholderParent.childCount; i++)
            {
                if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
                {

                    newSiblingIndex = i;

                    if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                        newSiblingIndex--;


                    break;
                }
            }

            placeholder.transform.SetSiblingIndex(newSiblingIndex);

            //RightBox.SetActive(true);
            //LeftBox.SetActive(true);

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeholder);

       
        
    }

   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (detectLeftBox.leftYearValue > card.year && collision.gameObject.tag == "Card")
        {
            health--;
            Debug.Log("You have " + health + "health left");
            RightBox.SetActive(false);
            LeftBox.SetActive(false);

        }
        else if(detectRightBox.rightYearValue < card.year && collision.gameObject.tag == "Card")
        {
            health--;
            Debug.Log("You have " + health + "health left");
            RightBox.SetActive(false);
            LeftBox.SetActive(false);
        }
        else if(gameObject.tag == "Tabletop")
        {
            Debug.Log("NEXT TURN");
        }
    }*/
    
}
