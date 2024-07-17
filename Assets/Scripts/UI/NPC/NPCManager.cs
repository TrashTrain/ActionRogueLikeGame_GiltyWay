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
            // 카메라 확대 기능 필요 JI Camera
            _isAction = true;
            scanObject = scanObj;
            talkText.text = "이것의 이름은 " + scanObject.name + "이다.";
        }
        
        talkPanel.SetActive(_isAction);

    }
}

