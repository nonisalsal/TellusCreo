using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustMirror : MonoBehaviour
{
    private void OnMouseDown()
    {
     
        if (InventoryManager.Instance.HasItem("Tissue"))
        {
            Destroy(gameObject);
        }
    }
}
