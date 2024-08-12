using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public GameObject arrowPrefab; // 화살표 프리팹
    public Transform player; // 플레이어의 Transform
    public Transform[] targetMonsters; // 목표 몬스터들의 Transform 배열

    private SimpleArrow[] arrows; // 생성된 화살표들을 저장할 배열

    void Start()
    {
        // 화살표 배열 초기화
        arrows = new SimpleArrow[targetMonsters.Length];

        // 각 몬스터에 대해 화살표를 생성하고 초기화
        for (int i = 0; i < targetMonsters.Length; i++)
        {
            GameObject arrowObject = Instantiate(arrowPrefab, transform); // 화살표 생성 후, ArrowManager의 자식으로 설정
            SimpleArrow arrow = arrowObject.GetComponent<SimpleArrow>();

            arrow.player = player; // 플레이어의 Transform 할당
            arrow.targetMonster = targetMonsters[i]; // 타겟 몬스터의 Transform 할당

            arrows[i] = arrow; // 배열에 저장
        }
    }

    // 필요 시 추가적인 관리 기능을 위한 Update 메서드
    void Update()
    {
        // 예를 들어, 모든 화살표를 업데이트하거나 제거하는 로직을 추가할 수 있음
    }
}