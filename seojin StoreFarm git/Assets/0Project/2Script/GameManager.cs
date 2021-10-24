using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PanelManager panelManager;
    public StoreManager storeManager;
    public thingManager thingManager;
    public UpgradeManager upgradeManager;

    public BigInteger Money;
    public BigInteger Gold;

    public Text MoneyTxt;
    public Text GoldTxt;
    public Text TestText;

    public TextAsset txt;
    string[,] Sentence;
    int lineSize, rowSize;

    void Start()
    {
        StartCoroutine(Timemoney());

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
    }

    void Update()
    {
        ReLoad();
        if (Input.GetButtonDown("Jump"))
            onClick();
    }

    IEnumerator Timemoney()
    {
        yield return new WaitForSecondsRealtime(1);

        //Store Timemoney
        int Line = storeManager.storeusing - 1;
        Money += int.Parse(Sentence[Line, 3]);

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
        if (panelManager.boolPanel[0] == true)
        {
            panelManager.boolPanel[0] = false;
            panelManager.Panelanim[0].SetTrigger("doHide");
        }

        if (panelManager.boolPanel[1] == true)
        {
            panelManager.boolPanel[1] = false;
            panelManager.Panelanim[1].SetTrigger("doHide");
        }
        
        if (panelManager.boolPanel[2] == true)
        {
            panelManager.boolPanel[2] = false;
            panelManager.Panelanim[2].SetTrigger("doHide");
        }

        if (panelManager.boolPanel[3] == true)
        {
            panelManager.boolPanel[3] = false;
            panelManager.Panelanim[3].SetTrigger("doHide");
        }

        if (panelManager.boolPanel[4] == true)
        {
            panelManager.boolPanel[4] = false;
            panelManager.xmlPanel.SetActive(false);
        }
        
        float MoneyUpgradeLv = upgradeManager.MoneyUpgradeLevel / 5 + 1;
        int Line = storeManager.storeusing - 1;

        Money += int.Parse(Sentence[Line, 2]) * (int)MoneyUpgradeLv;

        TestText.GetComponent<Text>().text = MoneyUpgradeLv.ToString();
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
