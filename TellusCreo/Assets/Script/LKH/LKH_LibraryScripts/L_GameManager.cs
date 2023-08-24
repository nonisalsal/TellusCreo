using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class L_GameManager : MonoBehaviour
{
    public static L_GameManager instance;

    public bool isDown;
    public bool isUp;
    public RaycastHit2D downHit;
    public RaycastHit2D upHit;

    private bool isGetFinalItem;
    private bool bookClear;
    private bool symmetryClear;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        isDown = false;
        isUp = false;

        isGetFinalItem = false;
        bookClear = false;
        symmetryClear = true;
    }

    void Update()
    {
        ShootRay();
    }

    private void ShootRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 downPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D downRay = new Ray2D(downPos, Vector2.zero);
                downHit = Physics2D.Raycast(downRay.origin, downRay.direction, 1 << 30);

                if (downHit.collider != null)
                    isDown = true;
            }
        }
        else
            isDown = false;

        if (Input.GetMouseButtonUp(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 upPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D upRay = new Ray2D(upPos, Vector2.zero);
                upHit = Physics2D.Raycast(upRay.origin, upRay.direction);

                if (upHit.collider != null)
                    isUp = true;
            }
        }
        else
            isUp = false;
    }

    public void Set_isGetFinalItem()
    {
        isGetFinalItem = true;
        Debug.Log("Get 'Water'");
    }

    public bool Get_isGetFinalItem() { return isGetFinalItem; }

    public void Set_bookClear()
    {
        bookClear = true;
        Debug.Log("Book Puzzle Clear");
    }

    public bool Get_bookClear() { return bookClear; }

    public void Set_symmetryClear()
    {
        symmetryClear = false;
        Debug.Log("Symmetry Puzzle Clear");
    }

    public bool Get_symmetryClear() { return symmetryClear; }
}
