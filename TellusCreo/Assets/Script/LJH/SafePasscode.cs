using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePasscode : MonoBehaviour
{
    public int CheckPass; //금고 클리어 판정
    // Start is called before the first frame update
    void Start()
    {
        CheckPass = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Clear();
    }

    public void OnTriggerEnter2D(Collider2D collider) //해당 태그의 오브젝트가 걸릴 시 플러스
    {
        if (collider.CompareTag("Pass1"))
        {
            CheckPass++;
            Debug.Log(CheckPass);
        }
        if (collider.CompareTag("Pass2"))
        {
            CheckPass++;
            Debug.Log(CheckPass);
        }
        if (collider.CompareTag("Pass3"))
        {
            CheckPass++;
            Debug.Log(CheckPass);
        }
        if (collider.CompareTag("Pass4"))
        {
            CheckPass++;
            Debug.Log(CheckPass);
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Pass3"))
        {
            CheckPass--;
            Debug.Log(CheckPass);
        }
        if (collider.CompareTag("Pass2"))
        {
            CheckPass--;
            Debug.Log(CheckPass);
        }
        if (collider.CompareTag("Pass1"))
        {
            CheckPass--;
            Debug.Log(CheckPass);
        }
        if (collider.CompareTag("Pass4"))
        {
            CheckPass--;
            Debug.Log(CheckPass);
        }
    }

    private void Clear()
    {
        if(CheckPass == 4)
        {
            Debug.Log("CLEAR");
        }
    }


}
