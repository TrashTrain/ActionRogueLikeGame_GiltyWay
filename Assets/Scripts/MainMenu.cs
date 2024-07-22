using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadCanvas;
    public GameObject doorMove;
    public void OnClickNewGame()
    {
        //SceneManager.LoadScene("Tutorial Map");
        SceneLoader.LoadScene("Tutorial Map");
    }

    public void OnClickLoad()
    {
        doorMove.GetComponent<Animator>().SetTrigger("LoadButton");
        //if()
        LoadCanvas.SetActive(true);
    }
    public void OnClickXButton()
    {
        doorMove.GetComponent<Animator>().SetTrigger("LoadButton");
        LoadCanvas.SetActive(false);
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    
    
}
