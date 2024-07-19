using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public GameObject menuScroll;

    private bool isMenuClick = false;
    public void OnMenuButtonClik()
    {
        if (DialogSystem._isAction) return;
        if (!isMenuClick)
        {
            isMenuClick = true;
            menuScroll.SetActive(isMenuClick);
            Pause.OnApplicationPause(true);
        }
        
    }
    private void Update()
    {
        if (DialogSystem._isAction) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuClick)
            {
                isMenuClick = false;
                menuScroll.SetActive(isMenuClick);
                Pause.OnApplicationPause(false);

            }
            else
            {
                isMenuClick = true;
                menuScroll.SetActive(isMenuClick);
                Pause.OnApplicationPause(true);
            }
            
            
        }
    }
}
