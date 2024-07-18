using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public SlotData[] slotDataGroup;
    public Dictionary<string, SlotData> slotDB;
    
    [Header("Slot1")]
    public Image slot1Image;
    public TextMeshProUGUI slot1Name;
    public TextMeshProUGUI slot1Description;
    [Header("Slot2")]
    public Image slot2Image;
    public TextMeshProUGUI slot2Name;
    public TextMeshProUGUI slot2Description;
    [Header("Slot3")]
    public Image slot3Image;
    public TextMeshProUGUI slot3Name;
    public TextMeshProUGUI slot3Description;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
