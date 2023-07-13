using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bed : MonoBehaviour
{
    private bool[] getItem;

    public GameObject rayControl;
    public AudioClip locked;
    public AudioClip item;

    void Start()
    {
        getItem = new bool[2] { false, false };

        this.transform.GetChild(2).gameObject.SetActive(false);
        this.transform.GetChild(3).gameObject.SetActive(false);
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
                if (System.Object.ReferenceEquals(this.transform.GetChild(0).gameObject, rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    if (rayControl.GetComponent<P_GameManager>().Get_isGetKeyA())
                    {
                        Debug.Log("open left");
                        this.transform.GetChild(0).gameObject.SetActive(false);
                        this.transform.GetChild(2).gameObject.SetActive(true);
                    }
                    else
                    {
                        this.GetComponent<AudioSource>().clip = locked;
                        this.GetComponent<AudioSource>().Play();
                    }
                }
                if (System.Object.ReferenceEquals(this.transform.GetChild(1).gameObject, rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    Debug.Log("open right");
                    this.transform.GetChild(1).gameObject.SetActive(false);
                    this.transform.GetChild(3).gameObject.SetActive(true);
                }
                if (System.Object.ReferenceEquals(this.transform.GetChild(2).gameObject, rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    if (!getItem[0])
                    {
                        Debug.Log("get concent");
                        // 인벤토리 적용 후 인벤토리로 보내는 코드 추가 필요.
                        getItem[0] = true;
                        this.GetComponent<AudioSource>().clip = item;
                        this.GetComponent<AudioSource>().Play();
                        this.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("close left");
                        this.transform.GetChild(0).gameObject.SetActive(true);
                        this.transform.GetChild(2).gameObject.SetActive(false);
                    }
                }
                if (System.Object.ReferenceEquals(this.transform.GetChild(3).gameObject, rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    if (!getItem[1])
                    {
                        Debug.Log("get guitar");
                        // 인벤토리 적용 후 인벤토리로 보내는 코드 추가 필요.
                        getItem[1] = true;
                        this.GetComponent<AudioSource>().clip = item;
                        this.GetComponent<AudioSource>().Play();
                        this.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("close right");
                        this.transform.GetChild(1).gameObject.SetActive(true);
                        this.transform.GetChild(3).gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
