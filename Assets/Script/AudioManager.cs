using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource SFXSource;
    public AudioClip SpinClip;
    public AudioClip CoinTypeOneClip;
    public AudioClip CoinTypeTwoClip;

    public Toggle toggleOne;
    public Toggle toggleTwo;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }



        toggleOne.isOn = PlayerPrefs.GetInt("Sound") == 1 ? true : false;
        toggleTwo.isOn = PlayerPrefs.GetInt("Sound") == 1 ? true : false;
    }


    void Update()
    {
        AudioListener.volume = toggleOne.isOn ? 1 : 0;
        PlayerPrefs.SetInt("Sound", toggleOne.isOn ? 1 : 0);

        AudioListener.volume = toggleTwo.isOn ? 1 : 0;
        PlayerPrefs.SetInt("Sound", toggleTwo.isOn ? 1 : 0);    
    }
       
    public void PlaySfx(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
