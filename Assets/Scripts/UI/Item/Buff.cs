using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    public string type;
    public float percentage;
    public float duration;
    public float currentTime;
    
    public Image icon;

    public void Init(string ty, float per, float du)
    {
        type = ty;
        percentage = per;
        duration = du;
        currentTime = duration;
        icon.fillAmount = 1;
        
        Execute();
    }

    WaitForSeconds seconds = new WaitForSeconds(0.1f);
    
    public void Execute()
    {
        PlayerData.instance.onBuff.Add(this);
        PlayerData.instance.ChooseBuff(type);
        StartCoroutine(Activation());
    }

    IEnumerator Activation()
    {
        while (currentTime > 0)
        {
            currentTime -= 0.1f;
            icon.fillAmount = currentTime / duration;
            yield return new WaitForSeconds(0.1f);
        }

        icon.fillAmount = 0;
        currentTime = 0;
        Deactivation();
    }

    public void Deactivation()
    {
        PlayerData.instance.onBuff.Remove(this);
        PlayerData.instance.ChooseBuff(type);
        Destroy(gameObject);
    }
}
