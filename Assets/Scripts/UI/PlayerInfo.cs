using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public PlayerHpBar playerHpBar;

    public void SetHp(float currentHp)
    {
        playerHpBar.SetHp(currentHp);
    }

    public void InitPlayerUI(PlayerController playerController)
    {
        playerHpBar.InitPlayerHp(playerController.hp);
    }
}
