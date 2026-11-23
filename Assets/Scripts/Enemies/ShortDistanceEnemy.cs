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
        //TODO: Improve how to do this?
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
}
