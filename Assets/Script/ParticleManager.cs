using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;

    public ParticleSystem CoinParticle;

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
   
   public void PlayParticle()
    {
        CoinParticle.Play();
    }


}
