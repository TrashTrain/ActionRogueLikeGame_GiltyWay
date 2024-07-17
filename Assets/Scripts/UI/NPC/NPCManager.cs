using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public TextMeshProUGUI talkText;
    private GameObject scanObject;
    public GameObject talkPanel;
    public static bool _isAction;

    public void Action(GameObject scanObj)
    {
        if(_isAction)
        {
            _isAction = false;
            
        }
        else
        {
            // ī�޶� Ȯ�� ��� �ʿ� JI Camera
            _isAction = true;
            scanObject = scanObj;
            talkText.text = "�̰��� �̸��� " + scanObject.name + "�̴�.";
        }
        
        talkPanel.SetActive(_isAction);

    }
}

