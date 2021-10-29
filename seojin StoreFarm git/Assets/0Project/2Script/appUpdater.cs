using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class appUpdater : MonoBehaviour
{
    public versionManager versionManager;

    public Load load;

    public string CurVersion; // 현재 빌드버전
    string latsetVersion; // 최신버전

    public Text versionText; // 버전 텍스트

    public GameObject StartButton;

    public Text internetText;
    public GameObject internet;

    void Start()
    {
        CurVersion = Application.version;
        if (SceneManager.GetActiveScene().name == "Main")
        {
            versionText.GetComponent<Text>().text = "version " + CurVersion;
            StartCoroutine(GetText());
        }
    }

    public void VersionCheck()
    {
        if (CurVersion != latsetVersion)
            load.LoadnewVersion();

        Debug.Log("Current Version " + CurVersion + " Lastest Version " + latsetVersion);
        StartButton.SetActive(true);
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(versionManager.versionLink);
        yield return www.SendWebRequest();

        if (www.error == null)
        {
            // Show results as text
            latsetVersion = www.downloadHandler.text;
            Debug.Log(latsetVersion);
            internet.SetActive(false);
            VersionCheck();
        }
        else
        {
            internetText.GetComponent<Text>().text = www.error + "\n 인터넷 연결 실패";
            StartButton.SetActive(true);
        }
    }

    public void Updateyes()
    {
        Application.OpenURL("http://seojin1.kro.kr/2.0/html/game/storeFarmBeta.html");
    }
    public void UpdateNo()
    {
        load.LoadPlay();
    }
}
