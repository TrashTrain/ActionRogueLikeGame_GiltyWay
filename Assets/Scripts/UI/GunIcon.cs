using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunIcon : MonoBehaviour
{
    public GunSlot gunSlot;
    private void Update()
    {
        if (gunSlot.gunImages[GunSlot.selectGunNum] == null) return;
        gameObject.GetComponent<Image>().sprite = gunSlot.gunImages[GunSlot.selectGunNum];
    }




}
