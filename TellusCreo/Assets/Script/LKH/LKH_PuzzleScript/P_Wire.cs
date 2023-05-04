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
            Instantiate(connectWire);
            FindObjectOfType<P_ClickObj>().setConnectWire();
            Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (System.Object.ReferenceEquals(collision.gameObject, rightItem))
        {
            Instantiate(connectWire);
            FindObjectOfType<P_ClickObj>().setConnectWire();
            Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
