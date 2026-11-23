using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ShortDistanceEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    protected float x = 0;
    protected float y = 0;
    protected bool isCloseToPlayer = false;
    //TODO: Do all enemies have the same health levels?
    protected float health = 100f;
    protected Player player;
    protected Animator enemyAnimator;
    public UnityEngine.UI.Image fillBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void SetStates()
    {
        enemyAnimator.SetBool("isMovingLeft", x > agent.transform.position.x);
        enemyAnimator.SetBool("isMovingRight", x < agent.transform.position.x);
        enemyAnimator.SetBool("isOnlyMovingUp", y < agent.transform.position.y && x == agent.transform.position.x);
        enemyAnimator.SetBool("isOnlyMovingDown", y > agent.transform.position.y && x == agent.transform.position.x);
        enemyAnimator.SetBool("isDead", health <= 0f);
        //Enemy attacks when it's close to the player and it's not moving
        enemyAnimator.SetBool("isAttacking", enemyAnimator.GetBool("isMovingLeft") == false && enemyAnimator.GetBool("isMovingRight") == false && enemyAnimator.GetBool("isOnlyMovingUp") == false && enemyAnimator.GetBool("isOnlyMovingDown") == false);

        //TODO: Check if this is the most efficient way
        x = agent.transform.position.x;
        y = agent.transform.position.y;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCloseToPlayer = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCloseToPlayer = false;
        }
    }

    //TODO: Do all close distance enemies decrease the same ammount?
    protected void HarmPlayer()
    {
        if(isCloseToPlayer && enemyAnimator.GetBool("isAttacking"))
        {
            //TODO: Check if param could be better
            player.DecreaseHealth(Time.deltaTime*1f);
        }
    }

    protected IEnumerator Dead()
    {
        if(health <= 0f)
        {
            yield return new WaitForSeconds(enemyAnimator.GetCurrentAnimatorClipInfo(0).Length * 1.5f);
            Destroy(this.transform.parent.gameObject);
        }
    }

    protected void UpdateHealthBar()
    {
        if(health >= 0)
        {
            fillBar.fillAmount = health/100f;
        }
    }

    public void DecreaseHealth(float impact)
    {
        health -= impact;
    }

    public float GetHealth()
    {
        return health;
    }
}
