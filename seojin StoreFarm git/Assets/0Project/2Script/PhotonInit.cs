using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonInit : MonoBehaviourPunCallbacks, IPunObservable
{
    public InputField NickNameInput;
    public GameObject connectPanel;
    public GameObject connectingPanel;

    public GameObject ConnectingText;
    public GameObject ConnectBtn;

    public Text playerNum;

    public Text localplayername;
    public Text outplayername;
    public Text localscore;
    public Text outscore;

    public GameObject playPanel;

    public int intlocalscore;
    public int intoutscore;

    void Awake()
    {
        Screen.SetResolution(960, 540, false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }

    public void Connect() => PhotonNetwork.ConnectToBestCloudServer();
    public void Connecting()
    {
        ConnectingText.SetActive(true);
        ConnectBtn.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, null);
    }

    public override void OnJoinedRoom()
    {
        connectPanel.SetActive(false);
        ConnectingText.SetActive(false);
        ConnectBtn.SetActive(true);
        connectingPanel.SetActive(true);

        StartCoroutine(JoinedRoom());
    }

    IEnumerator JoinedRoom()
    {
        yield return null;

        print("방 접속자수 : " + PhotonNetwork.CountOfPlayersInRooms);
        playerNum.GetComponent<Text>().text = "게임을 시작하기 위해 사용자를 기다리는중";
        if(PhotonNetwork.CountOfPlayersInRooms == 1)
        {
            playerNum.GetComponent<Text>().text = "게임을 시작합니다.";
            yield return new WaitForSecondsRealtime(5f);
            connectingPanel.SetActive(false);
            playPanel.SetActive(true);
            StartCoroutine(playing());
        }
        else
            StartCoroutine(JoinedRoom());
    }

    public void onclick()
    {
        intlocalscore++;
    }

    IEnumerator playing()
    {
        localplayername.text = PhotonNetwork.NickName;
        yield return null;
        StartCoroutine(playing());
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }
}
