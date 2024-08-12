using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private bool isContact = false;
    public GameObject EButton;
    public string npcName;
    public Sprite npcImage;

    public int index;
    private void Update()
    {
        if (isContact)
        {
            if (Input.GetKeyDown(KeyCode.E) && PlayerController.IsControllable)
            {
                InitNPCInfo();
                UIManager.instance.dialogSystem.ActiveDialog(index, npcName, npcImage);
                //index = UIManager.instance.dialogSystem.nextDialogNum;
                
            }
            
        }
    }
    private void InitNPCInfo()
    {
        var curNPC = UIManager.instance.dialogSystem.npcObj;
        if (curNPC.ContainsKey(npcName))
        {
            Debug.Log("index : " + index);
            index = curNPC[npcName];
            Debug.Log("curindex : " + index);
        }
        else
        {
            Debug.Log("null");
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
