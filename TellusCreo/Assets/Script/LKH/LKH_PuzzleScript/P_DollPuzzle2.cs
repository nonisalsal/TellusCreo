using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DollPuzzle2 : MonoBehaviour
{
    private bool isFirst;

    private bool startRotate;
    private float angle;

    private void Awake()
    {
        isFirst = true;

        startRotate = false;
        angle = 0f;
    }

    private void OnEnable()
    {
        if (isFirst)
            startRotate = true;
    }

    private void Update()
    {
        if (!isFirst)
            return;

        if (!startRotate)
            return;

        angle += 80 * Time.deltaTime;
        if (angle >= 80f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 80f);
            startRotate = false;
            isFirst = false;
            Destroy(this);
        }
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
