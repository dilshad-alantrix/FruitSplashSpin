using UnityEngine;
using TMPro;


public class CoinManager : MonoBehaviour, Iobserver
{
    public static CoinManager Instance;
    
     [SerializeField] private  Subject ControllerSubject;
    [SerializeField] private TMP_Text BetCoinText;
    [SerializeField] private TMP_Text TotalCoinText;
    [SerializeField] private MyBtn AddCoin;
    [SerializeField] private MyBtn SubCoin;


    private int _betCoin;
    private int _totalCoin;

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

    void OnEnable()
    {
        ControllerSubject.AddObserver(this);

        AddCoin.onBtnPressed += (s) => { AddBetCoin(); };
        SubCoin.onBtnPressed += (s) => { SubBetCoin(); };

        AddCoin.onClick.AddListener(AddBetCoin);
        SubCoin.onClick.AddListener(SubBetCoin);
    }
    void OnDisable()
    {
        ControllerSubject.RemoveObserver(this);
        AddCoin.onBtnPressed -= (s) => { AddBetCoin(); };
        SubCoin.onBtnPressed -= (s) => { SubBetCoin(); };

        AddCoin.onClick.RemoveListener(AddBetCoin);
        SubCoin.onClick.RemoveListener(SubBetCoin);
    }

    public void onNotify(GameState state)
    {

        if (state == GameState.PressSpinBtn)
        {
            SubTotalCoin();
        }
        else if (state == GameState.Win1x)
        {
            MultiBetCoin(1);
        }
         else if(state == GameState.Win2x)
        {
             MultiBetCoin(2);
        }
         else if(state == GameState.Win3x)
        {
             MultiBetCoin(3);
        }
        
    }

    void Start()
    {
      
        _betCoin = 10;
        _totalCoin = PlayerPrefs.GetInt("TotalCoin", 200);
        BetCoinText.text = _betCoin.ToString();
        TotalCoinText.text = _totalCoin.ToString();

    }

    private void AddBetCoin()
    {
        if (_betCoin < _totalCoin && AddCoin.interactable)
        {
            _betCoin += 10;
            BetCoinText.text = _betCoin.ToString();
        }
    }

    private void SubBetCoin()
    {
        if (_betCoin > 10 && SubCoin.interactable)
        {
            _betCoin -= 10;
            BetCoinText.text = _betCoin.ToString();
        }
    }

    //multiplay coin based on result 
    private void MultiBetCoin(int multi)
    {
        _totalCoin += _betCoin * multi;
        setCoins();
        TotalCoinText.text = _totalCoin.ToString();
    }
    
    private void SubTotalCoin()
    {
        if (_totalCoin >= _betCoin)
        {
            _totalCoin -= _betCoin;
            setCoins();
            TotalCoinText.text = _totalCoin.ToString();
        }
    }
    public void shopAddCoin(int coin)
    {
        _totalCoin += coin;
        setCoins();
        TotalCoinText.text = _totalCoin.ToString();

    }
    public bool ChekCons()
    {
        if (_totalCoin >= _betCoin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private void setCoins()
    {
        PlayerPrefs.SetInt("TotalCoin", _totalCoin);
    }
}
