using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class EndingController : MonoBehaviour
{
    public VideoPlayer video;

    void Start()
    {
        video.loopPointReached += CheckOver;
    }
    
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneLoader.LoadScene("Town Map");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneLoader.LoadScene("Town Map");
        }
    }
}
