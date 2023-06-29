using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_test : MonoBehaviour
{
    public GameObject pair;
    public GameObject rayControl;

    //void Start()
    //{
        
    //}

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (rayControl.GetComponent<P_GameManager>().isUp)
        {
            if (rayControl.GetComponent<P_GameManager>().upHit)
            {
                if (System.Object.ReferenceEquals(this.gameObject, rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    pair.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
