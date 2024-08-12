using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; // 풀링할 프리팹
    public int poolSize = 200; // 초기 풀 크기

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        // 풀 초기화
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.GetComponent<BossBullet>().pool = this;
            pool.Enqueue(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            // 필요한 경우 추가로 생성
            GameObject obj = Instantiate(prefab);
            return obj;
        }
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}