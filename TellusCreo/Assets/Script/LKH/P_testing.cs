using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_testing : MonoBehaviour
{
    public GameObject rayControl;

    private void PlayerInput()
    {
        if (rayControl.GetComponent<P_GameManager>().isUp == true)
        {
            RaycastHit2D upHit = rayControl.GetComponent<P_GameManager>().upHit;
            if (upHit)
            {
                if (System.Object.ReferenceEquals(this.transform.gameObject, upHit.collider.gameObject))
                {

                }
            }
        }
    }
}
