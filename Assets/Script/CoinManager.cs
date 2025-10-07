using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    [SerializeField] GameController gameController;

    [SerializeField] TMP_Text BetCoinText;
    [SerializeField] TMP_Text TotalCoinText;

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
        gameController.OnSpin += SubTotalCoin;
        gameController.OnStop += MultiBetCoin;

    }
    void OnDisable()
    {
        gameController.OnSpin -= SubTotalCoin;
    }

    void Start()
    {
       
        _betCoin = 10;
        _totalCoin = PlayerPrefs.GetInt("TotalCoin");
        BetCoinText.text = _betCoin.ToString();
        TotalCoinText.text = _totalCoin.ToString();

    }

    public void AddBetCoin()
    {
        if (_betCoin < _totalCoin)
        {
            _betCoin += 10;
            BetCoinText.text = _betCoin.ToString();
        }
    }

    public void SubBetCoin()
    {
        if (_betCoin > 10)
        {
            _betCoin -= 10;
            BetCoinText.text = _betCoin.ToString();
        }
    }

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
