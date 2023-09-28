using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_GetItem : MonoBehaviour
{
    private void OnDestroy()
    {
        if (SoundManager.Instance != null)
            SoundManager.Instance.Play("item_get");

        if (this.CompareTag("item_final_soil_puzzle"))
            P_GameManager.instance.Set_isGetFinalItem();
    }
}
