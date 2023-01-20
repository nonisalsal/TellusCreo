using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetTissue : MonoBehaviour
{
    int cnt;
    bool clear;

    public GameObject mars;

    [SerializeField]
    Transform spwanPos;

    [SerializeField]
    GameObject tissue;

    private void OnMouseDown()
    {
        if (cnt > 0)
        {
            GameObject tempTissue = Instantiate(tissue, spwanPos.position, Quaternion.identity);

            if (cnt % 2 == 0)
            {
                tempTissue.AddComponent<Rigidbody2D>().AddForce(new Vector2(1f, 1f) * 5f, ForceMode2D.Impulse);
            }
            else
            {
                tempTissue.AddComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 1f) * 5f, ForceMode2D.Impulse);
            }
            cnt--;
        }
        else
        {
            if (!clear)
            {
                clear = true;
                Instantiate(mars, transform.position, Quaternion.identity);
            }

        }
    }
    void Start()
    {
        cnt = 10;
        clear = false;
    }
}
