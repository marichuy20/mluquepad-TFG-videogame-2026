using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float speed = 3f;
    private float health = 100f;
    private bool isCloseToEnemy = false;
    //TODO: Maybe create another father name Enemy for all the enemies
    private Enemy closerEnemy;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator mainHeroAnimator;
    //Player has five lives - five hearts
    public GameObject[] heartsFills = new GameObject[5];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainHeroAnimator = GetComponent<Animator>();
        //heartsBar = GameObject.FindGameObjectsWithTag("HeartFill");
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = movement * speed;
        
        SetStates();
        HarmEnemy();
        UpdateHealthBar();
    }

    private void SetStates()
    {
        mainHeroAnimator.SetBool("isMovingRight", movement.x > 0 && movement.y == 0);
        mainHeroAnimator.SetBool("isMovingUp", movement.x == 0 && movement.y > 0);
        mainHeroAnimator.SetBool("isMovingDown", movement.x == 0 && movement.y < 0);
        mainHeroAnimator.SetBool("isMovingLeft", movement.x < 0 && movement.y == 0);
        mainHeroAnimator.SetBool("isNotMoving", movement == Vector2.zero);
        mainHeroAnimator.SetBool("isDead", health <= 0f);
        if (Input.GetKeyDown(KeyCode.Z) && movement == Vector2.zero)
        {
            mainHeroAnimator.SetTrigger("isAttacking");
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCloseToEnemy = true;
            closerEnemy = collision.gameObject.GetComponent<Enemy>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCloseToEnemy = false;
        }
    }

    private void HarmEnemy()
    {
        if(isCloseToEnemy && mainHeroAnimator.GetBool("isAttacking"))
        {
            //TODO: Check if param is correct
            closerEnemy.DecreaseHealth(5);
        }
    }

    //TODO: Improve this function?
    private void UpdateHealthBar()
    {
        if(health <= 100f && health >=80f)
        {
            heartsFills[4].GetComponent<UnityEngine.UI.Image>().fillAmount = (health-80)/20;
        }else if(health < 80f && health >= 60f)
        {
            heartsFills[3].GetComponent<UnityEngine.UI.Image>().fillAmount = (health-60)/20;
        }else if(health < 60f && health >= 40f)
        {
            heartsFills[2].GetComponent<UnityEngine.UI.Image>().fillAmount = (health-40)/20;
        }
        else if(health < 40f && health >= 20f)
        {
            heartsFills[1].GetComponent<UnityEngine.UI.Image>().fillAmount = (health-20)/20;
        }
        else if(health < 20f && health >= 0f)
        {
            heartsFills[0].GetComponent<UnityEngine.UI.Image>().fillAmount = (health-0)/20;
        }
    }

    public void DecreaseHealth(float impact)
    {
        if(health >= 0f)
        {
            health -= impact;
        }
    }

    public float GetHealth()
    {
        return health;
    }
}
