using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Numerics;

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
        // Xml을 선언한다(xml의 버전과 인코딩 방식을 정해준다.)

        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        // 루트 노드 생성
        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "saveDataInfo", string.Empty);
        xmlDoc.AppendChild(root);

        // 자식 노드 생성
        XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, "saveData", string.Empty);
        root.AppendChild(child);

        // 자식 노드에 들어갈 속성 생성
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
        //xmlDoc.Save("!/assets/saveData.xml");

    }

    public IEnumerator Load()
    {
        // xmlsample_02.xml 파일은 유니티 Asset폴더 하위에 StreamingAssets 폴더를 만들어 안에다 넣어두어야 한다
        string fileName = "saveData.xml";   //파일명
        string filePath;                        //파일경로 

        switch (Application.platform)       //플랫폼에따라 파일경로를 다르게한다
        {
            default:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:     //윈도우 유니티 에디터, PC버전 빌드일때의 경로
                filePath = Application.dataPath + "./Assets/Resources/" + fileName;
                break;

            case RuntimePlatform.Android:           //안드로이드 빌드 일때의 경로
                filePath = "jar:file://" + Application.dataPath + "!/assets/saveData.xml";
                break;
        }

        //파일경로를 참조하여 해당 파일을 WWW클래스로 만들어준다
        var file_www = new WWW(filePath);

        //WWW 클래스로 전부 읽을때까지 잠깐 대기
        yield return file_www;

        XmlDocument xmlDoc = new XmlDocument();     //비어있는 XML 만들고
        xmlDoc.LoadXml(file_www.text);              //WWW클래스로 만든 파일의 text를 XML에 집어 넣는다


        //아래는 XML파싱
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
