using UnityEngine;


public class AudioManager : MonoBehaviour,Iobserver
{
    public static AudioManager Instance;

    [SerializeField] private Subject ControllerSubject;
    [SerializeField] UIManager uIManager;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioClip CoinTypeOneClip;
    [SerializeField] private AudioClip CoinTypeTwoClip;
    [SerializeField] private AudioClip BtnClick;
    public AudioClip SpinClip;


    void OnEnable()
    {
        ControllerSubject.AddObserver(this);
        uIManager.OnUIButtonPress += PressSound;     

    }
    void OnDisable()
    {
        ControllerSubject.RemoveObserver(this);
        uIManager.OnUIButtonPress -= PressSound;

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
    public void onNotify(GameState state)
    {
        if (state == GameState.Win1x || state == GameState.Win2x)
        {
            PlayMatchSFX();
        }
        else if(state == GameState.Win3x)
        {
            PlayJackPotSFX();
        }
    }

    //Play Sfx based on bones
    private void PlayJackPotSFX()
    {

        SFXSource.PlayOneShot(CoinTypeTwoClip);

    }
     private void PlayMatchSFX()
    {
        
        
        SFXSource.PlayOneShot(CoinTypeOneClip);
        

    }
    
    //Play slot spining sound 
    public void PlaySpinSound()
    {
        SFXSource.PlayOneShot(SpinClip);
    }
   
   //Button click Sfx
   private void PressSound()
    {
        SFXSource.PlayOneShot(BtnClick);
    }
}

