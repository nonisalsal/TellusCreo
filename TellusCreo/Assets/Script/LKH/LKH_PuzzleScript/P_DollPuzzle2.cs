using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DollPuzzle2 : MonoBehaviour
{
    public GameObject pair;
    public GameObject clear;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (System.Object.ReferenceEquals(collision.gameObject, pair))
        {
            clear.SetActive(true);
            Destroy(collision.gameObject.GetComponent<P_DragAndDrop>());
            collision.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
