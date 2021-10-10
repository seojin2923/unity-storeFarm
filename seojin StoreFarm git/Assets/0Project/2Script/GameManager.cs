using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public StoreManager storeManager;
    public thingManager thingManager;
    public UpgradeManager upgradeManager;

    public BigInteger Money;
    public BigInteger Gold;

    public Text MoneyTxt;
    public Text GoldTxt;
    public Text TestText;

    void Start()
    {
        StartCoroutine(Timemoney());

        //GameLoad();
    }

    void Update()
    {
        ReLoad();
        //GameSave();

        if (Input.GetButtonDown("Jump"))
            onClick();
    }

    IEnumerator Timemoney()
    {
        yield return new WaitForSecondsRealtime(1);

        //Store Timemoney
        if (storeManager.storeusing == 2)
            Money += 50;
        else if (storeManager.storeusing == 3)
            Money += 100;
        else if (storeManager.storeusing == 4)
            Money += 200;

        //thing Timemoney
        if (thingManager.boolthing1unLock == true)
            Money += 50;

        if (thingManager.boolthing2unLock == true)
            Money += 3000;

        if (thingManager.boolthing3unLock == true)
            Money += 10000;

        if (thingManager.boolthing4unLock == true)
            Money += 20000;

        if (thingManager.boolthing5unLock == true)
            Money += 50000;

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
        for (int i = 0; i < numList.Count; i++)
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
        for (int i = 0; i < numList.Count; i++)
        {
            retStr = numList[i] + goldUnitArr[i] + retStr;
        }
        return retStr;
    }

    public void onClick()
    {
        float MoneyUpgradeLv = upgradeManager.MoneyUpgradeLevel / 5 + 1;

        if (storeManager.storeusing == 1)
        {
            Money += (BigInteger)100 * (int)MoneyUpgradeLv;
        }
        else if (storeManager.storeusing == 2)
        {
            //Money += Money;
            //Gold += Gold;

            Money += (BigInteger)200 * (int)MoneyUpgradeLv;
        }
        else if (storeManager.storeusing == 3)
        {
            Money += (BigInteger)500 * (int)MoneyUpgradeLv;
        }
        else if (storeManager.storeusing == 4)
        {
            Money += (BigInteger)1000 * (int)MoneyUpgradeLv;
        }
        else if (storeManager.storeusing == 5)
        {
            Money += (BigInteger)1500 * (int)MoneyUpgradeLv;
        }
        else if (storeManager.storeusing == 6)
        {
            Money += (BigInteger)1500 * (int)MoneyUpgradeLv;
        }
        else if (storeManager.storeusing == 7)
        {
            Money += (BigInteger)2000 * (int)MoneyUpgradeLv;
        }
        else
        {
            Debug.Log("on click 코드 추가 필요");
        }

        TestText.GetComponent<Text>().text = MoneyUpgradeLv.ToString();
    }

    public void Reset()
    {
        Money = 0;
        Gold = 0;
    }

    public void GameSave()
    {

    }

    public void GameSaveOverlap()
    {

    }

    public void GameLoad()
    {

    }

    public void GameExit()
    {
        Application.Quit();
        GameSave();
    }
}
