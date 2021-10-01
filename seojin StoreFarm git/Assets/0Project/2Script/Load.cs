using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public void LoadPlay()
    {
        LoadingScene.LoadScene("Play");
    }

    public void LoadMain()
    {
        LoadingScene.LoadScene("Main");
    }
}
