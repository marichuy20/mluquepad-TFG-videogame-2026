using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

//TODO: Create caracter class and add dead(), health, animator...
public class Player : MonoBehaviour
{
    private float speed = 3f;
    private float maxHealth = 100f;
    private float health = 100f;
    private bool isCloseToEnemy = false;
    private Enemy closerEnemy;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator mainHeroAnimator;
    public GameObject gameOverMessage;
    //Player has five lives - five hearts
    public GameObject[] heartsFills = new GameObject[5];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        gameOverMessage.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        mainHeroAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = movement * speed;
        
        SetStates();
        HarmEnemy();
        UpdateHealthBar();
        StartCoroutine(Die());
    }

    private void SetStates()
    {
        //TODO: Can it be improved more? Too many ifs?
        //Is moving left - rotate sprite x
        if(movement.x < 0 && movement.y == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            mainHeroAnimator.SetBool("isMoving", true);
        // Is moving left - rotate sprite x   
        }else if(movement.x > 0 && movement.y == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            mainHeroAnimator.SetBool("isMoving", true);
        //Is not moving
        }else if(movement == Vector2.zero)
        {
            mainHeroAnimator.SetBool("isMoving", false);
        //Is moving up
        }else if(movement.x == 0 && movement.y > 0)
        {
            mainHeroAnimator.SetBool("isMoving", true);
        //Is moving down
        }else if(movement.x == 0 && movement.y < 0)
        {
            mainHeroAnimator.SetBool("isMoving", true);
        }

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
            //TODO: Improve when several enemies are close
            isCloseToEnemy = true;
            closerEnemy = collision.gameObject.GetComponent<Enemy>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //TODO: Improve when several enemies are close
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
            //Fill last heart
            heartsFills[4].GetComponent<UnityEngine.UI.Image>().fillAmount = (health-80)/20;
            //Make sure the other hearts are fill
            heartsFills[3].GetComponent<UnityEngine.UI.Image>().fillAmount = 1;
            heartsFills[2].GetComponent<UnityEngine.UI.Image>().fillAmount = 1;
            heartsFills[1].GetComponent<UnityEngine.UI.Image>().fillAmount = 1;
            heartsFills[0].GetComponent<UnityEngine.UI.Image>().fillAmount = 1;
        }else if(health < 80f && health >= 60f)
        {
            //Make sure the last heart is empty
            heartsFills[4].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
            //Fill fourth hearlt
            heartsFills[3].GetComponent<UnityEngine.UI.Image>().fillAmount = (health-60)/20;
            heartsFills[2].GetComponent<UnityEngine.UI.Image>().fillAmount = 1;
            heartsFills[1].GetComponent<UnityEngine.UI.Image>().fillAmount = 1;
            heartsFills[0].GetComponent<UnityEngine.UI.Image>().fillAmount = 1;
        }else if(health < 60f && health >= 40f)
        {
            //Make sure the last hearts are empty
            heartsFills[4].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
            heartsFills[3].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
            //Fill third hearlt
            heartsFills[2].GetComponent<UnityEngine.UI.Image>().fillAmount = (health-40)/20;
            heartsFills[1].GetComponent<UnityEngine.UI.Image>().fillAmount = 1;
            heartsFills[0].GetComponent<UnityEngine.UI.Image>().fillAmount = 1;
        }
        else if(health < 40f && health >= 20f)
        {
            //Make sure the last hearts are empty
            heartsFills[4].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
            heartsFills[3].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
            heartsFills[2].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
            //Fill second heart
            heartsFills[1].GetComponent<UnityEngine.UI.Image>().fillAmount = (health-20)/20;
            heartsFills[0].GetComponent<UnityEngine.UI.Image>().fillAmount = 1;
        }
        else if(health < 20f && health >= 0f)
        {
            //Make sure the last hearts are empty
            heartsFills[4].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
            heartsFills[3].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
            heartsFills[2].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
            heartsFills[1].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
            //Fill first heart
            heartsFills[0].GetComponent<UnityEngine.UI.Image>().fillAmount = (health-0)/20;
        }
    }

    public IEnumerator Die()
    {
        if(health <= 0f && !gameOverMessage.gameObject.activeSelf)
        {
            mainHeroAnimator.SetBool("isDead", true);
            //Give time for the bunny_die animation to finish
            yield return new WaitForSeconds(2);
            gameOverMessage.SetActive(true);
        }
    }

    public void IncreaseHealth(float powerUp)
    {
        health += powerUp;
        if(health > maxHealth)
        {
            health = maxHealth;
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
