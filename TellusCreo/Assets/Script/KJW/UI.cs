using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Vector3 prevCameraPos;

    public GameObject backArrow;

    public GameObject[] lrArrow;

    GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void BackArrow()
    {
        foreach(var arrow in lrArrow)
        {
            arrow.SetActive(true);
        }
        Camera.main.transform.position = prevCameraPos;

       foreach(var puzzle in gm.Puzzles)
        {
            puzzle.SetActive(false);
        }
        backArrow.SetActive(false);
        gm.onPuzzle = false;
    }

    public void LeftArrow()
    {
        Camera.main.transform.position = new Vector3((Camera.main.transform.position.x + 60) % 80, 0f,-10f);
    }

    public void RightArrow()
    {

        Camera.main.transform.position = new Vector3((Camera.main.transform.position.x + 20) % 80, 0f, -10f);
    }

    public void DisbleArrow()
    {
        foreach (var arrow in lrArrow)
        {
            arrow.SetActive(false);
        }
    }
}
