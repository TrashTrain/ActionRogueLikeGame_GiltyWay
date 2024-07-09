using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class BuffText : MonoBehaviour
{
    public GameObject buffText;
    public Transform buffPanel;
    private List<Buff> activeBuffs = new List<Buff>();

    void Update()
    {
        for (int i = activeBuffs.Count - 1; i >= 0; i--)
        {
            activeBuffs[i].duration -= Time.deltaTime;
            if (activeBuffs[i].duration <= 0)
            {
                Destroy(activeBuffs[i].textObject);
                activeBuffs.RemoveAt(i);
            }
            else
            {
                activeBuffs[i].textObject.GetComponent<TextMeshProUGUI>().text = $"{activeBuffs[i].name}: {activeBuffs[i].currentState} / {activeBuffs[i].duration:F1}s";
            }
        }
    }

    public void AddBuff(string buffName, float currentState, float duration)
    {
        GameObject newBuffText = Instantiate(buffText, buffPanel);
        newBuffText.GetComponent<TextMeshProUGUI>().text = $"{buffName}: {currentState} / {duration:F1}s";
        activeBuffs.Add(new Buff { name = buffName, currentState = currentState, duration = duration, textObject = newBuffText });
    }

    private class Buff
    {
        public string name;
        public float duration;
        public float currentState;
        //public Image icon;
        public GameObject textObject;
    }
}
