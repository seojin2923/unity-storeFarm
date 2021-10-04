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
            startText.GetComponent<Text>().text = "화면을 터치해서 돈을 모은다";
        }
        else if(page == 2)
        {
            Play.sprite = Play2;
            clickImg.SetActive(false);
            startTextbox.SetActive(true);
            startText.GetComponent<Text>().text = "오른쪽 버튼들로 가게를 업그레이드 하거나 물건을 구매할수 있다.\n그리고 업적은 업적을 달성할시 몇골드를 받을수 있다.";
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
