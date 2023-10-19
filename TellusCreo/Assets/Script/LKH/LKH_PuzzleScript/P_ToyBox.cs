using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ToyBox : MonoBehaviour
{
    [SerializeField] private int num = 1;

    private void OnEnable()
    {
        if (P_Camera.instance.nowPuzzle.Get_isClear())
            return;

        if (!P_GameManager.instance.Get_topClear())
            return;

        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
            collider.enabled = true;

        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(false);
        //transform.GetChild(1).GetComponent<Collider2D>().enabled = true;
    }

    private void PlayerInput()
    {
        if (P_GameManager.instance.isUp)
        {
            GameObject upHit = P_GameManager.instance.upHit.collider.gameObject;
            if (System.Object.ReferenceEquals(gameObject, upHit.transform.parent.gameObject))
            {
                num++;
                if (num == 3)
                    num = 0;

                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                    //transform.GetChild(i).GetComponent<Collider2D>().enabled = false;
                    //transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                    if (i == num)
                    {
                        transform.GetChild(i).gameObject.SetActive(true);
                        //transform.GetChild(i).GetComponent<Collider2D>().enabled = true;
                        //transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
                Debug.Log("adsf");
            }
        }
    }

    private void Update()
    {
        PlayerInput();
    }
}
