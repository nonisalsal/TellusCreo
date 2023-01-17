using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Puzzle
    {
        Poster = 10,
        WetTissue,
        Star,
        SignatureCard, // 14
        Wire,
    }

    UI ui;

    public GameObject[] Puzzles;

    public bool onPuzzle;
    public bool lightOn;
    public bool posterPuzzle;
   

    [SerializeField]
    GameObject light2D;
    [SerializeField]
    GameObject globalLight;

    void Start()
    {
        ui = FindObjectOfType<UI>();
        onPuzzle = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 바꾸기
        RaycastHit2D hit = Physics2D.Raycast(mousPos, transform.forward, 10f); // 레이캐스트
        if (hit.collider == null)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            if (!onPuzzle)
            {
                ui.prevCameraPos = Camera.main.transform.position;
                Camera.main.transform.position = new Vector3(0, -25f, -100f);
                ActiveBackArrow();
            }
            if (hit.collider.gameObject.layer == (int)Puzzle.Poster)
            {
                Debug.Log("Poster");
                onPuzzle = true;
                Puzzles[(int)Puzzle.Poster - 10].SetActive(true);

            }
            else if (hit.collider.gameObject.layer == (int)Puzzle.WetTissue)
            {
                onPuzzle = true;
                Puzzles[(int)Puzzle.WetTissue - 10].SetActive(true);
                Debug.Log("WetTissue");

            }
            else if(hit.collider.gameObject.layer == (int)Puzzle.SignatureCard)
            {
                onPuzzle = true;
                Puzzles[(int)Puzzle.SignatureCard - 10].SetActive(true);
                Debug.Log("SignatureCard");
            }
            else if (hit.collider.gameObject.layer == (int)Puzzle.Star)
            {
                onPuzzle = true;
                Puzzles[(int)Puzzle.Star - 10].SetActive(true);
                LightEnable();
                Debug.Log("Star");
            }
        }

    }

    public void  LightEnable()
    {
        if (light2D.gameObject.activeSelf)
        {
            light2D.gameObject.SetActive(false);
            globalLight.gameObject.SetActive(true);
        }
        else
        {
            light2D.transform.position = new Vector2(0, -25f);
            light2D.gameObject.SetActive(true);
            globalLight.gameObject.SetActive(false);
        }
      
    }

    void ActiveBackArrow()
    {
        ui.backArrow.SetActive(true);
        ui.DisbleArrow();

      
    }
}
