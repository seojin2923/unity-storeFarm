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

    void Update()
    {
        MoneyUpgrade();
    }

    void MoneyUpgrade()
    {
        if (MoneyUpgradeLevel == 1)
            MoneyUpgradeButtonText.GetComponent<Text>().text = "5õ��";
        else if (MoneyUpgradeLevel == 2)
            MoneyUpgradeButtonText.GetComponent<Text>().text = "����";
        else if (MoneyUpgradeLevel == 3)
            MoneyUpgradeButtonText.GetComponent<Text>().text = "4����";
        else if (MoneyUpgradeLevel == 4)
            MoneyUpgradeButtonText.GetComponent<Text>().text = "10����";
        else if (MoneyUpgradeLevel == 5)
            MoneyUpgradeButtonText.GetComponent<Text>().text = "15����";
        else if (MoneyUpgradeLevel == 6)
            MoneyUpgradeButtonText.GetComponent<Text>().text = "34����";
        else if (MoneyUpgradeLevel == 7)
            MoneyUpgradeButtonText.GetComponent<Text>().text = "45����";
        else if (MoneyUpgradeLevel == 8)
            MoneyUpgradeButtonText.GetComponent<Text>().text = "68����";
        else if (MoneyUpgradeLevel == 9)
            MoneyUpgradeButtonText.GetComponent<Text>().text = "90����";
        else if (MoneyUpgradeLevel == 10)
            MoneyUpgradeButtonText.GetComponent<Text>().text = "140����";

        MoneyUpgradeLavelText.GetComponent<Text>().text = "Lv." + MoneyUpgradeLevel.ToString();
    }

    public void UpgradeMoney()
    {
        if (MoneyUpgradeLevel == 1 && gameManager.Money >= 5000)
        {
            MoneyUpgradeLevel++;
            gameManager.Money -= 5000;
        }
        else if (MoneyUpgradeLevel == 2 && gameManager.Money >= 10000)
        {
            MoneyUpgradeLevel++;
            gameManager.Money -= 10000;
        }
        else if (MoneyUpgradeLevel == 3 && gameManager.Money >= 40000)
        {
            MoneyUpgradeLevel++;
            gameManager.Money -= 40000;
        }
        else if (MoneyUpgradeLevel == 4 && gameManager.Money >= 100000)
        {
            MoneyUpgradeLevel++;
            gameManager.Money -= 100000;
        }
        else if (MoneyUpgradeLevel == 5 && gameManager.Money >= 150000)
        {
            MoneyUpgradeLevel++;
            gameManager.Money -= 150000;
        }
        else if (MoneyUpgradeLevel == 6 && gameManager.Money >= 340000)
        {
            MoneyUpgradeLevel++;
            gameManager.Money -= 340000;
        }
        else if (MoneyUpgradeLevel == 7 && gameManager.Money >= 450000)
        {
            MoneyUpgradeLevel++;
            gameManager.Money -= 450000;
        }
        else if (MoneyUpgradeLevel == 8 && gameManager.Money >= 680000)
        {
            MoneyUpgradeLevel++;
            gameManager.Money -= 680000;
        }
        else if (MoneyUpgradeLevel == 9 && gameManager.Money >= 900000)
        {
            MoneyUpgradeLevel++;
            gameManager.Money -= 900000;
        }
        else if (MoneyUpgradeLevel == 10 && gameManager.Money >= 1400000)
        {
            MoneyUpgradeLevel++;
            gameManager.Money -= 1400000;
        }

    }
}
