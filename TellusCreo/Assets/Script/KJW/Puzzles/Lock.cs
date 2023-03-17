using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lock : MonoBehaviour
{
    List<GameObject> passwords = new List<GameObject>();
    
    string correctPassword = "456";
    string changePassword = "000";

    void Start()
    {
        Init();
    }

    void Init()
    {
        if (passwords.Count >= 3)
            return;
        if (transform.childCount < 3)
        {
            Debug.LogError("비밀번호 객체가 부족");
            return;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            passwords.Add(transform.GetChild(i).gameObject);
        }

    }

    void ComparePassword()
    {
        if (correctPassword != changePassword)
            return;
        GameManager.Instance[(int)GameManager.Puzzle.Lock - 10] = true;
    }

    public void UpButton()
    {
        PasswordController password = EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<PasswordController>();
       
        password.Password = "1";

        ChangePassword(password, passwords.IndexOf(password.gameObject));
        ComparePassword();
        Debug.Log(changePassword);
    }

    public void DownButton()
    {
        PasswordController password = EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<PasswordController>();

        password.Password = "-1";

        ChangePassword(password,passwords.IndexOf(password.gameObject));
        ComparePassword();
        Debug.Log(changePassword);
    }

    void ChangePassword(PasswordController password, int index)
    {
        var temp = new StringBuilder(changePassword);
        temp[index] = password.Password[0];
        changePassword = temp.ToString();
    }
}
