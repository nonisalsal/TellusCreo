using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class on : MonoBehaviour
{
    public GameObject pair;
    public GameObject clear;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == pair)
        {
            clear.SetActive(true);
        }
    }
}
