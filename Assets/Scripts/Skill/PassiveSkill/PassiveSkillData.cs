using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkillData : MonoBehaviour 
{
    private int automaticBulletCnt = 0;
    public static PassiveSkillData instance = new PassiveSkillData();
    public int AutomaticBulletCnt
    {
        get { return automaticBulletCnt; }

        set{ automaticBulletCnt = value; }
    }



}
