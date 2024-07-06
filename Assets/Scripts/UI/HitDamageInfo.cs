using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamageInfo : MonoBehaviour
{
    public HitDamageText hitDamageText;
    public GameObject hitDamageObject;
    
    public void PrintHitDamage(Vector3 pos)
    {
        var hitDamage = Instantiate(hitDamageObject, pos, Quaternion.identity);
        //hitDamage.
    }
}
