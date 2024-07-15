using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageBlocker : MonoBehaviour
{
	public Transform player;
	public Transform bossBlock;
	
	public GameObject kingSlime;
	
	public bool isblock = false;


    // Start is called before the first frame update
    void Start()
    {
	    bossBlock = GameObject.Find("Stage_1").transform.Find("Boss Stage");
	    bossBlock.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
	    if (player.position.x >= 260f)
	    {
		    GameObject.Find("Stage_1").transform.Find("Boss Stage").gameObject.SetActive(true);
	    }
	    else
	    {
		    bossBlock.gameObject.SetActive(false);
	    }
    }

	// 플레이어가 도착하면 / 문을 닫고 / 슬라임 활성화
}
