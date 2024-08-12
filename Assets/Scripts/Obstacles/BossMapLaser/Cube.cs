using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IDamageable
{
    public float cubeHP = 10f;

    public void GetDamaged(float damage)
    {
        // if (damage <= 0) return;
        
        cubeHP -= damage;
        if (cubeHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
