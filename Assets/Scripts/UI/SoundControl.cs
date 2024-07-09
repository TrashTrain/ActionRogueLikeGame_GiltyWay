using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [Header("soundCheck")]
    public GameObject soundCheckT;
    public GameObject soundCheckF;

    [Header("soundBarControl")]
    public GameObject soundBarValue;
    public GameObject effectBarValue;

    [Header("SoundManager")]
    public GameObject bgm;
    // Start is called before the first frame update
    void Start()
    {
        soundBarValue.GetComponent<Slider>().value = 0.5f;
        effectBarValue.GetComponent<Slider>().value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        bgm.GetComponent<AudioSource>().volume = soundBarValue.GetComponent<Slider>().value;
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
