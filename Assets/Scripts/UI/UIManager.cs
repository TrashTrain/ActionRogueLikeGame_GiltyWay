using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Canvas Canvas;

    public PlayerInfo playerInfo;
    public HitDamageInfo hitDamageInfo;

    public GameObject buffPanel;
    public ItemGetText itemGetText;
    public BuffItemController buffItemController;

    public SlotController slotController;
    
    public DialogSystem dialogSystem;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
