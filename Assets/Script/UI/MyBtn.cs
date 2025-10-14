using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyBtn : Button
{
    [SerializeField]
    private float sentitivity = 0.05f;
    private WaitForSecondsRealtime wait;

    private Coroutine CR = null;

    protected override void Awake()
    {
        base.Awake();
        wait = new WaitForSecondsRealtime(sentitivity);
    }
    bool isPointerDown;
    public event Action<bool> onBtnPressed;
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        isPointerDown = true;
        if (CR != null)
        {
            StopCoroutine(CR);
            CR = null;
        }
        CR = StartCoroutine(RasieEvent());
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (CR != null)
        {
            StopCoroutine(CR);
            CR = null;
        }
    }

    private IEnumerator RasieEvent()
    {
        yield return null;
        yield return wait;
        while (isPointerDown)
        {
            // yield return wait;
            yield return new WaitForSecondsRealtime(sentitivity);
            onBtnPressed?.Invoke(true);
        }
    }
}
