using UnityEngine;

public class SimpleArrow : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public Transform targetMonster; // 목표 몬스터의 Transform
    public LineRenderer lineRenderer; // 라인 렌더러 컴포넌트
    public float arrowSize = 1f; // 화살표 크기
    public float distanceFromPlayer = 2f; // 플레이어로부터 화살표까지의 거리
    public float arrowWidth = 0.1f; // 화살표의 굵기

    void Start()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        // 라인 렌더러의 점 개수 설정 (세 개의 점으로 ">" 모양을 그림)
        lineRenderer.positionCount = 3;

        // 라인 렌더러의 굵기 설정
        lineRenderer.startWidth = arrowWidth;
        lineRenderer.endWidth = arrowWidth;
    }

    void Update()
    {
        DrawArrow();
    }

    void DrawArrow()
    {
        // 목표 몬스터까지의 방향 계산
        Vector3 direction = (targetMonster.position - player.position).normalized;

        // 화살표의 위치를 플레이어로부터 목표 방향으로 이동
        Vector3 arrowPosition = player.position + direction * distanceFromPlayer;

        // 화살표의 기본 모양 ">"
        Vector3[] arrowPoints = new Vector3[3];
        arrowPoints[0] = arrowPosition + new Vector3(0, arrowSize, 0); // 위쪽 점
        arrowPoints[1] = arrowPosition + new Vector3(arrowSize, 0, 0); // 화살표 끝점 (오른쪽)
        arrowPoints[2] = arrowPosition + new Vector3(0, -arrowSize, 0); // 아래쪽 점

        // 각 점을 몬스터 방향으로 회전 (화살표 위치를 기준으로)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        for (int i = 0; i < arrowPoints.Length; i++)
        {
            arrowPoints[i] = RotatePointAroundPivot(arrowPoints[i], arrowPosition, angle);
        }

        // 라인 렌더러에 점 설정
        lineRenderer.SetPositions(arrowPoints);
    }

    Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, float angle)
    {
        // 주어진 중심(pivot)을 기준으로 점(point)을 회전
        return Quaternion.Euler(0, 0, angle) * (point - pivot) + pivot;
    }
}