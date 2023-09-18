using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ClickItem : MonoBehaviour
{
    private void OnDestroy()
    {
        Debug.Log("asdf");
        SoundManager.Instance.Play("item_get");
    }
}
