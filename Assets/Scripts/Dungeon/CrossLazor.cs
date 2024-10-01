using UnityEngine;

public class CrossLaser : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float laserLength = 5f; // 레이저의 길이
    public float rotationSpeed = 30f; // 회전 속도 (도/초)
    public LayerMask playerLayer; // 플레이어 레이어
    public float damage = 10f; // 플레이어에게 입히는 데미지

    private Vector3[] positions = new Vector3[8]; // 8개의 점을 저장 (중앙 4번 + 4개 끝점)

    void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        lineRenderer.positionCount = 8; // 8개의 점을 설정
        
        // 레이저 두께 설정
        lineRenderer.startWidth = 0.1f; // 시작 두께
        lineRenderer.endWidth = 0.1f; // 끝 두께
        
        UpdateLaserPositions(); // 초기 레이저 위치 설정
    }

    void Update()
    {
        // 레이저 회전
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        // 레이저 위치 업데이트
        UpdateLaserPositions();

        // 충돌 체크 및 데미지 처리
        CheckLaserCollision();
    }

    void UpdateLaserPositions()
    {
        // 중앙점 설정 (4번 추가하여 십자 모양 만들기)
        positions[0] = transform.position;
        positions[2] = transform.position;
        positions[4] = transform.position;
        positions[6] = transform.position;

        // 레이저 끝점 설정 (십자 모양)
        positions[1] = transform.position + transform.up * laserLength;
        positions[3] = transform.position - transform.up * laserLength;
        positions[5] = transform.position + transform.right * laserLength;
        positions[7] = transform.position - transform.right * laserLength;

        // 라인 렌더러에 위치 업데이트
        lineRenderer.SetPositions(positions);
    }

    void CheckLaserCollision()
    {
        for (int i = 1; i < positions.Length; i += 2)
        {
            // 레이저 각 선분에 대해 충돌 검사
            RaycastHit2D hit = Physics2D.Raycast(positions[i - 1], positions[i] - positions[i - 1], laserLength, playerLayer);
            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<PlayerController>().GetDamaged(damage, gameObject, Vector2.zero);
            }
        }
    }
}
