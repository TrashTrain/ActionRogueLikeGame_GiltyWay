using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunIcon : MonoBehaviour
{
    // ���Ŀ� ��ų �޾ƿͼ� ��ü �� ó�� �� �� �ְ�.
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
