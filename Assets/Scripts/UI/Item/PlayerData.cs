using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;

    public PlayerController player;

    public float originalHp = 50f;
    public float originalSpeed = 5f;
    public float originalAtk = 10;
    public float originalDef = 10;

    public List<Buff> onBuff = new List<Buff>();

    public float BuffChange(string type, float origin)
    {
        if (onBuff.Count > 0)
        {
            float temp = 0;
            for (int i = 0; i < onBuff.Count; i++)
            {
                if (onBuff[i].type.Equals(type))
                {
                    temp += origin * onBuff[i].percentage;
                }
            }

            return origin + temp;
        }
        else
        {
            return origin;
        }
    }

    public void ChooseBuff(string type)
    {
        switch (type)
        {
            case "Hp":
                player.hp = BuffChange(type, originalHp);
                break;
            case "Speed":
                player.speed = BuffChange(type, originalSpeed);
                break;
            case "Def":
                player.def = BuffChange(type, originalDef);
                break;
            case "Atk":
                player.atk = BuffChange(type, originalAtk);
                break;
        }
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
