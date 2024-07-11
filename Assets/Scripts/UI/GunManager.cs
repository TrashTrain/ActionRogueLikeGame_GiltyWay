using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public PlayerController player;
    public Sprite[] gunImages = new Sprite[8];
    public static int selectGunNum = 0;
    private void Start()
    {
        for (int i = 0; i < player.guns.Length; i++)
        {
            gunImages[i] = player.guns[i].GetComponent<SpriteRenderer>().sprite;
        }
    }

}
