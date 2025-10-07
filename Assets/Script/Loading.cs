using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
        [SerializeField] private float fillTime = 4f;
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
      
        float elapsed = 0f;
        while (elapsed < fillTime)
        {
            elapsed += Time.deltaTime;
            yield return null;  
        }
        loadingScreen.SetActive(false);
       
    }
    
}
