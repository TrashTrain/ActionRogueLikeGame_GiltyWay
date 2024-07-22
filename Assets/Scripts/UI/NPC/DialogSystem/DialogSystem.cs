using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    public DialogSet[] dialogSets;

    public TextMeshProUGUI talkText;
    

    [Header("Select")]
    public RectTransform selectCursor;
    public GameObject selectPanel;
    private int talkIndex = 0;
    public bool isActiveSlot = true;

    private DialogSet curDialogSet;
    private DialogElement curDialog;

    public int nextDialogNum;

    [Header("NpcName")]
    public TextMeshProUGUI npcName;

    private bool isActive = false;

    private void Update()
    {
        if (selectPanel.activeSelf)
            SelectPanelInput();
        else
        {
            DialogInput();
        }
    }

    public void CallMethod(int methodNum = 0)
    {
        if (methodNum < 0)
            return;

        switch (methodNum)
        {
            case 0:
                NextSentence();
                //InActiveDialog();
                break;
            case 1:
                UIManager.instance.slotController.ShowSlotPanel();
                break;
            default:
                break;
        }

        selectPanel.SetActive(false);
    }
    public void ActiveDialog(int dialogSetIndex, string npcName)
    {
        if (isActive) return;
        if (dialogSetIndex < 0)
            return;

        isActive = true;
        talkIndex = 0;
        this.npcName.text = npcName;

        selectPanel.SetActive(false);

        gameObject.SetActive(true);
        PlayerController.IsControllable = false;

        curDialogSet = dialogSets[dialogSetIndex];
        nextDialogNum = curDialogSet.nextIdx;
        NextSentence();
        
    }

    public void InActiveDialog()
    {
        isActive = false;  

        PlayerController.IsControllable = true;
        gameObject.SetActive(false);
    }
    void NextSentence()
    {
        //Debug.Log(talkIndex);
        if (talkIndex >= curDialogSet.dialogElements.Length)
        {
            InActiveDialog(); 
            return;
        }
        curDialog = curDialogSet.dialogElements[talkIndex];
        talkText.text = curDialog.dialog;

        if (curDialog.selectYes >= 0)
            selectPanel.SetActive(true);

        talkIndex++;
        
    }

    void SelectPanelInput()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            if (isActiveSlot)
            {
                isActiveSlot = false;
            }
            else
            {
                isActiveSlot = true;
            }
            selectCursor.anchoredPosition = new Vector2(selectCursor.anchoredPosition.x, -selectCursor.anchoredPosition.y);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isActiveSlot)
            {
                Debug.Log(curDialog.selectYes);
                CallMethod(curDialog.selectYes);
            }
            else
            {
                CallMethod(curDialog.selectNo);
            }
        }
    }

    private void DialogInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && !UIManager.instance.slotController.gameObject.activeSelf)
        {
            NextSentence();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.instance.slotController.CloseSlotPanel();
        }
    }
}

