using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ClickItem : MonoBehaviour
{
    private void OnDestroy()
    {
        SoundManager.Instance.Play("item_get");
    }
}
