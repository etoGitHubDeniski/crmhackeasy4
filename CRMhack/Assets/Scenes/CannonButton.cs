using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CannonButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Action<float> ButtonReleased;

    private Coroutine _buttonHoldTimer;
    private float _holdButtonTime;

    public void OnPointerDown(PointerEventData eventData)
    {
        _buttonHoldTimer = StartCoroutine(ButtonHoldTimer());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopCoroutine(_buttonHoldTimer);
        ButtonReleased?.Invoke(_holdButtonTime);
    }

    private IEnumerator ButtonHoldTimer()
    {
        _holdButtonTime = 0f;

        while (true)
            _holdButtonTime += Time.deltaTime;    
    }
}
