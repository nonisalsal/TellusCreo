using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetTissue : MonoBehaviour
{

    bool clear;
    public GameObject mars;

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
            tissueList.RemoveAt(0);
            if (tissueList.Count > 0)
            {
                tissueList[0].SetActive(true);
            }
        }
        else
        {
            if (!clear)
            {
                clear = true;
                Instantiate(mars, transform.position, Quaternion.identity).transform.SetParent(this.transform);
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
        order = false;
        clear = false;
    }
}
