using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [Header("Login Panel")]
    public InputField LoginID;
    public InputField LoginPW;

    [Header("create Panel")]
    public InputField newID;
    public InputField newPW;
    public Button newBtn;

    [Header("·Î±×ÀÎ")]
    public string LoginUrl;

    void Start()
    {
        LoginUrl = "";
    }

    public void LoginBtn()
    {
        StartCoroutine(LoginCo());
    }

    IEnumerator LoginCo()
    {
        WWW www = new WWW("http://net.seojin1.kro.kr/sqlconnect/register.php");
        from.AddField("name", newID.text);
        from.AddField("password", newPW.text);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created successfully");
        }
        else
        {
            Debug.Log("User creation fail. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        newBtn.interactable = (newID.text.Length >= 8 && newPW.text.Length >= 8);
    }
}
