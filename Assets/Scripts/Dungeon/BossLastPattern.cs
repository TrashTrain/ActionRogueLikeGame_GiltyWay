using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLastPattern : MonoBehaviour
{
    public GameObject BossMapLazor;
    public GameObject ArrowManager;
    public Golem boss;
    public bool executedTwoLazorAction = false; // 2개 남았을 때의 함수 실행 여부 체크
    public bool executedOneLazorAction = false; // 1개 남았을 때의 함수 실행 여부 체크
    public bool executedZeroLazorAction = false;

    public bool isBossLastPattern = false;
    public int remainLazor = 4;

    public void SetActiveBossMapLazor()
    {
        BossMapLazor.SetActive(true);
    }
    
    public void SetActiveArrowManager()
    {
        ArrowManager.SetActive(true);
    }

    private void Update()
    {
        if(!isBossLastPattern) return;
        
        // 자식 오브젝트의 현재 개수 확인
        int currentChildCount = BossMapLazor.transform.childCount;

        if (currentChildCount < remainLazor)
        {
            remainLazor = currentChildCount;

            if (remainLazor == 2 && !executedTwoLazorAction)
            {
                boss.ShootBigBullet(); // 보스의 2개 남았을 때 실행할 함수
                executedTwoLazorAction = true;
            }

            if (remainLazor == 1 && !executedOneLazorAction)
            {
                boss.SetActiveCrossLazor(); // 보스의 1개 남았을 때 실행할 함수
                executedOneLazorAction = true;
            }
            
            if (remainLazor == 0 && !executedZeroLazorAction)
            {
                boss.Die(); // 보스의 0개 남았을 때 실행할 함수
                executedZeroLazorAction = true;


                isBossLastPattern = false;
            }
        }
    }
}
