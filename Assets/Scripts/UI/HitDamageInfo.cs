using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamageInfo : MonoBehaviour
{
    public GameObject hitDamageObject;
    
    public void PrintHitDamage(Transform enemyTrans, float damage)
    {
        var hitDamage = Instantiate(hitDamageObject, this.transform);
        
        // 월드 좌표를 화면 좌표로 변환
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(enemyTrans.position);
        
        // 데미지 텍스트 위치 설정
        hitDamage.transform.position = screenPosition;
        hitDamage.GetComponent<HitDamageText>().SetHitDamage(damage);
        hitDamage.GetComponent<HitDamageText>().SetEnemyTrans(enemyTrans);
    }
}
