using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    [Header("soundCheck")]
    public GameObject soundCheckT;
    public GameObject soundCheckF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundButtonClick()
    {
        if (soundCheckT.activeSelf)
        {
            soundCheckT.SetActive(false);
            soundCheckF.SetActive(true);
        }
        else
        {
            soundCheckT.SetActive(true);
            soundCheckF.SetActive(false);
        }
    }
}
