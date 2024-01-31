using UnityEngine;

public class BaseLogic : MonoBehaviour
{
    [SerializeField] private KeyCode KeyJump; //������ ��� ������
    [SerializeField] private KeyCode KeyLeft; //������ ��� �������� ������
    [SerializeField] private KeyCode KeyRight; //������ ��� �������� �������

    public Vector2 MoveDirection; //� ���������� ��� ��� x ������� �� ����� 0.05. ����� �������� ����� ����� �������
    private Rigidbody2D _rigidbody2D; //���������� ������
    private Animator _animator; // ���������� ��������

    public void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void Update()
    {

        if (Input.GetKey(KeyLeft))
            _rigidbody2D.velocity -= MoveDirection;
        if (Input.GetKey(KeyRight))
            _rigidbody2D.velocity += MoveDirection;

        if (_rigidbody2D.velocity.x != 0)
            _animator.SetBool("isRunning", true);
        else
            _animator.SetBool("isRunning", false);
    }

}
