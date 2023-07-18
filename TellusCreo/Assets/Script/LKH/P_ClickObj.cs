using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ClickObj : MonoBehaviour
{
    public GameObject rayControl;

    private bool[] getItem;
    private bool getKey_A;

    void Start()
    {
        getItem = new bool[8] { false, false, false, false, false, false, false, false };
        getKey_A = false;
    }

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
                if (getItem[0] == false && System.Object.ReferenceEquals(this.transform.GetChild(0).gameObject, rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    Debug.Log("click");
                    this.transform.GetChild(0).gameObject.GetComponent<P_PuzzleInfo>().moveCamera();
                }
                if (getItem[1] == false && System.Object.ReferenceEquals(this.transform.GetChild(1).gameObject, 
                    rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    Debug.Log("Get 'Violin'");
                    this.transform.GetChild(1).gameObject.SetActive(false);
                    getItem[3] = true;
                }
                if (getItem[2] == false && System.Object.ReferenceEquals(this.transform.GetChild(2).gameObject, 
                    rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    if (rayControl.GetComponent<P_GameManager>().Get_wireConnect())
                    {
                        Debug.Log("click");
                        this.transform.GetChild(2).gameObject.GetComponent<P_PuzzleInfo>().moveCamera();
                    }
                    else
                    {
                        Debug.Log("Need 'Connect Wire'");
                    }
                }
                if (getItem[3] == false && System.Object.ReferenceEquals(this.transform.GetChild(3).gameObject, 
                    rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    Debug.Log("click");
                    this.transform.GetChild(3).gameObject.GetComponent<P_PuzzleInfo>().moveCamera();
                }
                if (getItem[4] == false && System.Object.ReferenceEquals(this.transform.GetChild(4).gameObject,
                    rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    Debug.Log("click");
                    this.transform.GetChild(4).gameObject.GetComponent<P_PuzzleInfo>().moveCamera();
                }
                if (getItem[5] == false && System.Object.ReferenceEquals(this.transform.GetChild(5).gameObject,
                    rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    Debug.Log("click");
                    this.transform.GetChild(5).gameObject.GetComponent<P_PuzzleInfo>().moveCamera();
                }
            }
        }
    }
}
