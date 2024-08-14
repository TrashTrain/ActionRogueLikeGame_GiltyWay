using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DataManager.instance.isClear);
        if (DataManager.instance.isClear)
        {
            var goa = GameObject.Find("Goa").gameObject.transform.GetChild(0);
            goa.gameObject.SetActive(DataManager.instance.isClear);
        }
    }

}
