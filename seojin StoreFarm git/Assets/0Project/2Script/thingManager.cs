using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thingManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject[] thing;

    public bool[] boolthingunLock;

    public GameObject[] LockGroup;
    public GameObject[] unLockGroup;

    public TextAsset txt;
    public string[,] Sentence;
    int lineSize, rowSize;

    void Start()
    {
        // ���ʹ����� ������ ������ �迭�� ũ�� ����
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        Sentence = new string[lineSize, rowSize];

        // �� �ٿ��� ������ ����
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for (int j = 0; j < rowSize; j++) Sentence[i, j] = row[j];
        }
    }

    public void buy(int buy_number)
    {
        int down1 = buy_number - 1;
        int down2 = buy_number - 2;

        if(gameManager.Money >= int.Parse(Sentence[down1, 1]))
        {
            gameManager.Money -= int.Parse(Sentence[down1, 1]);
            boolthingunLock[down1] = true;
            thing[down1].SetActive(true);

            LockGroup[down1].SetActive(false);
            unLockGroup[down1].SetActive(true);
        }
        else
        {
            Debug.Log("���� " + gameManager.Money + "�ۿ� ����");
        }
    }
}
