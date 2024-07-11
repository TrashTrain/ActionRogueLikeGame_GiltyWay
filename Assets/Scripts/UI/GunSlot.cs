using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSlot : MonoBehaviour
{
    public Image[] gunSlot;
    public PlayerController player;
    public Sprite[] gunImages = new Sprite[8];
    public static int selectGunNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < player.guns.Length; i++)
        {
            gunImages[i] = player.guns[i].GetComponent<SpriteRenderer>().sprite;
        }
        for (int i = 0; i < gunImages.Length; i++)
        {
            gunSlot[i].sprite = gunImages[i];
        }
        for (int i = 0; i < gunSlot.Length; i++)
        {
            Color color = gunSlot[i].GetComponent<Image>().color;
            if (gunImages[i] == null)
            {
                color.a = 0f;
            }
            else
            {
                color.a = 1f;
            }
            gunSlot[i].GetComponent<Image>().color = color;

        }
        
    }
    private void Update()
    {
        //gameObject.GetComponent<Image>().sprite = gunImages[selectGunNum];
    }


}
