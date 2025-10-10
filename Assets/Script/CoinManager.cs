using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    [SerializeField] GameController gameController;

    [SerializeField] TMP_Text BetCoinText;
    [SerializeField] TMP_Text TotalCoinText;
    [SerializeField] MyBtn AddCoin;
     [SerializeField] MyBtn SubCoin;


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

        AddCoin.onBtnPressed += (s) => { AddBetCoin(); };
        SubCoin.onBtnPressed += (s) => { SubBetCoin(); };
    }
    void OnDisable()
    {
        gameController.OnSpin -= SubTotalCoin;
        AddCoin.onBtnPressed -= (s) => { AddBetCoin(); };
        SubCoin.onBtnPressed -= (s) => { SubBetCoin(); };
    }

    void Start()
    {
       
        _betCoin = 10;
        _totalCoin = PlayerPrefs.GetInt("TotalCoin",100);
        BetCoinText.text = _betCoin.ToString();
        TotalCoinText.text = _totalCoin.ToString();

    }

    public void AddBetCoin()
    {
        if (_betCoin < _totalCoin && AddCoin.interactable)
        {
            _betCoin += 10;
            BetCoinText.text = _betCoin.ToString();
        }
    }

    public void SubBetCoin()
    {
        if (_betCoin > 10 && AddCoin.interactable)
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
