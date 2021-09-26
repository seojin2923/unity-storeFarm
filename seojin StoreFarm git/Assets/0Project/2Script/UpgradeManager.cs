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
            MoneyUpgradeButtonText.GetComponent<Text>().text = "5000¿ø";
        else if (MoneyUpgradeLevel == 2)
            MoneyUpgradeButtonText.GetComponent<Text>().text = "10000¿ø";

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

    }
}
