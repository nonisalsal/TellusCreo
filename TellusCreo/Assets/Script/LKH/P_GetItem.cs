using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_GetItem : MonoBehaviour
{
    private void OnDestroy()
    {
        SoundManager.Instance.Play("item_get");
    }
}
