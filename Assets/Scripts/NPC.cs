using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private bool isContact = false;
    public GameObject EButton;
    [Header("NPCInfo")]
    public int id;
    public bool isNpc;

    [Header("DialogSystem")]
    public DialogSystem dialog;

    public int index = 0;
    private void Update()
    {
        if (isContact)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialog.Action(gameObject);
                if (true)
                {
                    UIManager.instance.slotController.RandomSlot();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            EButton.SetActive(true);
            isContact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {

            EButton.SetActive(false);
            isContact = false;
        }
    }

}
