using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Load : MonoBehaviour
{
    public void LoadPlay()
    {
        LoadingScene.LoadScene("Play");
    }

    public void LoadMain()
    {
        LoadingScene.LoadScene("Main");
        if (PhotonNetwork.IsConnected)
            PhotonNetwork.Disconnect();
    }

    public void LoadHelp()
    {
        LoadingScene.LoadScene("Help");
    }

    public void LoadnewVersion()
    {
        LoadingScene.LoadScene("newVersion");
    }

    public void LoadBattle()
    {
        LoadingScene.LoadScene("Battle");
    }
}
