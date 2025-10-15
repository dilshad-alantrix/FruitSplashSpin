using UnityEngine;

public class DailySpinManager : MonoBehaviour
{
    [SerializeField] private SpinningWheel wheel;

    void Update()
    {
        if(wheel.onGetReward)
        {
            CoinManager.Instance.shopAddCoin(wheel.reward);
            Debug.Log(wheel.reward);
            wheel.onGetReward = false;
        }
    }


}
