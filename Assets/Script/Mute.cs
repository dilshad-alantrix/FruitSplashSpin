using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    [SerializeField] private Toggle Toggle_1;
    [SerializeField] private Toggle Toggle_2;

   
    
    void Start()
    {
        PlayerPrefs.SetInt("Sound", 1);
        Toggle_1.isOn = true;
        Toggle_2.isOn = true;
        
    }


    void Update()
    {

        if (Toggle_1.isOn != (PlayerPrefs.GetInt("Sound") == 1 ? true : false))
        {
            PlayerPrefs.SetInt("Sound", Toggle_1.isOn ? 1 : 0);
            Toggle_2.isOn = Toggle_1.isOn;
        }
        if (Toggle_2.isOn != (PlayerPrefs.GetInt("Sound") == 1 ? true : false))
        {
            PlayerPrefs.SetInt("Sound", Toggle_2.isOn ? 1 : 0);
            Toggle_1.isOn = Toggle_2.isOn;
        }

        AudioListener.volume = PlayerPrefs.GetInt("Sound");

    }
    

}
