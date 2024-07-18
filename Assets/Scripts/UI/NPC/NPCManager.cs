using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public TalkManager talkManager;
    public TextMeshProUGUI talkText;
    private GameObject scanObject;
    public GameObject talkPanel;
    public static bool _isAction;

    private int talkIndex = 0;

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        NPC npcData = scanObj.GetComponent<NPC>();
        Talk(npcData.id, npcData.isNpc);

        talkPanel.SetActive(_isAction);

    }
    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null)
        {
            _isAction = false;
            talkIndex = 0;
            return;
        }
        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
        _isAction = true;
        talkIndex++;
    }
}

