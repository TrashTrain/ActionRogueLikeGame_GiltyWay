using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private bool isContact = false;
    public GameObject EButton;


    [Header("NPCManager")]
    public NPCManager npcManager;

    private void Update()
    {
        if (isContact)
        {
            EButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                EButton.SetActive(false);
                npcManager.Action(gameObject);
            }
        }
        else
        {
            EButton.SetActive(false);
        }
    }
    public void SetNPC(GameObject npc)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isContact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isContact = false;
        }
    }

}
