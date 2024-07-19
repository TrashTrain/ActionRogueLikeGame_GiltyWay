using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    public DialogSet[] dialogSets;

    public GameObject talkPanel;
    public TextMeshProUGUI talkText;
    public static bool _isAction = false;

    [Header("Select")]
    public RectTransform selectCursor;
    public GameObject selectPanel;
    private int talkIndex = 0;
    public bool isRandomSlot = false;
    public void CallMethod(int methodNum = 0)
    {
        if (methodNum < 0)
        {
            return;
        }
        switch (methodNum)
        {
            case 0:
                break;
            case 1:
                selectPanel.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void Action(GameObject scanObj)
    {
        NPC npcData = scanObj.GetComponent<NPC>();
  
        Talk(npcData.index);

        talkPanel.SetActive(_isAction);

    }
    void Talk(int idx)
    {
        
        if (idx < 0)
        {
            return;
        }
        
        var dialogSet = dialogSets[idx].dialogElements[talkIndex];
        talkText.text = dialogSet.dialog;
        CallMethod(dialogSet.selectYes);
        _isAction = true;
        if (talkIndex == dialogSets[idx].dialogElements.Length)
        {
            return;
        }
        talkIndex++;
    }
    private void Update()
    {
        if (!selectPanel.activeSelf) return;
        YESorNO();
    }
    void YESorNO()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            if (isRandomSlot)
            {
                isRandomSlot = false;
            }
            else
            {
                isRandomSlot = true;
            }
            selectCursor.anchoredPosition = new Vector2(selectCursor.anchoredPosition.x, -selectCursor.anchoredPosition.y);
        }
        
    }
}

