using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thingManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject thing2;
    public GameObject thing3;
    public GameObject thing4;
    public GameObject thing5;

    public bool boolthing1unLock = true;
    public bool boolthing2unLock = false;
    public bool boolthing3unLock = false;
    public bool boolthing4unLock = false;
    public bool boolthing5unLock = false;

    public GameObject thing2LockGroup;
    public GameObject thing2unLockGroup;

    public GameObject thing3LockGroup;
    public GameObject thing3unLockGroup;

    public GameObject thing4LockGroup;
    public GameObject thing4unLockGroup;

    public GameObject thing5LockGroup;
    public GameObject thing5unLockGroup;


    void Start()
    {
        StartCoroutine(reLoad());
    }

    void Update()
    {
        
    }

    IEnumerator reLoad()
    {
        if (boolthing2unLock == true)
        {
            thing2.SetActive(true);
            thing2LockGroup.SetActive(false);
            thing2unLockGroup.SetActive(true);
        }  
        
        if (boolthing3unLock == true)
        {
            thing3.SetActive(true);
            thing3LockGroup.SetActive(false);
            thing3unLockGroup.SetActive(true);
        }

        if (boolthing4unLock == true)
        {
            thing4.SetActive(true);
            thing4LockGroup.SetActive(false);
            thing4unLockGroup.SetActive(true);
        }

         if (boolthing5unLock == true)
        {
            thing5.SetActive(true);
            thing5LockGroup.SetActive(false);
            thing5unLockGroup.SetActive(true);
        }
            

        yield return null;

        StartCoroutine(reLoad());
    }

    public void buy2()
    {
        if (gameManager.Money >= 50000)
        {
            gameManager.Money -= 50000;
            boolthing2unLock = true;
        }
        else
        {
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음");
        }
    }
    public void buy3()
    {
        if (gameManager.Money >= 100000)
        {
            gameManager.Money -= 100000;
            boolthing3unLock = true;
        }
        else
        {
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음");
        }
    }
    public void buy4()
    {
        if (gameManager.Money >= 300000)
        {
            gameManager.Money -= 300000;
            boolthing4unLock = true;
        }
        else
        {
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음");
        }
    }
    public void buy5()
    {
        if (gameManager.Money >= 1000000)
        {
            gameManager.Money -= 1000000;
            boolthing5unLock = true;
        }
        else
        {
            Debug.Log("돈이 " + gameManager.Money + "밖에 없음");
        }
    }


}
