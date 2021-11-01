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
        for (int i = 0; i < 12; i++)
        {
            if (thingManager.boolthingunLock[i] == true)
                Money += int.Parse(thingManager.Sentence[i, 2]);
        }

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
        for (int i = 0; i < 5; i++)
        {
            if (panelManager.boolPanel[i] == true)
            {
                panelManager.boolPanel[i] = false;
                panelManager.Panelanim[i].SetFloat("anim", -1.0f);
                panelManager.Panelanim[i].SetTrigger("play");
            }
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
