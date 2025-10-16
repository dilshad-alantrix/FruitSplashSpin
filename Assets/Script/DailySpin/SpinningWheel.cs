using System;
using UnityEngine;
using UnityEngine.UI;

public class SpinningWheel : MonoBehaviour
{
    [SerializeField] private float SpinSpeed;
    [SerializeField] private float Diclaration;
    [SerializeField] private Button SpinBtn;
    [SerializeField] private Button StopBtn;
    [SerializeField] private GameObject BtnObj;

    public event Action spinStop;

    public int  reward { get; private set; }
    public bool onGetReward;
    private bool isStop;
    private float CurrentSpeed;

    void OnEnable()
    {
        SpinBtn.onClick.AddListener(spin);
        StopBtn.onClick.AddListener(Stop);
    }
    void OnDisable()
    {
         SpinBtn.onClick.RemoveListener(spin);
        StopBtn.onClick.RemoveListener(Stop);
    }

    void Start()
    {
        CurrentSpeed = 0;
    }

    void Update()
    {
        if (CurrentSpeed > 0)
        {
            transform.Rotate(0, 0, CurrentSpeed * Time.deltaTime);
                if (isStop)
        {
            CurrentSpeed -= Diclaration * Time.deltaTime;
            if (CurrentSpeed < 0)
            {
                CheckRewards();
                CurrentSpeed = 0;
            }
        }
        }
       
    }

    private void CheckRewards()
    {
        float value = transform.eulerAngles.z;
        reward=0;
        if (value >= 0 && value < 45)
        {
            reward = 10;
        }
        else if (value >= 45 && value < 90)
        {
            reward = 50;
        }
        else if (value >= 90 && value < 135)
        {
            reward = 10;
        }
        else if (value >= 135 && value < 180)
        {
            reward = 75;
        }
        else if (value >= 180 && value < 225)
        {
            reward = 20;
        }
        else if (value >= 225 && value < 270)
        {
            reward = 100;
        }
        else if (value >= 270 && value < 315)
        {
            reward = 10;
        }
        else if (value >= 315 && value < 360)
        {
            reward = 20;
        }

        spinStop?.Invoke();
        
    }

    private void spin()
    {
        CurrentSpeed = SpinSpeed;
        BtnObj.SetActive(false);
        isStop = false;

    }

    private void Stop()
    {
        isStop = true;
    }
    
   
 
}