using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuffPanelSystem : MonoBehaviour
{
    public List<ItemData> itemDataGroup;
    //public ItemData[] itemDataGroup;
    public Dictionary<string, ItemData> itemDB;

    public Buff[] itemBuffs;
    
    //buff info
    public GameObject buffInfoObj;
    public RectTransform buffInfoTransform;
    public TextMeshProUGUI buffInfoItemName;
    public TextMeshProUGUI buffInfoItemDesc;
    public TextMeshProUGUI buffInfoItemDuration;
    
    public RectTransform iconLayer;

    private ItemIcon icon;
    
    private bool isPointerInBG;
    private bool isPointerInFrame;

    private Buff focusedBuff;

    public Buff FocusedBuff => focusedBuff;
    
    void Start()
    {
        itemDB = new Dictionary<string, ItemData>();
            // foreach (var data in itemDataGroup)
            // {
            //     itemDB.Add(data.name, data);
            // }
            //
            // foreach (var itemKey in itemDB.Keys)
            // {
            //     SetItem(itemKey); // 부딪혔을 때 setitem하는 걸로 고치기
            // }
    }

    private void Update()
    {
        foreach (var data in itemDataGroup)
        {
            itemDB.Add(data.name, data);
        }

        foreach (var itemKey in itemDB.Keys)
        {
            SetItem(itemKey); // 부딪혔을 때 setitem하는 걸로 고치기
        }
    }

    public bool SetItem(string itemKey)
    {
        Buff targetBuff = null;
        for (var i = 0; i < itemBuffs.Length; i++)
        {
            if (!itemBuffs[i].isFilled)
            {
                targetBuff = itemBuffs[i];
                break;
            }
        }

        if (targetBuff == null) return false;
        
        targetBuff.SetItem(itemDB[itemKey]);
        
        return true;
    }

    public void InitBuffInfo(ItemData itemData)
    {
        buffInfoObj.SetActive(true);

        buffInfoItemName.text = itemData.itemName;
        buffInfoItemDesc.text = itemData.itemDesc;
        buffInfoItemDuration.text = itemData.itemDuration;
    }

    public void ExitBuffInfo()
    {
        buffInfoObj.SetActive(false);
    }
    
    public void BuffInfoMove(Vector2 pos)
    {
        buffInfoTransform.anchoredPosition = pos;
    }
    
    public void OnBGEnter(BaseEventData eventDAta)
    {
        isPointerInBG = true;
    }
    
    public void OnBGExit(BaseEventData eventDAta)
    {
        isPointerInBG = false;
    }
    
    public void OnFrameEnter(BaseEventData eventDAta)
    {
        isPointerInFrame = true;
    }
    
    public void OnFrameExit(BaseEventData eventDAta)
    {
        isPointerInFrame = false;
    }
    public void SetFocusedBuff(Buff buff)
    {
        focusedBuff = buff;
    }
}
