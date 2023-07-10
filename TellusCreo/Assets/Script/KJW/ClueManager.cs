using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> gameObjects;
    [SerializeField]
    private GameObject clue;
    int index;
    private void Start()
    {
        index = 0;
        if (gameObjects.Count > 0)
        {
            gameObjects[index].SetActive(true);
        }
    }

    void OnMouseDown()
    {
        //if (gameObjects.Count != 0)
        //{
        //    if(gameObjects[index].activeSelf)
        //    {
        //        gameObjects[index].SetActive(false);
        //    }
        //    else
        //    {
        //        gameObjects[index].SetActive(true);
        //    }
            
        //}
        clue?.SetActive(true);
    }
}
