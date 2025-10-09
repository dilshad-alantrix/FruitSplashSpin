using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;

    [SerializeField] ParticleSystem CoinParticle;

    [SerializeField] ParticleSystem FruitParticle;
    [SerializeField] GameController gameController;

    private void OnEnable()
    {
        gameController.OnStop += PlayParticle;
        CoinManager.Instance.ShopCoin += ShopCoins;
    }

    private void OnDisable()
    {
        gameController.OnStop -= PlayParticle;
          CoinManager.Instance.ShopCoin += ShopCoins;
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

        CoinParticle.Stop();
        FruitParticle.Stop();
    }

    private void PlayParticle(int mulitiple)
    {
        CoinParticle.emissionRate = 10 * mulitiple;
        CoinParticle.Play();
        if (mulitiple == 3)
        {
            JackPort();
        }


    }
    private void ShopCoins()
    {
        CoinParticle.Play();
    }

    private void JackPort()
    {
        FruitParticle.Play();
    }


}
