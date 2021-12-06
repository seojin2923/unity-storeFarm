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

    int achie2level;
    public Text achie2MainText;
    public Text achie2GetText;

    public int[] achie2needlevel;

    void Update()
    {
        /*if (achie2level == 0)
        {
            achie2MainText.text = "머니\n" + achie2needlevel + "레벨 달성";
            achie2GetText.text = achie2level + "만원";

            if (upgradeManager.MoneyUpgradeLevel >= achie2needlevel[0])
            {
                AchiegetButton[0].SetActive(true);
                AchieclearButton[0].SetActive(false);
            }
        }*/
            
    }

    public void Achie1_clear()
    {
        gameManager.Money += 100000;
        AchiegetButton[0].SetActive(false);
        AchieclearButton[0].SetActive(true);
    }

    public void Achie_clear(int clear_number)
    {
        int down1 = clear_number - 1;

        if(clear_number == 2)
        {
            achie2level++;
        }

        AchiegetButton[down1].SetActive(false);
        AchieclearButton[down1].SetActive(true);
    }
}
