using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public GameManager gameManager;

    public Image storeImg;
    public Text storeText;

    public Sprite ������������Img;
    public Sprite ��������Img;
    public Sprite ���ݱ���������Img;
    public Sprite ����������Img;

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

    public Animator StorePanelObj;
    bool storePanelchacker;

    public GameObject xmlPanelObj;
    bool xmlPanelchacker;

    void Start()
    {
        
    }

    void Update()
    {
        if (storeusing == 1)
        {
            storeImg.sprite = ������������Img;
            storeText.text = "���� ���� ����";
        }
        else if (storeusing == 2)
        {
            storeImg.sprite = ��������Img;
            storeText.text = "���� ����";
        }
        else if (storeusing == 3)
        {
            storeImg.sprite = ���ݱ���������Img;
            storeText.text = "���� ������ ����";
        }
        else if (storeusing == 4)
        {
            storeImg.sprite = ����������Img;
            storeText.text = "������ ����";
        }
           

    }

    public void storePanel()
    {
        if (storePanelchacker)
        {
            storePanelchacker = false;
            StorePanelObj.SetTrigger("doHide");
        }
        else
        {
            storePanelchacker = true;
            StorePanelObj.SetTrigger("doShow");
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
        if (gameManager.Money > 12000)
        {
            gameManager.Money -= 12000;
            boolstore2unLock = true;
            store2unLockGroup.SetActive(true);
            store2LockGroup.SetActive(false);
            use2();
        }
        else
            Debug.Log("���� " + gameManager.Money + "�� �ۿ� ���� ���� ���ڶ�");
    }
    public void buy3()
    {
        if (gameManager.Money > 32000)
        {
            gameManager.Money -= 32000;
            boolstore3unLock = true;
            store3unLockGroup.SetActive(true);
            store3LockGroup.SetActive(false);
            use3();
        }
        else
            Debug.Log("���� " + gameManager.Money + "�� �ۿ� ���� ���� ���ڶ�");
    }
    public void buy4()
    {
        if (gameManager.Money > 170000)
        {
            gameManager.Money -= 170000;
            boolstore4unLock = true;
            store4unLockGroup.SetActive(true);
            store4LockGroup.SetActive(false);
            use4();
        }
        else
            Debug.Log("���� " + gameManager.Money + "�� �ۿ� ���� ���� ���ڶ�");
    }

}
