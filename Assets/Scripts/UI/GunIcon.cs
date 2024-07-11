using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunIcon : MonoBehaviour
{
    public PlayerController player;
    private Sprite[] gunImages = new Sprite[7];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < player.guns.Length; i++)
        {
            gunImages[i] = player.guns[i].GetComponent<SpriteRenderer>().sprite;
        }

        gameObject.GetComponent<Image>().sprite = gunImages[0];
    }



}
