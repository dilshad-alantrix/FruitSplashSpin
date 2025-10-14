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

    void OnEnable()
    {
        Toggle_1.onValueChanged.AddListener(ValueChange);
        Toggle_2.onValueChanged.AddListener(ValueChange);
    }

    void OnDisable()
    {
         Toggle_1.onValueChanged.RemoveListener(ValueChange);
         Toggle_2.onValueChanged.RemoveListener(ValueChange);
    }


    private void ValueChange(bool isOn)
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
