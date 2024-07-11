using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSlot : MonoBehaviour
{
    public Image[] gunSlot;
    public GunManager gunManager;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gunSlot.Length; i++)
        {
            Color color = gunSlot[i].GetComponent<Image>().color;
            if (gunManager.gunImages[i] == null)
            {
                color.a = 0f;
            }
            else
            {
                color.a = 1f;
            }
            gunSlot[i].GetComponent<Image>().color = color;
            gunSlot[i].GetComponent<Image>().sprite = gunManager.gunImages[i];
        }
        
    }
    private void Update()
    {
        //gameObject.GetComponent<Image>().sprite = gunImages[selectGunNum];
    }


}
