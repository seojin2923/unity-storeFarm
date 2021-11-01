using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Numerics;

public class DataManager : MonoBehaviour
{
    public GameManager gameManager;

    public void Save()
    {
        PlayerState myPlayerState = new PlayerState();

        myPlayerState.Money = gameManager.Money;
        myPlayerState.Gold = gameManager.Gold;

        string json = JsonUtility.ToJson(myPlayerState);
        Debug.Log(json);

        string fileName = "gameData";
        string path = Application.dataPath + "/Resources/" + fileName + ".Json";

        File.WriteAllText(path, json);
    }

    public void Load()
    {
        string fileName = "gameData";
        string path = Application.dataPath + "/Resources/" + fileName + ".Json";
        string json = File.ReadAllText(path);

        PlayerState myPlayerState = JsonUtility.FromJson<PlayerState>(json);

        Debug.Log(myPlayerState.Money);
        Debug.Log(myPlayerState.Gold);
    }
}

public class PlayerState
{
    public BigInteger Money;
    public BigInteger Gold;
}
