//using UnityEngine;

//public class PlayerMove : MonoBehaviour
//{
//    public float moveSpeed = 5f;       // ĳ���� �̵� �ӵ�
//    public float rotationSpeed = 720f; // ȸ�� �ӵ� (�ε巯�� ȸ����)
//    private Animator animator;

//    void Start()
//    {
//        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
//    }

//    void Update()
//    {
//        // �Է°� �ޱ�
//        float horizontal = Input.GetAxis("Horizontal"); // �¿� �Է�
//        float vertical = Input.GetAxis("Vertical");     // �յ� �Է�

//        // �÷��̾� ���� �̵� ���� ����
//        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;

//        // �̵� ó��
//        if (moveDirection.magnitude > 0.1f)
//        {
//            // �̵�
//            transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

//            // �̵� �������� ȸ�� ó��
//            Quaternion targetRotation = Quaternion.LookRotation(moveDirection.normalized);
//            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
//        }
//    }
//}

using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed = 3f;        // �ȱ� �ӵ�
    public float runSpeed = 6f;         // �ٱ� �ӵ�
    public float rotationSpeed = 720f;  // ȸ�� �ӵ�
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
        bool isRunning = Input.GetKey(KeyCode.LeftShift); // Shift Ű �Է� Ȯ�� (�ٱ�)

        // �̵� �ӵ� ����
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        // �̵� ���� ���� (�÷��̾� ����)
        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;

        // �̵� ó��
        if (moveDirection.magnitude > 0.1f)
        {
            // �̵�
            transform.position += moveDirection.normalized * currentSpeed * Time.deltaTime;

            // �̵� �������� ȸ�� ó��
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection.normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // �ִϸ��̼� ����
            animator.SetBool("isWalking", !isRunning); // �ȱ� �ִϸ��̼�
            animator.SetBool("isRunning", isRunning);  // �ٱ� �ִϸ��̼�
        }
        else
        {
            // ������ ����
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
    }
}

