using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenButton : MonoBehaviour, IPointerDownHandler
{
    public Action Clicked;
    public void OnPointerDown(PointerEventData eventData) => Clicked?.Invoke();
}