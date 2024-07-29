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
    public void OnSlotclick(int slotNum)
    {
        var slotData = slotDataGroup[rands[slotNum]];
        if(slotData.type == ItemType.Status)
            ChangeStatus(slotData);
        if(slotData.type == ItemType.PassiveSkill) 
            GetPassiveSkill(slotData);
        CloseSlotPanel();
    }
    public void OnReRollButtonClick()
    {
        CloseSlotPanel();
        RandomSlot();
        ShowSlotPanel();
    }
    public void ChangeStatus(SlotData slotData)
    {
        if (slotData == null) return;
        PlayerController player = FindObjectOfType<PlayerController>();
        if (slotData.status == StatusType.HP)
            player.maxhp += slotData.value;
        if(slotData.status == StatusType.ATK)
            player.atk += slotData.value;
        if(slotData.status == StatusType.SPD)
            player.speed += slotData.value;
        
        Debug.Log("playerAtk : " + player.atk + "/playerHP : " + player.maxhp + "/playerSPD : " + player.speed);
        UIManager.instance.playerInfo.playerHpBar.InitPlayerHp(player.maxhp);
    }

    public void GetPassiveSkill(SlotData slotData)
    {
        if(slotData == null) return;
        if(slotData.passive == PassiveType.BulletCnt)
        {
            PassiveSkillData.instance.AutomaticBulletCnt += 1;
        }
        
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
