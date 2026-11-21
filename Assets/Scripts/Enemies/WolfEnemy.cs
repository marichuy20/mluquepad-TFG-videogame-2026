using UnityEngine;
using UnityEngine.AI;

public class WolfEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    private float x = 0;
    private float y = 0;
    private bool isCloseToPlayer = false;
    private float health = 100f;
    private Player player;
    public Animator wolfAnimator;
    public UnityEngine.UI.Image fillBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wolfAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        x = agent.transform.position.x;
        y = agent.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        SetStates();
        HarmPlayer();
        UpdateHealthBar();

        //Enemy is placed right in front the player
        agent.SetDestination(player.transform.position + new Vector3(0.8f, 0, 0));
        //TODO: Change destination if player already has something in front of it
    }

    private void SetStates()
    {
        wolfAnimator.SetBool("isMovingLeft", x > agent.transform.position.x);
        wolfAnimator.SetBool("isMovingRight", x < agent.transform.position.x);
        wolfAnimator.SetBool("isOnlyMovingUp", y < agent.transform.position.y && x == agent.transform.position.x);
        wolfAnimator.SetBool("isOnlyMovingDown", y > agent.transform.position.y && x == agent.transform.position.x);
        wolfAnimator.SetBool("isDead", health <= 0f);
        //Enemy attacks when it's close to the player and it's not moving
        wolfAnimator.SetBool("isAttacking", wolfAnimator.GetBool("isMovingLeft") == false && wolfAnimator.GetBool("isMovingRight") == false && wolfAnimator.GetBool("isOnlyMovingUp") == false && wolfAnimator.GetBool("isOnlyMovingDown") == false);

        x = agent.transform.position.x;
        y = agent.transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCloseToPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCloseToPlayer = false;
        }
    }

    private void HarmPlayer()
    {
        if(isCloseToPlayer && wolfAnimator.GetBool("isAttacking"))
        {
            //TODO: Check if param could be better
            player.DecreaseHealth(Time.deltaTime*1f);
        }
    }

    private void UpdateHealthBar()
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