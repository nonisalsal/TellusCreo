using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drawer : MonoBehaviour
{
    public string UnlockItem;
    public GameObject respawn;
    private GameObject inventory;

    void Start()
    {
        respawn = GameObject.FindWithTag("box");
        inventory = GameObject.Find("Inventory");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
                {

                    Debug.Log("unlock");
                    //inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slots>().ItemProperty = Slots.property.empty;
                    //inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite =
                    //    Resources.Load<Sprite>("Inventory Items/empty_item");

                }
            }

        }
       


        }


    }

