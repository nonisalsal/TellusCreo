using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePasscode : MonoBehaviour
{
    public int CheckPass;
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

    public void OnTriggerEnter2D(Collider2D collider)
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
    }

    private void Clear()
    {
        if(CheckPass == 3)
        {
            Debug.Log("!!CLEAR!!");
        }
    }


}
