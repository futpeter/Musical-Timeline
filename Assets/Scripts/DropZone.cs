using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.UI;
using System;
using UnityEngine.XR;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Draggable.Slot typeOfCard = Draggable.Slot.HAND;
    
    public GameManager gameManager;
    public bool moveCards = true;

    public string selectedCard;
    public string playSpaceString;
    public bool selectedCardOn = false;
    public bool selectedCardOn2 = false;

    DetectRightBox detectRightBox;

    public void OnPointerEnter(PointerEventData eventData)
    {

        //Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        //Debug.Log("OnPointerExit");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);


        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            if (typeOfCard == d.typeOfCard)
            {
                d.parentToReturnTo = this.transform;
            }
        }

        if(gameObject.name == "Tabletop" && selectedCardOn == false)
        {
            gameManager.ContinueButton.SetActive(true);

            typeOfCard = Draggable.Slot.PLAYED;

            eventData.pointerDrag.name = selectedCard;

            selectedCardOn = true;
        }
        
        if (selectedCardOn == true && selectedCard == eventData.pointerDrag.name && gameObject.name == "Hand")
        {
            selectedCardOn2 = true;
            Debug.Log(selectedCard);

        }

        if (selectedCardOn2 == true)
        {
            typeOfCard = Draggable.Slot.HAND;
            selectedCardOn = false;
        }
    }

    public void ContinueButton()
    {
        moveCards = false;
        detectRightBox.OnCollisionEnter = true;

    }
}