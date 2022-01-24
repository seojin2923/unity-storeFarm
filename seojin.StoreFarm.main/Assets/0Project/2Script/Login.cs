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

    string LoginURL = "http://storeFarm.seojin1.kro.kr/login.php";
    string newURL = "http://storeFarm.seojin1.kro.kr/new.php";


    void Start()
    {
        
    }

    public void ToLogin()
    {
        StartCoroutine(LoginCo());
    }

    IEnumerator LoginCo()
    {
        string Loginname = LoginID.text;
        string Loginpasswd = LoginPW.text;

        WWWForm form = new WWWForm();
        form.AddField("Input_user", Loginname);
        form.AddField("Input_pass", Loginpasswd);

        //WWW WWW = new WWW(LoginURL, form);
        //yield return WWW;

        yield return null;

        //Debug.Log(WWW.text);
    }
    
}
