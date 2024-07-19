using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUpInfo : MonoBehaviour
{
    public GameObject hpUpObject;
    
    public void PrintHpUp(Transform charTrans, float plusHp)
    {
        var hpUp = Instantiate(hpUpObject, this.transform);
        
        // 월드 좌표를 화면 좌표로 변환
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(charTrans.position);
        
        // hp 상승 텍스트 위치 설정
        hpUp.transform.position = screenPosition;
        hpUp.GetComponent<HpUpText>().SetHpUp(plusHp);
        hpUp.GetComponent<HpUpText>().SetCharTrans(charTrans);
    }
}
