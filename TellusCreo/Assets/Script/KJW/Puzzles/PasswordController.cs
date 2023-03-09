using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordController : MonoBehaviour
{
    [SerializeField]
    Text passwordText;
    string password = "0";
    public string Password { get => password; set => ChangePassword(value); }

    void ChangePassword(string val)
    {
        int tempPassword = (int.Parse(password) + int.Parse(val) + 10 )% 10;
        password = tempPassword.ToString();

        passwordText.text = password;
    }
}
