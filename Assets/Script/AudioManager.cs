using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] GameController gameController;
    [SerializeField] UIManager uIManager;
    public AudioClip SpinClip;
    [SerializeField] AudioClip CoinTypeOneClip;
    [SerializeField] AudioClip CoinTypeTwoClip;
    [SerializeField] AudioClip BtnClick;


    void OnEnable()
    {
        gameController.OnStop += PlaySfx;
        uIManager.onPress += PressSound;

    }
    void OnDisable()
    {
        gameController.OnStop -= PlaySfx;
        uIManager.onPress -= PressSound;

    }
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

    }

    private void PlaySfx(int multiple)
    {
        if (multiple == 3)
        {
            SFXSource.PlayOneShot(CoinTypeTwoClip);
        }
        else
        {
            SFXSource.PlayOneShot(CoinTypeOneClip);
        }

    }

    public void PlaySpinSound()
    {
        SFXSource.PlayOneShot(SpinClip);
    }
   
   private void PressSound()
    {
        SFXSource.PlayOneShot(BtnClick);
    }
}

