using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    private Toggle _toggle;
    void Start()
    {
        PlayerPrefs.SetInt("Sound", 1);
        _toggle = GetComponent<Toggle>();
        _toggle.isOn = PlayerPrefs.GetInt("Sound") == 1 ? true : false;
    }

    
    void Update()
    {
         AudioListener.volume = _toggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("Sound", _toggle.isOn ? 1 : 0);
    }
}
