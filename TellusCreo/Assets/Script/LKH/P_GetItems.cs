using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_GetItems : MonoBehaviour
{
    public GameObject rayControl;
    public GameObject parentObj;

    //private GameObject dollPuzzle2;
    //private GameObject picturePuzzle;
    //private GameObject clockPuzzle;
    //private GameObject towerPuzzle;
    //private GameObject topPuzzle;

    private GameObject[] objList;
    private bool[] getItem;
    private bool getKey_A;
    private bool getKey_B;
    private bool getPattern;
    private bool contectWire;
    private bool getWire;

    private bool[] clearPuzzle;

    void Start()
    {
        getItem = new bool[8] { false, false, false, false, false, false, false, false };
        objList = new GameObject[8];
        for (int i=0; i<8; i++)
        {
            objList[i] = parentObj.transform.GetChild(i).gameObject;
        }

        clearPuzzle = new bool[5] { false, false, false, false, false };
    }

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (rayControl.GetComponent<P_GameManager>().isUp == true)
        {
            RaycastHit2D upHit = rayControl.GetComponent<P_GameManager>().upHit;
            if (upHit)
            {
                if(System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
                {
                    //Debug.Log("uphit true");
                    if (getItem[0] == false && System.Object.ReferenceEquals(this.gameObject, objList[0]))
                    {
                        if (!getKey_A) { Debug.Log("Need 'Key_A'"); }
                        else
                        {
                            Debug.Log("Get 'Wire'");
                            getItem[0] = true;
                        }
                    }
                    if (getItem[1] == false && System.Object.ReferenceEquals(this.gameObject, objList[1]))
                    {
                        Debug.Log("Get 'Guitar'");
                        getItem[1] = true;
                    }
                    if (getItem[2] == false && System.Object.ReferenceEquals(this.gameObject, objList[2]))
                    {
                        Debug.Log("Get 'Key_A'");
                        getKey_A = true;
                        getItem[2] = true;
                    }
                    //if (getItem[3] == false && System.Object.ReferenceEquals(this.gameObject, objList[3]))
                    //{
                    //    if (!getPattern) { Debug.Log("Need 'Pattern'"); }
                    //    else
                    //    {
                    //        Debug.Log("Get 'Fianl_Item'");
                    //        getItem[3] = true;
                    //    }
                    //}
                    if (getItem[3] == false && System.Object.ReferenceEquals(this.gameObject, objList[4]))
                    {
                        Debug.Log("Get 'Violin'");
                        getItem[3] = true;
                    }
                    if (getItem[4] == false && System.Object.ReferenceEquals(this.gameObject, objList[5]))
                    {
                        if (!contectWire) { Debug.Log("Need 'Contect Wire'"); }
                        else
                        {
                            Debug.Log("Get 'Top_B'");
                            getItem[4] = true;
                        }
                    }
                    if (getItem[5] == false && System.Object.ReferenceEquals(this.gameObject, objList[6]))
                    {
                        if (!getKey_B) { Debug.Log("Need 'Key_B'"); }
                        else
                        {
                            Debug.Log("Get 'Top_C'");
                            getItem[5] = true;
                        }
                    }
                    if (getItem[6] == false && System.Object.ReferenceEquals(this.gameObject, objList[7]))
                    {
                        if (!getWire) { Debug.Log("Need 'Wire'"); }
                        else
                        {
                            Debug.Log("Use 'Lamp'");
                            getItem[6] = true;
                        }
                    }
                }
            }
        }
    }
}
