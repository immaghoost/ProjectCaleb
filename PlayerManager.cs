using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Variables
    private Animator animator;
    public float speed;
    private new Rigidbody2D rigidbody2D;
    
    //Properties
    private Vector2 LeftOrRight => new Vector2(Input.GetAxisRaw("Horizontal"),
        0) * speed * Time.fixedDeltaTime;
    private Vector2 UpOrDown => new Vector2(0, Input.GetAxisRaw("Vertical"))
                    * speed * Time.fixedDeltaTime;
    private bool IsIdle => rigidbody2D.velocity == Vector2.zero;
    private Vector2 MovePlayer
    {
        set => rigidbody2D.velocity = value;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovementSystem();
        AnimatePlayer();
    }

    private void AnimatePlayer()
    {
        animator.Play(IsIdle ? "Player_Idle" : "Player_walk");
    }

    private void MovementSystem()
    {
        if (Input.GetButton("Horizontal"))
        {
            MovePlayer = LeftOrRight;
        }
        else if (Input.GetButton("Vertical"))
        {
            MovePlayer = UpOrDown;
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
