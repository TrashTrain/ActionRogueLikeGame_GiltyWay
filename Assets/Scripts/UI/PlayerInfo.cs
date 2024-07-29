using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public PlayerHpBar playerHpBar;
    
    // ------
    // public ProfileInfo profileInfo;
    // ------

    public void SetHp(float currentHp)
    {
        playerHpBar.SetHp(currentHp);
    }

    public void InitPlayerUI(PlayerController playerController)
    {
        playerHpBar.InitPlayerHp(playerController.hp);
       
        // ------
        // profileInfo.InitProfileInfo(playerController.atk, playerController.def, playerController.speed);
        // ------

    }
}
