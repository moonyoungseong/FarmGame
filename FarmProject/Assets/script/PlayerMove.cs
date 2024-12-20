using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;       // 캐릭터 이동 속도
    public float rotationSpeed = 720f; // 회전 속도 (부드러운 회전용)
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
    }

    void Update()
    {
        // 입력값 받기
        float horizontal = Input.GetAxis("Horizontal"); // 좌우 입력
        float vertical = Input.GetAxis("Vertical");     // 앞뒤 입력

        // 플레이어 기준 이동 방향 설정
        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;

        // 이동 처리
        if (moveDirection.magnitude > 0.1f)
        {
            // 이동
            transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

            // 이동 방향으로 회전 처리
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection.normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
