using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lock : MonoBehaviour
{

    private const int PASSWORD_COUNT = 4;
    private const string CORRECT_PASSWORD = "4567";
    private string changePassword = "0000";
    private List<GameObject> passwords = new List<GameObject>();
    [SerializeField]
    private LockBox LockBox;
    void Start()
    {
        Init();
    }

    void Init()
    {
        if (passwords.Count >= PASSWORD_COUNT)
            return;
        if (transform.childCount < PASSWORD_COUNT)
        {
#if UNINTY_EDITOR
            Debug.LogError("비밀번호 객체가 부족");
#endif
            return;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            passwords.Add(transform.GetChild(i).gameObject);
        }

    }

    void ComparePassword()
    {
        if (CORRECT_PASSWORD != changePassword)
            return;
        LockBox.IsUnlock = true;
        foreach(var passwrod in passwords)
        {
            passwrod.gameObject.SetActive(false);
        }
        GameManager.Instance[(int)GameManager.Puzzle.Lock - 10] = true;
    }

    public void UpButton()
    {
        PasswordController password = EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<PasswordController>();

        password.Password = "1";

        ChangePassword(password, passwords.IndexOf(password.gameObject));
        ComparePassword();
#if UNINTY_EDITOR
        Debug.Log(changePassword);
#endif
    }

    public void DownButton()
    {
        PasswordController password = EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<PasswordController>();

        password.Password = "-1";

        ChangePassword(password, passwords.IndexOf(password.gameObject));
        ComparePassword();
#if UNINTY_EDITOR
        Debug.Log(changePassword);
#endif
    }

    void ChangePassword(PasswordController password, int index)
    {
        changePassword = changePassword.Substring(0, index) + password.Password[0] + changePassword.Substring(index + 1);
    //}
    //var temp = new StringBuilder(changePassword);
    //    temp[index] = password.Password[0];
    //    changePassword = temp.ToString();
    }
}
