using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitDamageText : MonoBehaviour
{
    public float moveSpeed = 100f;
    private TextMeshProUGUI hitDamageText;

    private RectTransform rectTransform;
    private Vector3 upTransform = Vector3.zero;
    private Transform enemyTrans;
    private Vector3 screenPosition;
    
    
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        hitDamageText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Invoke("Destroy", 0.5f);
    }

    private void FixedUpdate()
    {
        upTransform += moveSpeed * Time.deltaTime * Vector3.up;
        // 월드 좌표를 화면 좌표로 변환
        if (enemyTrans != null)
        {
            screenPosition = Camera.main.WorldToScreenPoint(enemyTrans.position);
        }

        transform.position = screenPosition + upTransform;

        //rectTransform.position = screenPosition;

        //rectTransform.position += moveSpeed * Time.deltaTime * Vector3.up * 10;
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void SetHitDamage(float hitDamage)
    {
        hitDamageText.text = $"   - {hitDamage}";
    }

    public void SetEnemyTrans(Transform transform)
    {
        enemyTrans = transform;
    }
}
