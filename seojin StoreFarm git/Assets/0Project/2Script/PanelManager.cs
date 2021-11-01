using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public bool[] boolPanel;

    public Animator[] Panelanim;

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
    }

    void Update()
    {

    }

    public void Panel(int PanelNumber)
    {
        int Panelup1 = PanelNumber + 1;
        int Paneldown1 = PanelNumber - 1;

        for (int i = 0; i < 5; i++)
        {
            if (boolPanel[i] == true)
            {
                boolPanel[i] = false;
                Panelanim[i].SetFloat("anim", -1.0f);
                Panelanim[i].SetTrigger("play");
            }
        }


        if (boolPanel[Paneldown1])
        {
            boolPanel[Paneldown1] = false;
            Panelanim[Paneldown1].SetFloat("anim", -1.0f);
            Panelanim[Paneldown1].SetTrigger("play");
        }
        else
        {
            boolPanel[Paneldown1] = true;
            Panelanim[Paneldown1].SetFloat("anim", 1.0f);
            Panelanim[Paneldown1].SetTrigger("play");
        }
    }
}
