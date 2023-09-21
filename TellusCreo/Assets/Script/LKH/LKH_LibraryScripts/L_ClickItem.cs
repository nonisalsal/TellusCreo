using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ClickItem : MonoBehaviour
{
    [SerializeField] private bool hasPair = false;

    private void OnDestroy()
    {
        Debug.Log("asdf");
        SoundManager.Instance.Play("item_get");

        if (hasPair)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
