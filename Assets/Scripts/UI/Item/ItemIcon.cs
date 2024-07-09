using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Buff buff;
    public Vector2 posOffset;
    
    private RectTransform rectTransform;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetPos(Vector2 pos)
    {
        rectTransform.anchoredPosition = pos - posOffset;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buff.MouseEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buff.MouseExit();
    }

    public void Reset()
    {
        rectTransform.SetParent(buff.transform);
        rectTransform.anchoredPosition = new Vector2(100f, 100f);
        buff.Reset();
    }

    public void BackToBuff()
    {
        rectTransform.SetParent(buff.transform);
        rectTransform.anchoredPosition = new Vector2(100f, 100f);
        buff.BackToSlot();
    }
}
