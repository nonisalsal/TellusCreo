using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KTest : MonoBehaviour
{
    enum State
    {
        UP,
        DOWN
    }

    public Text playerName;
    public Text Alphabet;
    [SerializeField]
    string tempStr = "_ _ _";
    [SerializeField]
    State state = State.DOWN;
    [SerializeField]
    int selectAlph;
    [SerializeField]
    int selectIdx;
    public string[] alphArr = {"A","B","C","D","E","F","G","H","I","K","L","M",
                                "N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};

    void Start()
    {
        selectAlph = 0;
        selectIdx = 0;

        for (int i = 0; i < alphArr.Length; i++)
        {
            if (i == 0)
            {
                Alphabet.text += string.Format("<b><color=blue>{0}</color></b> ", alphArr[i]);
            }
            else if (i == 11)
            {
                Alphabet.text += alphArr[i] + " ";
                Alphabet.text += '\n';
            }
            else
            {
                Alphabet.text += alphArr[i] + " ";
            }
        }
    }

    public void SelectAlph()
    {

        tempStr = tempStr.Substring(selectIdx+1);
        tempStr = tempStr. Insert(selectIdx, alphArr[selectAlph]);
        //tempStr = tempStr.Replace(tempStr[selectIdx].ToString(), alphArr[selectAlph]);
        playerName.text = tempStr;
    }

    void Display()
    {
        if (state == State.DOWN)
        {

            Alphabet.text = "";
            for (int i = 0; i < alphArr.Length; i++)
            {
                if (i == selectAlph)
                {
                    Alphabet.text += string.Format("<b><color=blue>{0}</color></b> ", alphArr[i]);

                    if (i == 11)
                    {
                        Alphabet.text += '\n';
                    }
                }
                else if (i == 11)
                {
                    Alphabet.text += alphArr[i] + " ";
                    Alphabet.text += '\n';
                }
                else
                {
                    Alphabet.text += alphArr[i] + " ";
                }
            }
        }
        else if (state == State.UP)
        {

        }
    }

    public void NextBT()
    {
        if (state == State.DOWN)
        {

            if (selectAlph == 24)
            {
                selectAlph = 0;
            }
            else
            {
                selectAlph++;
            }
        }
        else if(state==State.UP)
        {
            if(selectIdx==4)
            {
                selectIdx = 0;
            }
            else
            {
            selectIdx += 2;

            }
        }

        Display();
    }

    public void ResetBT()
    {
        playerName.text = "";
    }

    public void UPDOWN()
    {
        if (state == State.UP)
            state = State.DOWN;
        else
            state = State.UP;
    }
}
