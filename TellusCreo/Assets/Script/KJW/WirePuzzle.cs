using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzle : MonoBehaviour
{
    bool isClear;

    public int cnt;
    public GameObject[] objs;
    void Start()
    {
        isClear = false;
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (cnt == 3) //원래는 4개
        {
            if (objs != null)
            {
                foreach (var obj in objs)
                {
                    var child = obj.transform.GetChild(0).name;
                    if (obj.name.Substring(obj.name.Length - 1) != child.Substring(child.Length - 1)) // 마지막 번호 비교
                    {
                        cnt = 0;
                        isClear = false; // TODO 실패하면 전선 타일들 전부 인벤토리로 들어가게 구현하기
                        Debug.Log(isClear); 
                        return;
                    }
                    else
                    {
                        isClear = true;
                        GameManager.Instance.ClearPuzzles[(int)GameManager.Puzzle.LightSwitch - 10] = true;
                        cnt = 0;

                    }
                }
                Debug.Log(isClear);
            }
        }
    }
}
