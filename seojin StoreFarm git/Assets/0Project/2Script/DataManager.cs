using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Numerics;
using System.IO;
using System.Xml.Serialization;

public class DataManager : MonoBehaviour
{
    public GameManager gameManager;
    public StoreManager storeManager;

    void Start()
    {
        //CreateXml();
        //LoadXml();
        //SaveOverlapXml();
    }

    public void CreateXml()
    {
        XmlDocument xmlDoc = new XmlDocument();
        // Xml�� �����Ѵ�(xml�� ������ ���ڵ� ����� �����ش�.)
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        // ��Ʈ ��� ����
        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "saveDataInfo", string.Empty);
        xmlDoc.AppendChild(root);

        // �ڽ� ��� ����
        XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, "saveData", string.Empty);
        root.AppendChild(child);

        // �ڽ� ��忡 �� �Ӽ� ����
        XmlElement store_number = xmlDoc.CreateElement("store_number");
        store_number.InnerText = storeManager.storeusing.ToString();
        child.AppendChild(store_number);

        XmlElement money = xmlDoc.CreateElement("money");
        money.InnerText = gameManager.Money.ToString();
        child.AppendChild(money);

        XmlElement gold = xmlDoc.CreateElement("gold");
        gold.InnerText = gameManager.Gold.ToString();
        child.AppendChild(gold);

        xmlDoc.Save("./Assets/Resources/saveData.xml");
    }

    public void LoadXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("saveData");
        Debug.Log(textAsset);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("saveDataInfo/saveData");

        foreach (XmlNode node in nodes)
        {
            //Debug.Log("store_number :: " + node.SelectSingleNode("store_number").InnerText);
            //Debug.Log("money :: " + node.SelectSingleNode("money").InnerText);
            //Debug.Log("gold :: " + node.SelectSingleNode("gold").InnerText);

            string save_store_number = node.SelectSingleNode("store_number").InnerText;
            string save_money = node.SelectSingleNode("money").InnerText;
            string save_gold = node.SelectSingleNode("gold").InnerText;

            storeManager.storeusing = int.Parse(save_store_number);
            gameManager.Money = int.Parse(save_money);
            gameManager.Gold = int.Parse(save_gold);

        }
    }

    public void SaveOverlapXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("saveData");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("saveDataInfo/saveData");
        XmlNode character = nodes[0];

        character.SelectSingleNode("store_number").InnerText = storeManager.storeusing.ToString();
        character.SelectSingleNode("money").InnerText = gameManager.Money.ToString();
        character.SelectSingleNode("gold").InnerText = gameManager.Gold.ToString();

        xmlDoc.Save("./Assets/Resources/saveData.xml");
    }
}
