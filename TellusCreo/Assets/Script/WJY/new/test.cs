using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public void testtest()
    {
        for (int i = 0; i < GameManager.Instance.ClearPuzzles.Length; i++)
        {
            GameManager.Instance.ClearPuzzles[i] = true;
        }

        
            GameManager.Instance.CheckRoomClear();
       
    }
}