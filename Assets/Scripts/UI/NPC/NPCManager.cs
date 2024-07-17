using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public TextMeshProUGUI talkText;
    private GameObject scanObject;


    public void Action(GameObject scanObj)
    {
        Pause.OnApplicationPause(true);
        scanObject = scanObj;
        talkText.text = "�̰��� �̸��� " + scanObject.name + "�̴�.";
    }
}

