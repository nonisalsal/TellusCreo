using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ClickItem : MonoBehaviour
{
    public GameObject rayControl;

    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        if (rayControl.GetComponent<P_GameManager>().isUp)
        {
            RaycastHit2D upHit = rayControl.GetComponent<P_GameManager>().upHit;
            if (System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
            {
                Debug.Log("Get Spin A");
                // 인벤토리
                Destroy(this.gameObject);
            }
        }
    }
}
