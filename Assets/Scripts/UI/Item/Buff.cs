using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BuffPanelSystem buffPanelSystem;
    private ItemData itemData;

    public ItemData ItemData => itemData;

    public Image itemImage;

    private bool _isFilled = false;
    public bool isFilled => _isFilled;

    public void SetItem(ItemData data)
    {
        itemData = data;
        itemImage.sprite = data.itemImage;

        var tempColor = itemImage.color;
        tempColor.a = 1f;
        itemImage.color = tempColor;

        _isFilled = true;
    }

    public void MouseEnter()
    {
        if (itemData == null) return;
        buffPanelSystem.InitBuffInfo(itemData);
    }

    public void MouseExit()
    {
        buffPanelSystem.ExitBuffInfo();
    }

    public void Reset()
    {
        itemImage.sprite = null;
            
        var tempcolor = itemImage.color;
        tempcolor.a = 0f;
        itemImage.color = tempcolor;

        itemImage.raycastTarget = true;

        itemData = null;
        
        _isFilled = false;
    }
    
    public void BackToSlot()
    {
        itemImage.raycastTarget = true;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        buffPanelSystem.SetFocusedBuff(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(buffPanelSystem.FocusedBuff == this)
            buffPanelSystem.SetFocusedBuff(null);
    }
}
