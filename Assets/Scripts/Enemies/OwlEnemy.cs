using UnityEngine;

public class OwlEnemy : Enemy
{
    public bool isAttacking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.init();
        isAttacking = true;
    }

    // Update is called once per frame
    void Update()
    {
        enemyAnimator.SetBool("isDead", health <= 0f);
        UpdateHealthBar();
        StartCoroutine(Dead());
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Owl only throw arrows if player is not inside Circle collider
            isAttacking = false;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttacking = true;
        }
    }

}
