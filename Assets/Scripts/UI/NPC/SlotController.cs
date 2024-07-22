using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public SlotData[] slotDataGroup;

    [Header("Slot1")]
    public Image[] slotItems;

    [Header("Slot2")]
    public TextMeshProUGUI[] slotNames;

    [Header("Slot3")]
    public TextMeshProUGUI[] slotDescriptions;

    private int[] rands = new int[3];

    void Start()
    {
        RandomSlot();
    }
    public void RandomSlot()
    {
        for (int i = 0; i < rands.Length; i++)
        {
            rands[i] = Random.Range(0, slotDataGroup.Length);
            slotItems[i].sprite = slotDataGroup[rands[i]].itemImage;
            slotNames[i].text = slotDataGroup[rands[i]].itemName;
            slotDescriptions[i].text = slotDataGroup[rands[i]].itemDescription;
            slotDescriptions[i].font = slotDataGroup[rands[i]].font;
        }
        
     
    }
    public void OnButtonClick()
    {
        gameObject.SetActive(false);
        RandomSlot();
        gameObject.SetActive(true);
    }

    public void ShowSlotPanel()
    {
        gameObject.SetActive(true);
    }
    public void CloseSlotPanel()
    {
        gameObject.SetActive(false);
    }
}
