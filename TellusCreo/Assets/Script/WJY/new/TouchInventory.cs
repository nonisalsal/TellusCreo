using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInventory : MonoBehaviour
{
    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }

    private GameObject slots;

    public GameObject itemDisplayer { get; private set; }

    void Start()
    {
        InitializeInventory();


    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            SelectSlot();
            HideDisplay();

        }



    }

    void InitializeInventory()
    {
        slots = GameObject.Find("Item");
        itemDisplayer = GameObject.Find("ItemDisplayer");
        itemDisplayer.SetActive(false);
        foreach (Transform slot in slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/empty_Item");
            slot.GetComponent<Slots>().ItemProperty = Slots.property.empty;
        }
        currentSelectedSlot = GameObject.Find("slot");
        previousSelectedSlot = currentSelectedSlot;
    }


    void SelectSlot()
    {
        foreach (Transform slot in slots.transform)
        {
            if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slots>().ItemProperty == Slots.property.useable)
            {
                slot.GetComponent<Image>().color = new Color(.9f, .4f, .6f, 1);
            }
            else if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slots>().ItemProperty == Slots.property.displayable)
            {
                //slot.GetComponent<Slot>().DisplayItem();
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }

    void HideDisplay()
    {

        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            itemDisplayer.SetActive(false);
            if (currentSelectedSlot.GetComponent<Slots>().ItemProperty == Slots.property.displayable)
            {
                currentSelectedSlot = previousSelectedSlot;
                previousSelectedSlot = currentSelectedSlot;
            }
        }
    }
}
