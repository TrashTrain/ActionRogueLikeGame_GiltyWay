using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;

public class GunSlot : MonoBehaviour
{
    public Image[] gunSlot;
    public GunManager gunManager;
    public GameObject slotCenter;

    public GameObject slot;

    Vector2 slotPos = new();
    int startAngle = 180;
    int endAngle;
    int check = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (gunManager == null) return;

        GunSlotCheck();
    }
    private void Update()
    {
        if (!PlayerController.IsControllable) return;
        OnButtonScreen();
        if (gunManager == null) return;
        if (gunManager.player == null) return;
        GunSlotCheck();
    }

    void GunSlotCheck()
    {
        for (int i = 1; i < gunSlot.Length; i++)
        {
            Color color = gunSlot[i].GetComponent<Image>().color;
            if (gunManager.gunImages[i - 1] == null)
            {
                color.a = 0f;
            }
            else
            {
                color.a = 1f;
            }
            gunSlot[i].GetComponent<Image>().color = color;
            gunSlot[i].GetComponent<Image>().sprite = gunManager.gunImages[i - 1];
        }
        Color zeroColor = gunSlot[0].GetComponent<Image>().color;
        zeroColor.a = 1f;
        gunSlot[0].GetComponent<Image>().color = zeroColor;
        gunSlot[0].GetComponent<Image>().sprite = gunManager.gunImages[GunManager.selectGunNum];
    }
    void OnButtonScreen()
    {
        Vector2 mousePos = Input.mousePosition;
          
        if (Input.GetKeyDown(KeyCode.F))
        {
            slotPos = mousePos;
            slotCenter.GetComponent<Image>().transform.position = slotPos;
            slot.SetActive(true);
        }
        if (Input.GetKey(KeyCode.F))
        {
            Vector2 direction = mousePos - slotPos;
            float angle = Vector2.Angle(Vector2.right, direction);
            if (mousePos.y < slotPos.y)
            {
                angle *= -1;
            }
            
            for (int i = 1; i <= gunSlot.Length; i++)
            {
                endAngle = startAngle - 45;
                if (angle > endAngle && angle < startAngle)
                {
                    check = i;
                }
                startAngle = endAngle;
            }
            startAngle = 180;
            
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            GunManager.selectGunNum = check;
            Debug.Log(GunManager.selectGunNum);
            slot.SetActive(false);
        }
    }

    public static float GetAngle(Vector2 vStart, Vector2 vEnd)
    {
        Vector2 v = vEnd - vStart;

        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }
}
