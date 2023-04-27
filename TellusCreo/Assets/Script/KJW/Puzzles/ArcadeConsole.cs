using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ArcadeConsole : MonoBehaviour
{
    [SerializeField]
    List<Text> nickNameList;
    [SerializeField]
    Text Alpahbet;
    string[] alphArr = {"A ","B ","C ","D ","E ","F ","G ","H ","I ","K ","L ","M \n",
                                "N ","O ","P ","Q ","R ","S ","T ","U ","V ","W ","X ","Y ","Z"};
    int selectedIndex = 0;
    int columnCount = 13; // 열 개수
                          
    void Start()
    {
        Alpahbet.text = string.Join("", alphArr);
        UpdateAlphabetText();
    }

    public void ResetButton()
    {
        foreach (var nickName in nickNameList)
        {
            nickName.text = " ";
        }
    }

    public void SelectAlphabet(Vector2 inputDirection)
    {
        // 입력 방향에 따라 알파벳 선택
        if (Mathf.Abs(inputDirection.x) > Mathf.Abs(inputDirection.y))
        {
            // 좌우 이동
            if (inputDirection.x > 0)
            {
                selectedIndex++;
                if (selectedIndex >= alphArr.Length) selectedIndex = 0;
            }
            else
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = alphArr.Length - 1;
            }
        }
        else
        {
            // 상하 이동
            if (inputDirection.y > 0)
            {
                selectedIndex -= columnCount;
                if (selectedIndex < 0) selectedIndex += alphArr.Length;
            }
            else
            {
                selectedIndex += columnCount;
                if (selectedIndex >= alphArr.Length) selectedIndex -= alphArr.Length;
            }
        }
        UpdateAlphabetText();
    }

    private void UpdateAlphabetText() // 알파벳 색상 업데이트
    {
        StringBuilder tempAlpahbet = new StringBuilder();
        for (int i = 0; i < alphArr.Length; i++)
        {
            if (i == selectedIndex)
            {
                tempAlpahbet.Append("<color=red>");
                tempAlpahbet.Append(alphArr[i]);
                tempAlpahbet.Append("</color>");
            }
            else
            {
                tempAlpahbet.Append(alphArr[i]);
            }
        }
        Alpahbet.text = tempAlpahbet.ToString();
    }
}
