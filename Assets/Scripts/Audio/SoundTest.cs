using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SoundManager.instance.PlaySound("s1", transform);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SoundManager.instance.PlaySound("s2", transform);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SoundManager.instance.PlaySound("s2", transform);
        }
    }
}
