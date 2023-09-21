using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;

    private void Awake()
    {
        instance = this;
    }

    public List<ItemData> itemDB = new List<ItemData>();

    public GameObject ItemPrefab;
   
}
