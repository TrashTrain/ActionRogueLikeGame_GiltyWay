using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{

    public GameObject[] Info;

    //private bool[] isButtonClick;
    List<bool> isButtonClick = new List<bool>();

    private int check = 0;
    private void Awake()
    {
        for (int i = 0; i < Info.Length; i++)
        {
            isButtonClick.Add(false);
        }
    }
    public void OnMenuButtonClick(int a)
    {
        
        if(check != a)
        {
            for (int i = 0; i < Info.Length; i++)
            {
                isButtonClick[i] = false;
                Info[i].SetActive(isButtonClick[i]);
            }
            check = a;
        }
        
        if (!isButtonClick[a])
        {
            //Debug.Log("false");
            isButtonClick[a] = true;
            Info[a].SetActive(isButtonClick[a]);
        }
        else
        {
            //Debug.Log("true");
            isButtonClick[a] = false;
            Info[a].SetActive(isButtonClick[a]);
        }

    }
    public void OnClickStartPage()
    {
        SceneLoader.LoadScene("MainScene");
        Pause.OnApplicationPause(false); 
    }
}
