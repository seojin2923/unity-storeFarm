using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achie : MonoBehaviour
{
    public GameManager gameManager;
    public UpgradeManager upgradeManager;

    public GameObject[] AchiegetButton;
    public GameObject[] AchieclearButton;

    public TextAsset txt;
    string[,] Sentence;
    int lineSize, rowSize;

    public bool[] Achie_clear_bool;

    void Start()
    {
        Achie_clear_bool[0] = true;

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
        if(gameManager.Money >= 1000000)
        {
            Achie_clear_bool[1] = true;
        }
    }

    public void Achie_clear(int clear_num)
    {
        if (Achie_clear_bool[clear_num] == true)
        {
            gameManager.Money += int.Parse(Sentence[clear_num, 1]);
            AchiegetButton[clear_num].SetActive(false);
            AchieclearButton[clear_num].SetActive(true);
        }
        else
            return;
    }
}
