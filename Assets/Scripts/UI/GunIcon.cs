using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunIcon : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
        //if (player.guns[0] == null)
        //    Debug.Log("null");
        //Debug.Log(player.guns[0]);
        //gameObject.GetComponent<Image>().sprite = player.guns[0].GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
