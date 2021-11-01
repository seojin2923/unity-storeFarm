using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public Load load;

    public GameObject startTextbox;
    public Text startText;
    public Image Play;
    public GameObject clickImg;

    public Sprite Play1;
    public Sprite Play2;
    public Sprite Play3;

    int page = 1;

    void Update()
    {
        if(page == 1)
        {
            Play.sprite = Play1;
            clickImg.SetActive(true);
            startTextbox.SetActive(true);
            startText.GetComponent<Text>().text = "ȭ���� ��ġ�ؼ� ���� ������";
        }
        else if(page == 2)
        {
            Play.sprite = Play2;
            clickImg.SetActive(false);
            startTextbox.SetActive(true);
            startText.GetComponent<Text>().text = "������ ��ư��� ���Ը� ���׷��̵� �ϰų� ������ �����Ҽ� �ִ�.\n�׸��� ������ ������ �޼��ҽ� ���带 ������ �ִ�.";
        }
        else if(page == 3)
        {
            Play.sprite = Play3;
            clickImg.SetActive(false);
            startTextbox.SetActive(false);
        }

    }

    public void next()
    {
        if (page != 3)
            page++;
        else if (page == 3)
            load.LoadPlay();
    }
    public void prev()
    {
        if (page != 1)
            page--;
    }

    
}
