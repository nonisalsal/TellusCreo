using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(GameManager.Instance!=null)
        {
            if (GameManager.Instance.ClearAttic) SceneManager.LoadScene("livingRoom");
            else Debug.Log("다락방 미완료");
        }
    }
}
