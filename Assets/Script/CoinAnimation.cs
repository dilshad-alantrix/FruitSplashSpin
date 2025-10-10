using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    [SerializeField] ObjectPool Pool;
    [SerializeField] Transform CoinStart;
    [SerializeField] Transform CoinEnd;
    [SerializeField] float Duration;
    [SerializeField] Ease MoveType;
    [SerializeField] int NumOFCoin;
    [SerializeField] float Delay;
    [SerializeField] float Offset = 20f;
    [SerializeField] float size = 1f;


    public void CoinMove()
    {
        
       for(int i=0;i<NumOFCoin;i++)
        {
            var targetDelay = i * Delay;
            showCoin(targetDelay);
        }
    }

    private void showCoin(float delay)
    {
         var CoinObject = Pool.GetGameObject();
         var offset = new Vector3(Random.Range(-Offset, Offset), Random.Range(-Offset, Offset),0f);
         var StartPos = offset + CoinStart.position;
         CoinObject.transform.position = StartPos;
        CoinObject.transform.localScale = new Vector3(size,size,size);
         CoinObject.transform.DOMove(CoinEnd.position, Duration).SetEase(MoveType).SetDelay(delay).OnComplete(() =>
         {
             CoinObject.gameObject.SetActive(false);
         });
    }
}
