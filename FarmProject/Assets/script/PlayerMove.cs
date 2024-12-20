using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;       // ĳ���� �̵� �ӵ�
    public float rotationSpeed = 720f; // ȸ�� �ӵ� (�ε巯�� ȸ����)
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
    }

    void Update()
    {
        // �Է°� �ޱ�
        float horizontal = Input.GetAxis("Horizontal"); // �¿� �Է�
        float vertical = Input.GetAxis("Vertical");     // �յ� �Է�

        // �÷��̾� ���� �̵� ���� ����
        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;

        // �̵� ó��
        if (moveDirection.magnitude > 0.1f)
        {
            // �̵�
            transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

            // �̵� �������� ȸ�� ó��
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection.normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
