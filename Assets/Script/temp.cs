using UnityEditor.U2D.Path;
using UnityEngine;


public class temp : MonoBehaviour
{
    public GameObject coin;

    public RectTransform tempPos;


    void Start()
    {
        LeanTween.move(coin, tempPos.anchoredPosition, 2f);
    }
}