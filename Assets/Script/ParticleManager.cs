using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance;

    public ParticleSystem CoinParticle;

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

        CoinParticle.Stop();
    }
   
   public void PlayParticle()
    {
        CoinParticle.Play();
    }


}
