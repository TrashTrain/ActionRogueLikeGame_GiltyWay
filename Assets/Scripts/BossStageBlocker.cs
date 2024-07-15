using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageBlocker : MonoBehaviour
{
	public Transform player;
	private Transform bossBlock;
	private KingSlimeAI kingActive;
	public GameObject kingSlime;
	
	public bool isBlocked = false;

	private float timer;
	public int waitingTime = 2;

    void Start()
    {
	    // bossBlock = GameObject.Find("Stage_1").transform.Find("Boss Stage");
	    kingActive = GameObject.Find("King Slime").GetComponent<KingSlimeAI>();
    }

    void Update() 	// 플레이어가 도착하면 / 문을 닫고 / 슬라임 활성화
    {
	    if (player.position.x >= 260f) // 플레이어가 도착하면
	    {
		    GameObject.Find("Stage_1").transform.Find("Boss Stage").gameObject.SetActive(true);
				// 문을 닫고
		    isBlocked = true;
	    }

	    if (isBlocked)
	    {
		    timer += Time.deltaTime;
		    
		    if (timer > waitingTime)
			    kingActive.SetReady();
				// 딜레이 이후 슬라임 활성화
	    }

	    // if (kingSlime == false) // 슬라임 존재하지 않으면
	    // {
		   //  GameObject.Find("Stage_1").transform.Find("Boss Stage").gameObject.SetActive(false);
		   //  // 문을 연다 문 열라고
		   //  isBlocked = true;
	    // }
    }

    public void doorDpen()
    {
	    GameObject.Find("Stage_1").transform.Find("Boss Stage").gameObject.SetActive(false);
    }
}
