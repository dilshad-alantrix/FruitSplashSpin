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
    public AudioClip SpinClip;
    public AudioClip CoinTypeOneClip;
    public AudioClip CoinTypeTwoClip;


    void OnEnable()
    {
        gameController.OnStop += PlaySfx;
    }
    void OnDisable()
    {
        gameController.OnStop -= PlaySfx;
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
            SFXSource.PlayOneShot(CoinTypeOneClip);
        }
        else
        {
            SFXSource.PlayOneShot(CoinTypeTwoClip);
        }

    }

    public void PlaySpinSound()
    {
        SFXSource.PlayOneShot(SpinClip);
    }

}

