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

    void Update()
    {
        
    }

    public void ToLogin()
    {
        StartCoroutine(LoginToDB(LoginID.ToString(), LoginPW.ToString()));
    }

    IEnumerator LoginToDB(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(LoginURL, form);

        yield return www;
        Debug.Log(www.text);
    }

    public void newLogin()
    {
        StartCoroutine(newLogin(newID.ToString(), newPW.ToString()));
    }

    IEnumerator newLogin(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(newURL, form);
        yield return www;
        Debug.Log(www.text);
    }
}
