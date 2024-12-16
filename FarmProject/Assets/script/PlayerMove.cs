using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;  // 플레이어의 이동 속도

    void Update()
    {
        // 화살표 키 입력으로 이동 방향을 계산
        float moveX = Input.GetAxis("Horizontal");  // 좌우 화살표 (A/D, 왼쪽/오른쪽)
        float moveY = Input.GetAxis("Vertical");    // 상하 화살표 (W/S, 위/아래)

        // 이동 벡터 계산
        Vector3 move = new Vector3(moveX, 0f, moveY) * moveSpeed * Time.deltaTime;

        // 플레이어 이동
        transform.Translate(move);
    }
}
