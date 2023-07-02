using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ClickItem : MonoBehaviour
{
    public GameObject rayControl;
    private bool toybox;
    private P_PuzzleObject toy_obj;
    private GameObject toy_after;

    private void Start()
    {
        if (this.name == "puzzle_toybox_cover")
        {
            toybox = true;
            toy_obj = GameObject.Find("toy_box").GetComponent<P_PuzzleObject>();
            toy_after = GameObject.Find("P_Interaction").transform.GetChild(2).gameObject;
        }
        else
            toybox = false;
    }

    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        if (rayControl.GetComponent<P_GameManager>().isUp)
        {
            RaycastHit2D upHit = rayControl.GetComponent<P_GameManager>().upHit;
            if (System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
            {
                if (toybox)
                {
                    toy_after.SetActive(true);
                    toy_obj.puzzleClear = toy_after;
                    Destroy(GameObject.Find("ToyBoxClear"));
                }
                else
                {
                    Debug.Log("Get " + this.name);
                    // 인벤토리
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
