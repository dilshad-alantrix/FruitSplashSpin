using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;

    [SerializeField] ParticleSystem CoinParticle;
    [SerializeField] GameController gameController;

    private void OnEnable()
    {
        gameController.OnStop += PlayParticle;
    }
    
    private void OnDisable()
    {
        
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
    }
   
   private void PlayParticle(int mulitiple)
    {
        CoinParticle.emissionRate = 10 * mulitiple;
        CoinParticle.Play();
    }


}
