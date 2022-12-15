using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KTest : MonoBehaviour
{


   public  enum State
    {
        UP,
        DOWN
    }

    string tempStr;
    public Text playerName;
    public Text Alphabet;
    [SerializeField]
    State _state = State.DOWN;
    [SerializeField]
    int selectAlph;
    [SerializeField]
    int selectIdx;
    public string[] alphArr = {"A","B","C","D","E","F","G","H","I","K","L","M",
                                "N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};



    public Text tempStateText;
    

    void Init()
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

    void Awake()
    {
        Init();
    }

    public void SelectAlph()
    {
        playerName.text = playerName.text.Remove(selectIdx, 1).Insert(selectIdx, alphArr[selectAlph]);
        StopAllCoroutines();
    }

    void Display()
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

    public void NextBT()
    {
        if(playerName.text[selectIdx].ToString()!="_")
        StopAllCoroutines();
        
        if (_state == State.DOWN)
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
        else if (_state == State.UP)
        {

            if (selectIdx == 4)
            {
                selectIdx = 0;
            }
            else
            {
                selectIdx += 2;
            }

            StartCoroutine(BlickText());
        }

        Display();
    }

    public void ResetBT()
    {
        playerName.text = "_ _ _";
    }

    public void UPDOWN(State state)
    {

        _state = state;
        if (_state == State.UP)
        {
            tempStateText.text = "UP";
        }
        else
            tempStateText.text = "DOWN";
        //else
        //{
        //    _state = State.UP;
        //   // StartCoroutine(BlickText());
        //}
    }


    public IEnumerator BlickText()
    {
       
            tempStr = playerName.text[selectIdx].ToString();
        while (true)
        {
            playerName.text = playerName.text.Remove(selectIdx, 1).Insert(selectIdx, "_");
            yield return new WaitForSeconds(0.5f);
            playerName.text = playerName.text.Remove(selectIdx, 1).Insert(selectIdx, tempStr);
            yield return new WaitForSeconds(0.5f);
            //playerName.text = playerName.text.Insert(selectIdx, tempStr);
        }

    }
}
