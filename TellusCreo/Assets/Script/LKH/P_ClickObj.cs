using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ClickObj : MonoBehaviour
{
    public GameObject rayControl;

    private bool[] getItem;
    private bool getKey_A;
    private bool getKey_B;
    private bool getPattern;
    private bool contectWire;
    private bool getWire;

    void Start()
    {
        getItem = new bool[8] { false, false, false, false, false, false, false, false };
    }

    void Update()
    {
        if (FindObjectOfType<P_Camera>().playPuzzle == false)
        {
            PlayerInput();
        }
    }

    private void PlayerInput()
    {
        if (rayControl.GetComponent<P_GameManager>().isUp == true)
        {
            RaycastHit2D upHit = rayControl.GetComponent<P_GameManager>().upHit;
            if (upHit)
            {
                if (getItem[0] == false && System.Object.ReferenceEquals(this.transform.GetChild(0), upHit.collider.gameObject.transform))
                {
                    if (!getKey_A) { Debug.Log("Need 'Key_A'"); }
                    else { 
                        Debug.Log("Get 'Wire'");
                        getItem[0] = true;
                    }
                }
                if (getItem[1] == false && System.Object.ReferenceEquals(this.transform.GetChild(1), upHit.collider.gameObject.transform))
                {
                    Debug.Log("Get 'Guitar'");
                    getItem[1] = true;
                }
                if (getItem[2] == false && System.Object.ReferenceEquals(this.transform.GetChild(2), upHit.collider.gameObject.transform))
                {
                    Debug.Log("Get 'Key_A'");
                    getKey_A = true;
                    getItem[2] = true;
                }
                if (getItem[3] == false && System.Object.ReferenceEquals(this.transform.GetChild(3), upHit.collider.gameObject.transform))
                {
                    if (!getPattern) { Debug.Log("Need 'Pattern'"); }
                    else
                    {
                        Debug.Log("Get 'Fianl_Item'");
                        getItem[3] = true;
                    }
                }
                if (getItem[4] == false && System.Object.ReferenceEquals(this.transform.GetChild(4), upHit.collider.gameObject.transform))
                {
                    Debug.Log("Get 'Violin'");
                    getItem[4] = true;
                }
                if (getItem[5] == false && System.Object.ReferenceEquals(this.transform.GetChild(5), upHit.collider.gameObject.transform))
                {
                    if (!contectWire) { Debug.Log("Need 'Contect Wire'"); }
                    else
                    {
                        Debug.Log("Get 'Top_B'");
                        getItem[5] = true;
                    }
                }
                if (getItem[6] == false && System.Object.ReferenceEquals(this.transform.GetChild(6), upHit.collider.gameObject.transform))
                {
                    if (!getKey_B) { Debug.Log("Need 'Key_B'"); }
                    else
                    {
                        Debug.Log("Get 'Top_C'");
                        getItem[6] = true;
                    }
                }
                if (getItem[7] == false && System.Object.ReferenceEquals(this.transform.GetChild(7), upHit.collider.gameObject.transform))
                {
                    if (!getWire) { Debug.Log("Need 'Wire'"); }
                    else
                    {
                        Debug.Log("Use 'Lamp'");
                        getItem[7] = true;
                    }
                }
            }
        }
    }
}
