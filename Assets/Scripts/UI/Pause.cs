using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPause = true;
    public static void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0f;
            pause = false;
        }
        else
        {
            Time.timeScale = 1f;
            pause = true;
        }
        isPause = pause;
    }

}
