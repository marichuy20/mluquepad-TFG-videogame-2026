using UnityEngine;
using UnityEngine.AI;

public class ShortDistanceEnemy : Enemy
{
    public NavMeshAgent agent;
    protected float x = 0;
    protected float y = 0;
    protected bool isCloseToPlayer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void init()
    {
        base.init();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        x = agent.transform.position.x;
        y = agent.transform.position.y;
    }

    protected void SetStates()
    {
        //TODO: Make sure enemy is facing player - Different enemies have different ways of facing
        //Wolf - attacks in front - left?
        //Cat - attacks in the back - right?
        //Is moving left
        if(x > agent.transform.position.x)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            enemyAnimator.SetBool("isMoving", true); 
        //Is moving right
        }else if (x < agent.transform.position.x)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            enemyAnimator.SetBool("isMoving", true); 
        //Is moving up
        }else if(y < agent.transform.position.y && x == agent.transform.position.x)
        {
            enemyAnimator.SetBool("isMoving", true); 
        //Is moving down
        }else if(y > agent.transform.position.y && x == agent.transform.position.x)
        {
            enemyAnimator.SetBool("isMoving", true);    
        }else if(y == agent.transform.position.y && x == agent.transform.position.x)
        {
            enemyAnimator.SetBool("isMoving", false);
        }
        
        enemyAnimator.SetBool("isAttacking", !enemyAnimator.GetBool("isMoving"));

        if(health <= 0f)
        {
            enemyAnimator.SetBool("isDead", true);
        }

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
}
