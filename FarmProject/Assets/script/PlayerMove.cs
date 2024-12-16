using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;  // �÷��̾��� �̵� �ӵ�

    void Update()
    {
        // ȭ��ǥ Ű �Է����� �̵� ������ ���
        float moveX = Input.GetAxis("Horizontal");  // �¿� ȭ��ǥ (A/D, ����/������)
        float moveY = Input.GetAxis("Vertical");    // ���� ȭ��ǥ (W/S, ��/�Ʒ�)

        // �̵� ���� ���
        Vector3 move = new Vector3(moveX, 0f, moveY) * moveSpeed * Time.deltaTime;

        // �÷��̾� �̵�
        transform.Translate(move);
    }
}
