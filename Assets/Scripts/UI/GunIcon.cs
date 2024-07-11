using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunIcon : MonoBehaviour
{
    public GunManager gunManager;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = gunManager.gunImages[GunManager.selectGunNum];
    }
    private void Update()
    {
        //gameObject.GetComponent<Image>().sprite = gunImages[selectGunNum];
    }




}
