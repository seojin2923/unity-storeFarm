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
        Debug.Log(LoginID.text);
        Debug.Log(LoginPW.text);

        WWWForm form = new WWWForm();
        form.AddField("Input_user", LoginID.text);
        form.AddField("Input_pass", LoginPW.text);

        WWW webRequest = new WWW(LoginUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        yield return null;
    }
}
