using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DailySpinManager : MonoBehaviour
{
    [SerializeField] private SpinningWheel wheel;
    [SerializeField] private GameObject SpinIcon;
    [SerializeField] private GameObject SpinPanal;
    [SerializeField] private GameObject blackBackPanal;
    [SerializeField] private CoinAnimation animation;


    void OnEnable()
    {
        wheel.spinStop += stop;
    }
    void OnDisable()
    {
        wheel.spinStop += stop;
    }
    void Start()
    {
        if (CheckSpin())
        {
            Debug.Log("avilable");
            SpinIcon.SetActive(true);
        }
        else
        {
            Debug.Log("not avilable");
            SpinIcon.SetActive(false);
        }
    }

    private bool CheckSpin()
    {
        string lastSpin = PlayerPrefs.GetString("Daily", "");
        if (String.IsNullOrEmpty(lastSpin)) return true;

        DateTime lastSpinTime = DateTime.Parse(lastSpin);
        TimeSpan timeSince = DateTime.Now - lastSpinTime;


        return timeSince.TotalHours >= 24;
    }
    
    private void stop()
    {
        CoinManager.Instance.shopAddCoin(wheel.reward);
        animation.CoinMove();
        PlayerPrefs.SetString("Daily", DateTime.Now.ToString());
        PlayerPrefs.Save();
        StartCoroutine(closePanal());
    }
    IEnumerator closePanal()
    {
        yield return new WaitForSeconds(2f);
        SpinPanal.SetActive(false);
        blackBackPanal.SetActive(false);
        SpinIcon.SetActive(false);

    }
   
    public void reset()
    {
        PlayerPrefs.DeleteKey("Daily");
        Debug.Log("reset");
    }

}
