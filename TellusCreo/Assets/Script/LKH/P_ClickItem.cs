using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ClickItem : MonoBehaviour
{
    public GameObject rayControl;
    private bool toybox;
    private P_PuzzleObject toy_obj;
    private GameObject toy_after;

    private bool keyA = false;
    private bool keyB = false;

    private void Start()
    {
        if (this.name == "puzzle_toybox_cover")
        {
            toybox = true;
            toy_obj = GameObject.Find("toy_box").GetComponent<P_PuzzleObject>();
            toy_after = GameObject.Find("Clear").transform.GetChild(2).gameObject;
        }
        if (this.name == "item_keyA") { keyA = true; }
        if (this.name == "item_keyB") { keyB = true; }
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
            if (rayControl.GetComponent<P_GameManager>().upHit)
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
                        if (upHit.collider.CompareTag("P_item"))
                        {
                            Debug.Log("Get " + this.name);
                            // 인벤토리
                            this.GetComponent<AudioSource>().Play();
                            if (keyA) { rayControl.GetComponent<P_GameManager>().Set_isGetKeyA(); }
                            if (keyB) { rayControl.GetComponent<P_GameManager>().Set_isGetKeyB(); }
                            Destroy(this.GetComponent<SpriteRenderer>());
                            Destroy(this.GetComponent<Collider2D>());
                        }
                        else { Destroy(gameObject); }
                    }
                }
            }
        }
    }
}
