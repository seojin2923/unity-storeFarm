using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achie : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject Achie1getbutton;
    public GameObject Achie1clearbutton;

    public void Achie1_clear()
    {
        gameManager.Money += 100000;
        Achie1getbutton.SetActive(false);
        Achie1clearbutton.SetActive(true);
    }
}
