using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfileInfo : MonoBehaviour
{
    public PlayerController player;
    
    public GameObject name;
    public GameObject atk;
    public GameObject def;
    public GameObject spd;

    private float originalATK = 10f;
    private float originalDEF = 10f;
    private float originalSPD = 5f;

    private float currentATK = 10f;
    private float currentDEF = 10f;
    private float currentSPD = 5f;

    // player Find <-

    void Start()
    {
        // originalATK = player.atk;
        // originalDEF = player.def;
        // originalSPD = player.speed;
        //
        name.GetComponent<TextMeshProUGUI>().text = " Name : Player";
        atk.GetComponent<TextMeshProUGUI>().text = $" ATK :  {originalATK}";
        def.GetComponent<TextMeshProUGUI>().text = $" DEF :  {originalDEF}";
        spd.GetComponent<TextMeshProUGUI>().text = $" SPD :  {originalSPD}";
    }
    
    // Update is called once per frame
    void Update()
    {
        if (player = null) return;
        float diffATK = player.atk - originalATK;
        float diffDEF = player.def - originalDEF;
        float diffSPD = player.speed - originalSPD;
    
        if(diffATK > 0f)
            atk.GetComponent<TextMeshProUGUI>().text = $" ATK :  {player.atk} (+{diffATK})";
        else if (diffATK < 0f)
            atk.GetComponent<TextMeshProUGUI>().text = $" ATK :  {player.atk} ({diffATK})";
        else 
            atk.GetComponent<TextMeshProUGUI>().text = $" ATK :  {player.atk}";
        
        if(diffDEF > 0f)
            def.GetComponent<TextMeshProUGUI>().text = $" DEF :  {player.def} (+{diffDEF})";
        else if (diffDEF < 0f)
            def.GetComponent<TextMeshProUGUI>().text = $" DEF :  {player.def} ({diffDEF})";
        else
            def.GetComponent<TextMeshProUGUI>().text = $" DEF :  {player.def}";
    
        if(diffSPD > 0f)
            spd.GetComponent<TextMeshProUGUI>().text = $" SPD :  {player.speed} (+{diffSPD})";
        else if (diffSPD < 0f)
            spd.GetComponent<TextMeshProUGUI>().text = $" SPD :  {player.speed} ({diffSPD})";
        else
            spd.GetComponent<TextMeshProUGUI>().text = $" SPD :  {player.speed}";
    
    }

    // public void InitProfileInfo(float newAtk, float newDef, float newSpd)
    // {
    //     originalATK = newAtk;
    //     currentATK = originalATK;
    //     SetATK(currentATK);
    //
    //     originalDEF = newDef;
    //     currentDEF = originalDEF;
    //     SetDEF(currentDEF);
    //     // def.GetComponent<TextMeshProUGUI>().text = $" DEF :  {newDef}";
    //     
    //     originalSPD = newSpd;
    //     currentSPD = originalSPD;
    //     SetSPD(currentSPD);
    //     // spd.GetComponent<TextMeshProUGUI>().text = $" SPD :  {newSpd}";
    //     
    // }

    // public void SetATK(float CurrentATK)
    // {
    //     currentATK = CurrentATK;
    //     float diff = currentATK - originalATK;
    //     if(diff > 0f)
    //         atk.GetComponent<TextMeshProUGUI>().text = $" ATK :  {currentATK} (+{diff})";
    //     else if (diff < 0f)
    //         atk.GetComponent<TextMeshProUGUI>().text = $" ATK :  {currentATK} ({diff})";
    //     else 
    //         atk.GetComponent<TextMeshProUGUI>().text = $" ATK :  {currentATK}";
    // }
    //
    // public void SetDEF(float CurrentDEF)
    // {
    //     currentDEF = CurrentDEF;
    //     float diff = currentDEF - originalDEF;
    //     if(diff > 0f)
    //         def.GetComponent<TextMeshProUGUI>().text = $" DEF :  {currentDEF} (+{diff})";
    //     else if (diff < 0f)
    //         def.GetComponent<TextMeshProUGUI>().text = $" DEF :  {currentDEF} ({diff})";
    //     else 
    //         def.GetComponent<TextMeshProUGUI>().text = $" DEF :  {currentDEF}";
    // }
    //
    // public void SetSPD(float CurrentSPD)
    // {
    //     currentSPD = CurrentSPD;
    //     float diff = currentSPD - originalSPD;
    //     if(diff > 0f)
    //         spd.GetComponent<TextMeshProUGUI>().text = $" SPD :  {currentSPD} (+{diff})";
    //     else if (diff < 0f)
    //         spd.GetComponent<TextMeshProUGUI>().text = $" SPD :  {currentSPD} ({diff})";
    //     else 
    //         spd.GetComponent<TextMeshProUGUI>().text = $" SPD :  {currentSPD}";
    // }
}
