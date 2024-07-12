using System;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM instance;
    
    private AudioSource audioSource;

    public AudioData[] soundResources;
    private Dictionary<string, AudioClip> BGMDB = new();
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();

            foreach (var soundResource in soundResources)
            {
                BGMDB.Add(soundResource.key, soundResource.Clip);
            }
            
            PlayBGM("MainScene");
        }
    }
    
    public void PlayBGM(string key)
    {
        if (!BGMDB.ContainsKey(key))
        {
            Debug.LogError($"Unknown BGMDB key( )");
            StopBGM();
            return;
        }
        
        SetBGM(BGMDB[key]);
    }

    public void StopBGM()
    {
        audioSource.Stop();
        audioSource.clip = null;
    }
    
    public void SetBGM(AudioClip bgm)
    {
        audioSource.Stop();
        audioSource.clip = bgm;
        audioSource.Play();
        audioSource.loop = true;
    }
}
