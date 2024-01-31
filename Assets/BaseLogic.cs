using UnityEngine;

public class BaseLogic : MonoBehaviour
{
    [SerializeField] private KeyCode KeyJump; //Кнопка для прыжка
    [SerializeField] private KeyCode KeyLeft; //Кнопка для движения налево
    [SerializeField] private KeyCode KeyRight; //Кнопка для движения направо

    public Vector2 MoveDirection; //В инспекторе для оси x указать не более 0.05. Иначе скорость будет очень большой
    private Rigidbody2D _rigidbody2D; //Подключаем физику
    private Animator _animator; // Подключаем анимацию

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
