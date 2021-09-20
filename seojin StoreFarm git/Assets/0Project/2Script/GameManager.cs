using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class GameManager : MonoBehaviour
{
    public StoreManager storeManager;
    public DataManager dataManager;

    public BigInteger Money;
    public BigInteger Gold;

    public Text MoneyTxt;
    public Text GoldTxt;

    void Start()
    {
        StartCoroutine(Timemoney());

        GameLoad();
    }

    void Update()
    {
        ReLoad();
        GameSave();
    }

    IEnumerator Timemoney()
    {
        yield return new WaitForSecondsRealtime(1);

        if(storeManager.storeusing == 2)
        {
            Money += 50;
        }
        else if(storeManager.storeusing == 3)
        {
            Money += 100;
        }
        else if(storeManager.storeusing == 4)
        {
            Money += 200;
        }

        StartCoroutine(Timemoney());
    }

    void ReLoad()
    {
        MoneyTxt.text = GetMoneyText();
        GoldTxt.text = GetGoldText();

        //MoneyTxt.text = Money + " 원";
        //GoldTxt.text = Gold + " 골드";
    }

    private string[] moneyUnitArr = new string[] { "원", "만 ", "억 ", "조 ", "경 ", "해 ", "자 ", "양 ", "구 ", "간 " };
    private string GetMoneyText()
    {
        int placeN = 4;
        BigInteger value = Money;
        List<int> numList = new List<int>();
        int p = (int)Mathf.Pow(10, placeN);

        do
        {
            numList.Add((int)(value % p));
            value /= p;
        }
        while (value >= 1);
        string retStr = "";
        for(int i = 0; i< numList.Count; i++)
        {
            retStr = numList[i] + moneyUnitArr[i] + retStr;
        }
        return retStr;
    }

    private string[] goldUnitArr = new string[] { "골드", ",", ",", ",", ",", ",", ",", ",", "," };
    private string GetGoldText()
    {
        int placeN = 4;
        BigInteger value = Gold;
        List<int> numList = new List<int>();
        int p = (int)Mathf.Pow(10, placeN);

        do
        {
            numList.Add((int)(value % p));
            value /= p;
        }
        while (value >= 1);
        string retStr = "";
        for(int i = 0; i< numList.Count; i++)
        {
            retStr = numList[i] + goldUnitArr[i] + retStr;
        }
        return retStr;
    }

    public void onClick()
    {
        if(storeManager.storeusing == 1)
        {
            Money += (BigInteger)100;
        }
        else if(storeManager.storeusing == 2)
        {
            //Money += Money;
            //Gold += Gold;

            Money += (BigInteger)200;
        }
        else if(storeManager.storeusing == 3)
        {
            Money += (BigInteger)500;
        }
        else if(storeManager.storeusing == 4)
        {
            Money += (BigInteger)1000;
        }

    }

    public void Reset()
    {
        Money = 0;
        Gold = 0;
    }

    public void GameSave()
    {
        dataManager.CreateXml();
    }

    public void GameSaveOverlap()
    {
        dataManager.SaveOverlapXml();
    }
    

    public void GameLoad()
    {
        //dataManager.LoadXml();
        dataManager.Load();

    }

    public void GameExit()
    {
        Application.Quit();
        GameSave();
    }
}
