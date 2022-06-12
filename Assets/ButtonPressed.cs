using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    TMP_Text text;
    RectTransform textRect;
    RectTransform originalRect;
    Color originalColor;
    public Color pressedColor;
    public Vector2 pressedOffset = new Vector2(8f, 16f);

    void Start()
    {
        text = this.GetComponentInChildren<TMP_Text>();
        textRect = text.GetComponent<RectTransform>();
        RectTransform originalRect = textRect;
        originalColor = text.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        textRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, pressedOffset.x, textRect.rect.width);
        textRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, pressedOffset.y, textRect.rect.height);
        text.color = pressedColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        textRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0f, textRect.rect.width);
        textRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, pressedOffset.x, textRect.rect.height);
        text.color = originalColor;
    }

}
