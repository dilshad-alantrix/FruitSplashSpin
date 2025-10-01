using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [SerializeField] TMP_Text BetCoinText;
    [SerializeField] TMP_Text TotalCoinText;

    private int _betCoin;
    private int _totalCoin;

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
        _betCoin = 10;
        _totalCoin = 100;
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

    public void MultiBetCoin(int multi)
    {
        _totalCoin += _betCoin * multi;
        TotalCoinText.text = _totalCoin.ToString();
    }
    public void SubTotalCoin()
    {
        if (_totalCoin >= _betCoin)
        {
            _totalCoin -= _betCoin;
            TotalCoinText.text = _totalCoin.ToString();
        }
    }

    public void shopAddCoin(int coin)
    {
        _totalCoin += coin;
        TotalCoinText.text = _totalCoin.ToString();
        AudioManager.instance.PlaySfx(AudioManager.instance.CoinTypeTwoClip);
        ParticleManager.instance.PlayParticle();
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
}
