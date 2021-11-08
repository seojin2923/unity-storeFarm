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

    public TextAsset txt;
    string[,] Sentence;
    int lineSize, rowSize;

    public string[] storename;

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


        storeText.text = storename[Line];

        yield return null;
        StartCoroutine(reload());
    }

    public void use(int number)
    {
        storeusing = number;
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

}