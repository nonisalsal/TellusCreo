using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ToyBox : MonoBehaviour
{
    public GameObject rayControl;
    private int num = 1;


    private void Start()
    {
        //this.transform.GetChild(0).gameObject.SetActive(false);
        //this.transform.GetChild(1).gameObject.SetActive(true);
        //this.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void Update()
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
                Debug.Log(upHit.collider.gameObject.name);
                // 여기서 오류가 발생. > hierachy창에서 수정하니까 됨. 근데 왜 된거지?
                if (System.Object.ReferenceEquals(this.transform.gameObject, upHit.collider.gameObject.transform.parent.gameObject))
                {
                    Debug.Log("asdf");
                    num++;
                    if (num >= 3)
                        num = 0;
                    for (int i=0; i<3; i++)
                    {
                        this.transform.GetChild(i).gameObject.SetActive(false);
                        if(i == num)
                            this.transform.GetChild(i).gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
