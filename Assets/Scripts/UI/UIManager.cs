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
    
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
