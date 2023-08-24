using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_UI : MonoBehaviour
{
    public void ClickLeftArrow() { P_Camera.instance.MoveSide(0); }

    public void ClickRightArrow() { P_Camera.instance.MoveSide(1); }

    public void ClickBackArrow() { P_Camera.instance.ExtiPuzzle(); }
}
