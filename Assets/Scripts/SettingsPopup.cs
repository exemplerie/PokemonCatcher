using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SettingsPopup : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    public GameObject questManager;
    public GameObject startScreen;


    void Start()
    {
        questManager.SetActive(true);
        startScreen.SetActive(true);
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnMusicValue(float volume)
    {
        musicSource.volume = volume;
    }

    public void OnSoundValue(float volume)
    {
        AudioListener.volume = volume;
    }
}