using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum Puzzle
    {
        Poster = 10,
        WetTissue,
        Star,
        Wire,
    }

    public GameObject[] Puzzles;

    public bool onPuzzle;
    UI ui;

    public bool lightOn;

    public bool posterPuzzle;


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
        }

    }

    void ActiveBackArrow()
    {
        ui.backArrow.SetActive(true);
        ui.DisbleArrow();
    }
}
