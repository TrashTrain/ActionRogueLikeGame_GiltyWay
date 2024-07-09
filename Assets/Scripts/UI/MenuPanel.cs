using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public GameObject menuScroll;

    private bool isMenuClick = false;
    public void OnMenuButtonClik()
    {
        if (!isMenuClick)
        {
            isMenuClick = true;
            menuScroll.SetActive(isMenuClick);
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuClick)
            {
                isMenuClick = false;
                menuScroll.SetActive(isMenuClick);
            }
            else
            {
                isMenuClick = true;
                menuScroll.SetActive(isMenuClick);
            }
            
            
        }
    }
}
