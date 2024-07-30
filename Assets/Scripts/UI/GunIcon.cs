using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunIcon : MonoBehaviour
{
    // 추후에 스킬 받아와서 교체 및 처리 할 수 있게.
    public RollingShoot testSkill;
    private void Update()
    {
        if (UIManager.instance.gunSlot.gunImages[GunSlot.selectGunNum] == null) return;
        gameObject.GetComponent<Image>().sprite = UIManager.instance.gunSlot.gunImages[GunSlot.selectGunNum];
    }

    private void FillSkillGauge()
    {

    }


}
