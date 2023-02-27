using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowButton : MonoBehaviour
{
    ShadowPuzzle puzzle;

    private void Start()
    {
        puzzle = transform.parent.GetComponent<ShadowPuzzle>();
    }

    private void OnMouseDown()
    {
        puzzle.ChangeShadow();
    }

}
