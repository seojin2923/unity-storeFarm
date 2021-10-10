using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class StoreManager : MonoBehaviour
{
    public GameManager gameManager;

    public int storeusing;

    public Image storeImg;
    public Text storeText;

    public Sprite[] StoreImage;

    public bool[] boolstoreunLock;

    public GameObject[] storeLockGroup;
    public GameObject[] storeunLockGroup;

    public Animator[] Panelanim;
    public GameObject xmlPanelObj;

    bool AchiPanelchacker;
    bool storePanelchacker;
    bool thingPanelchacker;
    bool upgradePanelchacker;
    bool xmlPanelchacker;

    public TextAsset txt;
    string[,] Sentence;
    int lineSize, rowSize;

    void Start()
    {
        // 엔터단위와 탭으로 나눠서 배열의 크기 조정
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        Sentence = new string[lineSize, rowSize];

        // 한 줄에서 탭으로 나눔
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for (int j = 0; j < rowSize; j++) Sentence[i, j] = row[j];
        }

        StartCoroutine(reload());
    }

    IEnumerator reload()
    {
        int Line = storeusing - 1;

        storeImg.sprite = StoreImage[Line];

        string storetxt = Sentence[Line, 4];

        storeText.text = storetxt;

        yield return null;
        StartCoroutine(reload());
    }

    public void use(int number)
    {
        storeusing = number;
    }

    public void AchiPanel()
    {
        if (AchiPanelchacker)
        {
            AchiPanelchacker = false;
            Panelanim[0].SetTrigger("doHide");
        }
        else
        {
            AchiPanelchacker = true;
            Panelanim[0].SetTrigger("doShow");
        }
    }
    public void storePanel()
    {
        if (storePanelchacker)
        {
            storePanelchacker = false;
            Panelanim[1].SetTrigger("doHide");
        }
        else
        {
            storePanelchacker = true;
            Panelanim[1].SetTrigger("doShow");
        }   
    }
    public void thingPanel()
    {
        if (thingPanelchacker)
        {
            thingPanelchacker = false;
            Panelanim[2].SetTrigger("doHide");
        }
        else
        {
            thingPanelchacker = true;
            Panelanim[2].SetTrigger("doShow");
        }   
    }
    public void upgradePanel()
    {
        if (upgradePanelchacker)
        {
            upgradePanelchacker = false;
            Panelanim[3].SetTrigger("doHide");
        }
        else
        {
            upgradePanelchacker = true;
            Panelanim[3].SetTrigger("doShow");
        }   
    }
    public void xmlPanel()
    {
        if (xmlPanelchacker)
        {
            xmlPanelchacker = false;
            xmlPanelObj.SetActive(false);
        }
        else
        {
            xmlPanelchacker = true;
            xmlPanelObj.SetActive(true);
        }   
    }

    public void buy(int buy_number)
    {
        int Line = buy_number - 1;
        int Group_number = buy_number - 2;

        if (gameManager.Money >= int.Parse(Sentence[Line, 1]))
        {
            gameManager.Money -= int.Parse(Sentence[Line, 1]);
            boolstoreunLock[Line] = true;
            storeunLockGroup[Group_number].SetActive(true);
            storeLockGroup[Group_number].SetActive(false);
            use(buy_number);
        }
        else
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음 모자라");
    }
    
    public void buy2()
    {
        if (gameManager.Money >= 95000)
        {
            gameManager.Money -= 95000;
            boolstoreunLock[1] = true;
            storeunLockGroup[0].SetActive(true);
            storeLockGroup[0].SetActive(false);
            use(2);
        }
        else
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음 모자라");
    }
    public void buy3()
    {
        if (gameManager.Money > 295000)
        {
            gameManager.Money -= 295000;
            boolstoreunLock[2] = true;
            storeunLockGroup[1].SetActive(true);
            storeLockGroup[1].SetActive(false);
            use(3);
        }
        else
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음 모자라");
    }
    public void buy4()
    {
        if (gameManager.Money > 1000000)
        {
            gameManager.Money -= 1000000;
            boolstoreunLock[3] = true;
            storeunLockGroup[2].SetActive(true);
            storeLockGroup[2].SetActive(false);
            use(4);
        }
        else
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음 모자라");
    }
    public void buy5()
    {
        if (gameManager.Money > 1500000)
        {
            gameManager.Money -= 1500000;
            boolstoreunLock[4] = true;
            storeunLockGroup[3].SetActive(true);
            storeLockGroup[3].SetActive(false);
            use(5);
        }
        else
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음 모자라");
    }
    public void buy6()
    {
        if (gameManager.Money > 3500000)
        {
            gameManager.Money -= 3500000;
            boolstoreunLock[5] = true;
            storeunLockGroup[4].SetActive(true);
            storeLockGroup[4].SetActive(false);
            use(6);
        }
        else
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음 모자라");
    }
    public void buy7()
    {
        if (gameManager.Money > 5000000)
        {
            gameManager.Money -= 5000000;
            boolstoreunLock[6] = true;
            storeunLockGroup[5].SetActive(true);
            storeLockGroup[5].SetActive(false);
            use(7);
        }
        else
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음 모자라");
    }

}