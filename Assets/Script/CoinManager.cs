using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public TMP_Text BetCoinText;
    public TMP_Text TotalCoinText;

    private int BetCoin;
    private int TotalCoin;

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
        BetCoin = 10;
        TotalCoin = 100;
        BetCoinText.text = BetCoin.ToString();
        TotalCoinText.text = TotalCoin.ToString();
    }

    public void AddBetCoin()
    {
        if (BetCoin < TotalCoin)
        {
            BetCoin += 10;
            BetCoinText.text = BetCoin.ToString();
        }
    }

    public void SubBetCoin()
    {
        if (BetCoin > 10)
        {
            BetCoin -= 10;
            BetCoinText.text = BetCoin.ToString();
        }
    }

    public void MultiBetCoin(int multi)
    {
        TotalCoin += BetCoin * multi;
        TotalCoinText.text = TotalCoin.ToString();
    }
    public void SubTotalCoin()
    {
        if (TotalCoin >= BetCoin)
        {
            TotalCoin -= BetCoin;
            TotalCoinText.text = TotalCoin.ToString();
        }
    }
    
    public void shopAddCoin(int coin)
    {
        TotalCoin += coin;
        TotalCoinText.text = TotalCoin.ToString();
    }
}
