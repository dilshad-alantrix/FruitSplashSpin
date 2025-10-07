using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float fillTime = 2f;
    [SerializeField] private GameObject loadingScreen;

    void Start()
    {
        loadingScreen.SetActive(false);
    }

    public void Load()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(FillSlider());
    }
    IEnumerator FillSlider()
    {
        slider.value = 0;
        float elapsed = 0f;
        while (elapsed < fillTime)
        {
            elapsed += Time.deltaTime;
            slider.value = Mathf.Clamp01(elapsed / fillTime);
            yield return null;  
        }
        loadingScreen.SetActive(false);
       
    }
    
}
