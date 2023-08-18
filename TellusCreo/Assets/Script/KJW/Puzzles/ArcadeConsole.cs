using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ArcadeConsole : MonoBehaviour
{
    [SerializeField]
    Item launcher;
    [SerializeField]
    GameObject nameObject;
    [SerializeField]
    List<Text> nickNameList;
    [SerializeField]
    Text Alpahbet;
    string[] alphArr = {"A ","B ","C ","D ","E ","F ","G ","H ","I ","J ","K ","L ","M\n",
                                "N ","O ","P ","Q ","R ","S ","T ","U ","V ","W ","X ","Y ","Z"};
    int selectedAlphabetIndex = 0;
    int columnCount = 13; // 열 개수
    int selectedNameSpaceIndex;
    const string CORRECT_NAME = "SOL";
    string inputName = "   ";
    bool clearArcade = false;
    void Start()
    {
        selectedNameSpaceIndex = 0;
        Alpahbet.text = string.Join("", alphArr);
        UpdateAlphabetText();
    }

    public void OnResetButton()
    {
        SoundManager.Instance.Play("puzzle_Arcade_button");
        selectedNameSpaceIndex = 0;
        foreach (var nickName in nickNameList)
        {
            nickName.text = " ";
        }
    }

    public void OnSelectButton()
    {
        SoundManager.Instance.Play("puzzle_Arcade_button");
        char selectedChar = alphArr[selectedAlphabetIndex][0]; // 선택된 문자를 변수로 저장
        nameObject.transform.GetChild(selectedNameSpaceIndex).GetComponent<Text>().text = selectedChar.ToString(); // 변수를 사용하여 텍스트 변경

        inputName = inputName.Remove(selectedNameSpaceIndex, 1); // 입력된 이름에서 선택된 인덱스의 문자 제거
        inputName = inputName.Insert(selectedNameSpaceIndex, selectedChar.ToString()); // 입력된 이름에 선택된 문자 삽입
        selectedNameSpaceIndex++;
        selectedNameSpaceIndex %= 3;
        if (selectedNameSpaceIndex == 0)
        {
            NameCheck();
        }
    }

    public void SelectAlphabet(Direction direction)
    {
        int delta = 0;
        switch (direction)
        {
            case Direction.LEFT:
                delta = -1;
                break;
            case Direction.RIGHT:
                delta = 1;
                break;
            case Direction.UP:
                delta = -columnCount;
                break;
            case Direction.DOWN:
                delta = columnCount;
                break;
        }
        selectedAlphabetIndex = (selectedAlphabetIndex + delta + alphArr.Length) % alphArr.Length;
        UpdateAlphabetText();
    }

    void UpdateAlphabetText() // 알파벳 색상 업데이트
    {
        StringBuilder tempAlpahbet = new StringBuilder();
        for (int i = 0; i < alphArr.Length; i++)
        {
            if (i == selectedAlphabetIndex)
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

    void NameCheck()
    {
        if(CORRECT_NAME == inputName)
        {
            clearArcade = true;
            GameManager.Instance[(int)GameManager.Puzzle.ArcadeConsole - GameManager.Instance.NUMBER_OF_PUZZLES] = true;
            if(InventoryManager.Instance!=null)
            {
                InventoryManager.Instance.Add(launcher);
            }
        }    
    }
}
