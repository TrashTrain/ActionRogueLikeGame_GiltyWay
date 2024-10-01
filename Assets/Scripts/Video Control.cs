using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer video;
    public string nextSceneName;
    
    void Start()
    {
        video.loopPointReached += CheckOver;
    }
    
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneLoader.LoadScene(nextSceneName);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneLoader.LoadScene(nextSceneName);
        }
    }
}
