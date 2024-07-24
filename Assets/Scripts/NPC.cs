using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private bool isContact = false;
    public GameObject EButton;
    public string npcName;

    public int index;
    private void Update()
    {
        if (isContact)
        {
            if (Input.GetKeyDown(KeyCode.E) && PlayerController.IsControllable)
            {
                UIManager.instance.dialogSystem.ActiveDialog(index, npcName);
                index = UIManager.instance.dialogSystem.nextDialogNum;
                
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
