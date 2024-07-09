using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadCanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        SceneManager.LoadScene("Tutorial Map");
    }

    public void OnClickLoad()
    {
        if (LoadCanvas != null)
        {
            LoadCanvas.SetActive(true);
        }
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    
    
}
