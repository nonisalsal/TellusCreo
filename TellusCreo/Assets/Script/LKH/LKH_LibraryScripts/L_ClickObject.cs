using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L_ClickObject : MonoBehaviour
{
    [SerializeField] private GameObject pair;
    private bool hasPair;

    private bool isFinalDoor = false;

    private void Awake()
    {
        if (pair != null)
            hasPair = true;
    }

    void Start()
    {
        if (name == "finalDoor_object")
            isFinalDoor = true;
    }

    private void PlayerInput()
    {
        if (L_GameManager.instance.isUp)
        {
            GameObject upHit = L_GameManager.instance.upHit.collider.gameObject;
            if(System.Object.ReferenceEquals(gameObject, upHit))
            {
                if (isFinalDoor)
                {
                    if (L_GameManager.instance.Get_isGetFinalItem())
                        SceneManager.LoadScene("livingroom");
                    else
                        Debug.Log("Need final item");

                    return;
                }

                if (hasPair)
                    pair.SetActive(true);

                gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        PlayerInput();
    }
}
