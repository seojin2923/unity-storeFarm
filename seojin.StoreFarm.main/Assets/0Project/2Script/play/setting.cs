using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setting : MonoBehaviour
{
    [Header("BGM")]
    public Slider BGMSlider;
    public AudioSource BGMaudio;
    bool isBGMmute;
    private float backVol = 1f;

    [Header("SFX")]
    public AudioSource SFXaudio;
    public AudioClip[] SFXClip;

    [Header("testmode")]
    public GameObject doublebutton;

    [Header("Manager")]
    public PanelManager panelManager;

    void Start()
    {
        backVol = PlayerPrefs.GetFloat("BGMSlider", 1f);
        BGMSlider.value = backVol;
        BGMaudio.volume = BGMSlider.value;
    }

    void Update()
    {
        BGMSoundSlider();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelManager.Panel(5);
        }
    }

    public void testmode()
    {
        doublebutton.SetActive(true);
        SFX(0);
    }

    public void SFX(int Clip)
    {
        SFXaudio.clip = SFXClip[Clip];
        SFXaudio.Play();
    }

    public void BGMSoundSlider()
    {
        BGMaudio.volume = BGMSlider.value;

        backVol = BGMSlider.value;
        PlayerPrefs.SetFloat("BGMSlider", backVol);
    }

    public void BGMmute()
    {
        if (isBGMmute == false)
        {
            isBGMmute = true;
            BGMaudio.mute = true;
        }
        else
        {
            isBGMmute = false;
            BGMaudio.mute = false;
        }
    }
}
