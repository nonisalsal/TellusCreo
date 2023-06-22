using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PickUpItem : MonoBehaviour
{

    public string DisplaySprite;


    public enum property { usable, displayable };

    public property itemProperty;

    public GameObject InventorySlots;

    public string DisplayImage;

    public Sprite[] sprites;

    public int i = 0;

    //private void OnMouseDown()
    //{
    //    if (!EventSystem.current.IsPointerOverGameObject())
    //    {

    //    }

    //}

    void Start()
    {
        

        sprites = Resources.LoadAll<Sprite>("Inventory Items");
    }

    void Update()
    {
        Debug.DrawRay(transform.position, new Vector3(1, 0, 0), new Color(0, 1, 0));

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && gameObject.CompareTag("Item"))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                ItemPickUp();
                Vector3 forward = transform.TransformDirection(Vector3.forward) * 5;
                
            }
        }
    }
    void ItemPickUp()
    {
        

        foreach (Transform slot in InventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {

                slot.transform.GetChild(0).GetComponent<Image>().sprite = sprites[i];
                slot.GetComponent<Slots>().AssignProperty((int)itemProperty, DisplayImage);
                Destroy(gameObject);
                break;
            }
        }
    }


}
