using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioClip CoinTypeOneClip;
    [SerializeField] private AudioClip CoinTypeTwoClip;
    [SerializeField] private AudioClip BtnClick;
    public AudioClip SpinClip;


    void OnEnable()
    {
        EventManager.OnSpinStop += PlaySfx;
        EventManager.OnUIButtonPress += PressSound;
        EventManager.OnPlaySlotSfx += PlaySpinSound;

    }
    void OnDisable()
    {
        EventManager.OnSpinStop -= PlaySfx;
        EventManager.OnUIButtonPress -= PressSound;
         EventManager.OnPlaySlotSfx -= PlaySpinSound;

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

    //Play Sfx based on bones
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
    
    //Play slot spining sound 
    private void PlaySpinSound()
    {
        SFXSource.PlayOneShot(SpinClip);
    }
   
   //Button click Sfx
   private void PressSound()
    {
        SFXSource.PlayOneShot(BtnClick);
    }
}

