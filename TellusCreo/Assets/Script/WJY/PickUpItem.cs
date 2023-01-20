using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{

    public string DisplaySprite;
    public enum property { usable, displayable };

    public property itemProperty;

    private GameObject InventorySlots;

    public string DisplayImage;

    private void OnMouseDown()
    {
        ItemPickUp();
    }

    void Start()
    {
        InventorySlots = GameObject.Find("Slots");
    }

    void ItemPickUp()
    {
        

        foreach (Transform slot in InventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                
                slot.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);
                slot.GetComponent<Slots>().AssignProperty((int)itemProperty, DisplayImage);
                Destroy(gameObject);
                break;
            }
        }
    }


}
