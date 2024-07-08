using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMgr : MonoBehaviour
{
    public static BuffMgr instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject buffPrefab;

    public void CreateBuff(string type, float per, float du, Sprite icon)
    {
        GameObject go = Instantiate(buffPrefab, transform);
        go.GetComponent<Buff>().Init(type, per, du);
        go.GetComponent<UnityEngine.UI.Image>().sprite = icon;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
