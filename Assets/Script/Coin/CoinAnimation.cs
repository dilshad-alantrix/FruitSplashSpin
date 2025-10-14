using DG.Tweening;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    [Header("Coin Animation settings")]
    [SerializeField] private ObjectPool Pool;
    [SerializeField] private Transform CoinStart;
    [SerializeField] private Transform CoinEnd;
    [SerializeField] private float Duration;
    [SerializeField] private Ease MoveType;
    [SerializeField] private int NumOFCoin;
    [SerializeField] private float Delay;
    [SerializeField] private float Offset = 20f;
    [SerializeField] private float size = 1f;


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
        //Creating coins by using object pool
        var CoinObject = Pool.GetGameObject();
        var offset = new Vector3(Random.Range(-Offset, Offset), Random.Range(-Offset, Offset),0f);
        var StartPos = offset + CoinStart.position;
         
         //Change position and Scale 
         CoinObject.transform.position = StartPos;
         CoinObject.transform.localScale = new Vector3(size,size,size);
         CoinObject.transform.DOMove(CoinEnd.position, Duration).SetEase(MoveType).SetDelay(delay).OnComplete(() =>
         {
             CoinObject.gameObject.SetActive(false);
         });
    }
}
