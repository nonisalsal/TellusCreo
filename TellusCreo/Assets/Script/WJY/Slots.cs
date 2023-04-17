using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour, IPointerClickHandler
{
    private GameObject inventory;

    public enum property { useable, displayable, empty };
    public property ItemProperty { get; set; }
    public string combinationItem { get; private set; }


    private string displayImage;

    void Start()
    {
        inventory = GameObject.Find("Inventory");
        
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        int currentClickNum = eventData.clickCount;

        Debug.Log("Mouse Click Button : Left");


        if (currentClickNum == 1)
        {
            inventory.GetComponent<Inventory>().previousSelectedSlot = inventory.GetComponent<Inventory>().currentSelectedSlot;
            inventory.GetComponent<Inventory>().currentSelectedSlot = this.gameObject;
            if (ItemProperty == Slots.property.displayable) DisplayItem();
        }
    }

    public void AssignProperty(int orderNumber, string displayImage)
    {
        ItemProperty = (property)orderNumber;
        this.displayImage = displayImage;
       
    }

    public void DisplayItem()
    {
        inventory.GetComponent<Inventory>().itemDisplayer.SetActive(true);
        inventory.GetComponent<Inventory>().itemDisplayer.GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/" + displayImage);
    }

    public void ClearSlot()
    {
        ItemProperty = Slots.property.empty;
        displayImage = "";
        combinationItem = "";
        transform.GetChild(0).GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/empty_item");
    }
}
