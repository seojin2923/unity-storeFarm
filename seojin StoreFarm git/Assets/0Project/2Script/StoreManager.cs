﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public GameManager gameManager;

    public Image storeImg;
    public Text storeText;

    public Sprite 아주작은가게Img;
    public Sprite 작은가게Img;
    public Sprite 조금괜찮은가게Img;
    public Sprite 괜찮은가게Img;

    public bool boolstore1unLock = true;
    public bool boolstore2unLock = false;
    public bool boolstore3unLock = false;
    public bool boolstore4unLock = false;
    public bool boolstore5unLock = false;

    public GameObject store2LockGroup;
    public GameObject store2unLockGroup;

    public GameObject store3LockGroup;
    public GameObject store3unLockGroup;

    public GameObject store4LockGroup;
    public GameObject store4unLockGroup;

    public int storeusing;

    public Animator StorePanelanim;
    bool storePanelchacker;
    public Animator thingPanelanim;
    bool thingPanelchacker;

    public GameObject xmlPanelObj;
    bool xmlPanelchacker;

    void Start()
    {
        
    }

    void Update()
    {
        if (storeusing == 1)
        {
            storeImg.sprite = 아주작은가게Img;
            storeText.text = "아주작은가게";
        }
        else if (storeusing == 2)
        {
            storeImg.sprite = 작은가게Img;
            storeText.text = "작은가게";
        }
        else if (storeusing == 3)
        {
            storeImg.sprite = 조금괜찮은가게Img;
            storeText.text = "조금괜찮은가게";
        }
        else if (storeusing == 4)
        {
            storeImg.sprite = 괜찮은가게Img;
            storeText.text = "괜찮은가게";
        }
           

    }

    public void storePanel()
    {
        if (storePanelchacker)
        {
            storePanelchacker = false;
            StorePanelanim.SetTrigger("doHide");
        }
        else
        {
            storePanelchacker = true;
            StorePanelanim.SetTrigger("doShow");
        }   
    }
    public void thingPanel()
    {
        if (thingPanelchacker)
        {
            thingPanelchacker = false;
            thingPanelanim.SetTrigger("doHide");
        }
        else
        {
            thingPanelchacker = true;
            thingPanelanim.SetTrigger("doShow");
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

    public void use1()
    {
        storeusing = 1;
    }
    public void use2()
    {
        storeusing = 2;
    }
    public void use3()
    {
        storeusing = 3;
    }
    public void use4()
    {
        storeusing = 4;
    }

    public void buy2()
    {
        if (gameManager.Money > 95000)
        {
            gameManager.Money -= 95000;
            boolstore2unLock = true;
            store2unLockGroup.SetActive(true);
            store2LockGroup.SetActive(false);
            use2();
        }
        else
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음 모자라");
    }
    public void buy3()
    {
        if (gameManager.Money > 295000)
        {
            gameManager.Money -= 295000;
            boolstore3unLock = true;
            store3unLockGroup.SetActive(true);
            store3LockGroup.SetActive(false);
            use3();
        }
        else
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음 모자라");
    }
    public void buy4()
    {
        if (gameManager.Money > 1000000)
        {
            gameManager.Money -= 1000000;
            boolstore4unLock = true;
            store4unLockGroup.SetActive(true);
            store4LockGroup.SetActive(false);
            use4();
        }
        else
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음 모자라");
    }

}