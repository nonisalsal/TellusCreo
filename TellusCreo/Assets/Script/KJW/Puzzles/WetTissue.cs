using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetTissue : MonoBehaviour
{
    bool isFirstClick = true;
    bool clear;
    public GameObject mars;
    public Item Item;

    [SerializeField]
    Transform spwanPos;

    [SerializeField]
    GameObject tissue;

    List<GameObject> tissueList = new List<GameObject>();
    bool order;
    private void OnMouseDown()
    {
        if (tissueList.Count > 0)
        {
            tissueList[0].GetComponent<Tissue>().PullTissue((order = !order));
            var itemPickupComponent = tissueList[0].GetComponent<ItemPickup>();
            if (itemPickupComponent != null)
            {
                InventoryManager.Instance.Add(itemPickupComponent.Item);
            }
            tissueList.RemoveAt(0);
            if (tissueList.Count > 0)
            {
                tissueList[0].SetActive(true);
                SoundManager.Instance.Play("puzzle_tissue");
            }
        }
        else
        {
            if (!clear)
            {
                clear = true;
                SoundManager.Instance.Play("puzzle_clear");
                GameObject Mars = Instantiate(mars, transform.position, Quaternion.identity);
                Mars.transform.SetParent(this.transform);
                Mars.transform.localPosition = new Vector3(0.0f, 0.8f, 0.0f);
            }
        }
    }

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject tempGamObj = Instantiate(tissue, spwanPos.position, Quaternion.identity, this.transform);
            tempGamObj.SetActive(false);
            tempGamObj.GetComponent<SpriteRenderer>().sortingOrder = 0;
            tempGamObj.AddComponent<Rigidbody2D>().simulated = false;
            tissueList.Add(tempGamObj);
        }
        tissueList[0].SetActive(true);
        tissueList[0].AddComponent<ItemPickup>();
        tissueList[0].GetComponent<ItemPickup>().Item = Item;


        order = false;
        clear = false;
    }
}
