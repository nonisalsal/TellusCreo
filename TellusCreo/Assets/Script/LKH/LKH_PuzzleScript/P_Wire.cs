using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Wire : MonoBehaviour
{
    public GameObject rightItem;
    public GameObject connectWire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (System.Object.ReferenceEquals(collision.gameObject, rightItem))
        {
            P_GameManager.instance.Set_wireConnect();
            connectWire.SetActive(true);
            Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
