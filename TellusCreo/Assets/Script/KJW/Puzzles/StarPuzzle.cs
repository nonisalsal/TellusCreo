using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject light2D;
    [SerializeField]
    GameObject globalLight;

    public void TestButton()
    {
        if (!light2D.gameObject.activeSelf)
        {
            light2D.transform.position = new Vector2(0, 0);
            light2D.gameObject.SetActive(true);
            globalLight.gameObject.SetActive(false);
        }
        else
        {
            light2D.gameObject.SetActive(false);
            globalLight.gameObject.SetActive(true);
        }
    }
}
