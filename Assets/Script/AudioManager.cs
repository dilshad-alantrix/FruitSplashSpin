using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource SFXSource;
    public AudioClip SpinClip;
    public AudioClip CoinTypeOneClip;
    public AudioClip CoinTypeTwoClip;

    public Toggle toggle;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


       
        toggle.isOn = PlayerPrefs.GetInt("Sound") == 1 ? true : false;
    }


    void Update()
    {
        AudioListener.volume = toggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("Sound", toggle.isOn ? 1 : 0);
    }
       
    public void PlaySfx(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
