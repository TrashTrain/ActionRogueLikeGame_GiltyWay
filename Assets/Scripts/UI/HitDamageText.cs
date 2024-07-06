using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitDamageText : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    private RectTransform rectTransform;
    private TextMeshProUGUI hitDamageText;
    
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        hitDamageText = GetComponent<TextMeshProUGUI>();
        
        SetHitDamage(0);
    }

    private void Start()
    {
        Invoke("Destroy", 2f);
    }

    private void FixedUpdate()
    {
        rectTransform.position += moveSpeed * Time.deltaTime * Vector3.up;
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void SetHitDamage(float hitDamage)
    {
        hitDamageText.text = $"{hitDamage}";
    }
}
