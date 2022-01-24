using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class versionManager : MonoBehaviour
{
    public bool isBeta;

    public string downloadLink;
    public string versionLink;

    void Start()
    {
        if (isBeta == true)
        {
            downloadLink = "http://seojin1.kro.kr/2.0/html/game/storeFarmBeta.html";
            versionLink = "http://seojin1.kro.kr/2.0/html/game/storeFarmVersionBeta.txt";
        }
        else
        {
            downloadLink = "http://seojin1.kro.kr/2.0/html/game/storeFarm.html";
            versionLink = "http://seojin1.kro.kr/2.0/html/game/storeFarmVersion.txt";
        }
    }

    void Update()
    {
        
    }
}
