using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ClickInteractionObj : MonoBehaviour
{
    public GameObject pair;
    private AudioSource objSound;

    private bool isBookDrawer = false;

    private bool isPlantDrawer = false;
    private bool isLocked_plant = false;

    private bool isSymmetryDrawer = false;

    private void Awake()
    {
        objSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (gameObject.name == "bookDrawer_close")
            isBookDrawer = true;

        else if (gameObject.name == "plantDrawer_close")
        {
            isPlantDrawer = true;
            isLocked_plant = true;
        }

        else if (gameObject.name == "plantDrawer_open")
            isPlantDrawer = true;

        else if (gameObject.name == "symmetryDrawer_close")
            isSymmetryDrawer = true;
    }

    void Update()
    {
        if (L_GameManager.instance.isUp == true)
        {
            RaycastHit2D upHit = L_GameManager.instance.upHit;
            int childNum = transform.childCount;

            if (childNum == 0)
            {
                ChangeObj_nonChild(upHit);
                return;
            }
            else
            {
                if (isPlantDrawer == true)
                {
                    ChangeObj_nonChild(upHit);
                    return;
                }

                ChangeObj_child(upHit, childNum);
                return;
            }
        }
    }

    private void ChangeObj_nonChild(RaycastHit2D hit)
    {
        if (System.Object.ReferenceEquals(hit.collider.gameObject, gameObject))
        {
            if (isBookDrawer == true)
            {
                if (L_GameManager.instance.Get_bookClear() == false)
                {
                    objSound.Play();
                    return;
                }
            }

            else if (isPlantDrawer == true)
            {
                if (isLocked_plant == true)
                {
                    objSound.Play();
                    return;
                }
            }

            else if (isSymmetryDrawer == true)
            {
                if (L_GameManager.instance.Get_symmetryClear() == false)
                {
                    objSound.Play();
                    return;
                }
            }

            pair.SetActive(true);
            gameObject.SetActive(false);
            return;
        }
    }

    private void ChangeObj_child(RaycastHit2D hit, int num)
    {
        for (int i=0; i<num; i++)
        {
            if (transform.GetChild(i).CompareTag("P_item"))
                continue;

            if (System.Object.ReferenceEquals(hit.collider.gameObject, transform.GetChild(i).gameObject))
            {
                pair.SetActive(true);
                gameObject.SetActive(false);
                return;
            }
        }
    }

    public void Set_isLocked_plant() { isLocked_plant = false; }
}
