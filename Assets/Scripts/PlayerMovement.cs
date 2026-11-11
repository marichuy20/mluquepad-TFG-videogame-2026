using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator mainHeroAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainHeroAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = movement * speed;
        mainHeroAnimator.SetBool("isMovingRight", movement.x > 0 && movement.y == 0);
        mainHeroAnimator.SetBool("isMovingUp", movement.x == 0 && movement.y > 0);
        mainHeroAnimator.SetBool("isMovingDown", movement.x == 0 && movement.y < 0);
        mainHeroAnimator.SetBool("isMovingLeft", movement.x < 0 && movement.y == 0);
        mainHeroAnimator.SetBool("isNotMoving", movement == Vector2.zero);

    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
