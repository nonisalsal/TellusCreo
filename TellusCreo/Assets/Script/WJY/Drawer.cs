using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drawer : MonoBehaviour, IInteractable
{
    public string UnlockItem;
    public string ChangeItem;

    private GameObject inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

 



    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            Debug.Log("unlock");
            inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slots>().ItemProperty = Slots.property.empty;
            inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/empty_item");

        }
    }

    
}
