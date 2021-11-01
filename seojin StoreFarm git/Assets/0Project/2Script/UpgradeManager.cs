using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public GameManager gameManager;

    public int MoneyUpgradeLevel = 1;
    public Text MoneyUpgradeButtonText;
    public Text MoneyUpgradeLavelText;

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

        StartCoroutine(MoneyUpgradeText());
    }

    void Update()
    {
        //MoneyUpgrade();
    }

    IEnumerator MoneyUpgradeText()
    {
        int Line = MoneyUpgradeLevel - 1;

        MoneyUpgradeButtonText.GetComponent<Text>().text = Sentence[Line, 1];

        MoneyUpgradeLavelText.GetComponent<Text>().text = "Lv." + MoneyUpgradeLevel.ToString();

        yield return null;
        StartCoroutine(MoneyUpgradeText());
    }

    public void UpgradeMoney()
    {
        int Line = MoneyUpgradeLevel - 1;

        if(MoneyUpgradeLevel == int.Parse(Sentence[Line, 0]) && gameManager.Money >= int.Parse(Sentence[Line, 2]))
        {
            MoneyUpgradeLevel++;
            gameManager.Money -= int.Parse(Sentence[Line, 2]);
        }
    }
}
