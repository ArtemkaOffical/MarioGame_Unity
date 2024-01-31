using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private bool isFlip;
    [SerializeField] private bool isGround;
    [SerializeField, Range(1,10)] private float _jumpForce;
    [SerializeField, Range(1, 7)] protected float Speed;

    protected Rigidbody2D Rigidbody2D;
    protected Animator Animator;
    private float _moveAxis;
    private float _rayCastDistane = 0.6f;

    private void Awake()
    { 
        isFlip = true;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveHandler();
        FlipHandler(_moveAxis);
        Jump(KeyCode.Space);
        GroundHandler();

    }
   
    public virtual void MoveHandler()
    {
        _moveAxis = Input.GetAxis("Horizontal");
        Rigidbody2D.velocity = new Vector2(_moveAxis * Speed, Rigidbody2D.velocity.y);

        if (_moveAxis != 0)
            Animator.SetBool("isRunning", true);
        else
            Animator.SetBool("isRunning", false);
    }

    public virtual void FlipHandler(float moveAxis)
    {
        if (moveAxis > 0 && !isFlip)
            FlipCharacter();
        else if (moveAxis < 0 && isFlip)
            FlipCharacter();
    }

    private void GroundHandler()
    {
        RaycastHit2D hit = Physics2D.Raycast(GetComponent<BoxCollider2D>().bounds.center,Vector2.down, _rayCastDistane, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            isGround = true;
            Animator.SetBool("isJumping", false);
        }
        else
        {
            isGround = false;
            Animator.SetBool("isJumping", true);
        }
    }

    private void FlipCharacter()
    {
        isFlip = !isFlip;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    public virtual void Jump(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode) && isGround)
            Rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

}