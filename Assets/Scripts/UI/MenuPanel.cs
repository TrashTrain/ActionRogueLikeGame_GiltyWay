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
        if (!PlayerController.IsControllable) return;
        if (!isMenuClick)
        {
            isMenuClick = true;
            menuScroll.SetActive(isMenuClick);
            //Pause.OnApplicationPause(true);
            Time.timeScale = 0;
        }
        
    }
    private void Update()
    {
        if (!PlayerController.IsControllable) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuClick)
            {
                isMenuClick = false;
                menuScroll.SetActive(isMenuClick);
                //Pause.OnApplicationPause(false);
                Time.timeScale = 1;

            }
            else
            {
                isMenuClick = true;
                menuScroll.SetActive(isMenuClick);
                //Pause.OnApplicationPause(true);
                Time.timeScale = 0;
            }
            
            
        }
    }
}
