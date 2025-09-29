using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource SFXSource;
    public AudioClip SpinClip;
    public AudioClip CoinTypeOneClip;
    public AudioClip CoinTypeTwoClip;

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
    }
    void Start()
    {

    }


    void Update()
    {

    }
    public void PlaySfx(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
